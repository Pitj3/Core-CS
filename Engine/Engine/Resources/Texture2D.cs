// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using System;
using System.Diagnostics;
using System.IO;

using OpenTK.Graphics.OpenGL;

using FreeImageAPI;

namespace CoreEngine.Engine.Resources
{
    /// <summary>
    /// Texture 2D class
    /// </summary>
    public class Texture2D : Resource
    {
        #region Data
        private uint _id;
        private uint _width;
        private uint _height;
        private uint _bpp;

        public TextureTarget Target;
        public TextureUnit Unit;

        private FREE_IMAGE_FORMAT format;
        private FIBITMAP bitmap;
        private IntPtr pixels;
        #endregion

        #region Constructors
        public Texture2D()
        {

        }

        public Texture2D(string filepath)
        {
            Debug.Assert(Load(filepath));
        }
        #endregion

        #region Public API
        /// <summary>
        /// Returns the OpenGL texture ID
        /// </summary>
        public uint TexID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Load the texture from source
        /// </summary>
        /// <param name="source"></param>
        public override bool Load(string source)
        {
            if(source.Contains(".casset"))
            {
                return InternalLoad(source);
            }

            this.Source = source;

            Target = TextureTarget.Texture2D;
            Unit = TextureUnit.Texture0;

            _id = (uint)GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, (int)_id);

            GL.TexParameter(Target, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(Target, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            

            format = FreeImage.GetFileType(source, 0);
            FIBITMAP temp = FreeImage.Load(format, source, FREE_IMAGE_LOAD_FLAGS.DEFAULT);

            bitmap = FreeImage.ConvertTo32Bits(temp);
            FreeImage.Unload(temp);

            _width = FreeImage.GetWidth(bitmap);
            _height = FreeImage.GetHeight(bitmap);

            pixels = FreeImage.GetBits(bitmap);

            GL.TexImage2D(Target, 0, PixelInternalFormat.Rgba, (int)_width, (int)_height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, pixels);

            GL.TexParameter(Target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(Target, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.GenerateTextureMipmap(_id);

            _bpp = FreeImage.GetBPP(bitmap);

            return true;
        }

        /// <summary>
        /// Saves the texture to a .casset file
        /// </summary>
        public override void Save()
        {
            if (!Directory.Exists("Library"))
            {
                Directory.CreateDirectory("Library");
            }

            File.WriteAllText("Library/RES" + base.ID + ".casset", "");

            using (BinaryWriter bw = new BinaryWriter(File.Open("Library/RES" + base.ID + ".casset", FileMode.Append)))
            {
                bw.Write(Source);
            }
        }

        /// <summary>
        /// Binds the texture
        /// </summary>
        public void Bind()
        {
            GL.ActiveTexture(Unit);
            GL.BindTexture(Target, _id);
        }

        /// <summary>
        /// Unbinds the texture
        /// </summary>
        public void Unbind()
        {
            GL.BindTexture(Target, 0);
        }
        #endregion

        #region Internal API
        /// <summary>
        /// Loads the texture from a .casset file
        /// </summary>
        /// <param name="source"></param>
        internal bool InternalLoad(string source)
        {
            using (BinaryReader br = new BinaryReader(File.Open(source, FileMode.Open)))
            {
                string s = br.ReadString();

                return Load(s);
            }
        }
        #endregion
    }
}
