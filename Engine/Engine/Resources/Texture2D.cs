// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using OpenTK;
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

        public TextureTarget target;
        public TextureUnit unit;

        public string path = "";

        private FREE_IMAGE_FORMAT format;
        private FIBITMAP bitmap;
        private IntPtr pixels;
        #endregion

        #region Constructors
        public Texture2D(string filepath)
        {
            Debug.Assert(Load(filepath));
        }
        #endregion

        #region Public API
        /// <summary>
        /// Returns the OpenGL texture ID
        /// </summary>
        public uint ID
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
        /// Load the texture
        /// </summary>
        /// <param name="source">filesource (includes extension)</param>
        public override bool Load(string source)
        {
            path = source;

            target = TextureTarget.Texture2D;
            unit = TextureUnit.Texture0;

            _id = (uint)GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, (int)_id);

            GL.TexParameter(target, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(target, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            

            format = FreeImage.GetFileType(source, 0);
            FIBITMAP temp = FreeImage.Load(format, source, FREE_IMAGE_LOAD_FLAGS.DEFAULT);

            bitmap = FreeImage.ConvertTo32Bits(temp);
            FreeImage.Unload(temp);

            _width = FreeImage.GetWidth(bitmap);
            _height = FreeImage.GetHeight(bitmap);

            pixels = FreeImage.GetBits(bitmap);

            GL.TexImage2D(target, 0, PixelInternalFormat.Rgba, (int)_width, (int)_height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, pixels);

            GL.TexParameter(target, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(target, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.GenerateTextureMipmap(_id);

            _bpp = FreeImage.GetBPP(bitmap);

            return true;
        }

        /// <summary>
        /// Binds the texture
        /// </summary>
        public void Bind()
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(target, _id);
        }

        /// <summary>
        /// Unbinds the texture
        /// </summary>
        public void Unbind()
        {
            GL.BindTexture(target, 0);
        }
        #endregion
    }
}
