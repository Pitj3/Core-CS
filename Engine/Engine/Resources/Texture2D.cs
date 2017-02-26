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
            _id = (uint)GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, (int)_id);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            Bitmap bmp = new Bitmap(source);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            _width = (uint)data.Width;
            _height = (uint)data.Height;
            _bpp = (uint)(data.Stride / data.Width);

            bmp.UnlockBits(data);

            return true;
        }
        #endregion
    }
}
