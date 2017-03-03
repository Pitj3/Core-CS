// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine.Resources;
using CoreEngine.Engine.Components;

using CoreEngine.Engine;

namespace CoreEngine.Engine.Rendering
{
    #region Enums
    /// <summary>
    /// Clear flags
    /// </summary>
    [Flags]
    public enum ClearFlags
    {
        SolidColor = 0,
        Depth = 1,
        Nothing = 2
    }
    #endregion

    /// <summary>
    /// Camera class
    /// </summary>
    public class Camera : CoreComponent
    {
        #region Data
        public static Camera Current;

        public Matrix4 projection;
        public Matrix4 view;

        private Color _clearColor;

        public float znear, zfar;
        public float fov;

        public float aspect;

        private bool _ortho = true;
        public bool orthographic
        {
            get
            {
                return _ortho;
            }
            set
            {
                _ortho = value;
                if(value)
                {
                    znear = -10;
                    zfar = 10;

                    // create ortho matrix
                    projection = Matrix4.CreateOrthographicOffCenter(0, _renderSize.X, _renderSize.Y, 0, znear, zfar);
                    view = Matrix4.Identity;
                }
                else
                {
                    znear = 0.01f;
                    zfar = 10000.0f;

                    aspect = _renderSize.X / _renderSize.Y;

                    projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), aspect, znear, zfar);
                    view = Matrix4.LookAt(eye, look, up);
                }
            }
        }

        private Vector2 _renderSize;

        public ClearFlags clearFlags;

        private Texture2D _renderTexture = null;

        public Vector3 eye, look, up;
        #endregion

        #region Construction
        public Camera()
        {
            _renderSize = new Vector2(1280, 720);
            fov = 60.0f;

            clearFlags |= ClearFlags.Depth;

            _clearColor = Color.CornflowerBlue;

            if (_ortho)
            {
                znear = -10;
                zfar = 10;
            }
            else
            {
                znear = 0.01f;
                zfar = 10000.0f;
            }
        }
        #endregion

        #region Public API

        public override void Awake()
        {
            eye = new Vector3(10, 10, 10);
            look = Vector3.Zero;
            up = new Vector3(0, 1, 0);

            if (_ortho)
            {
                // create ortho matrix
                projection = Matrix4.CreateOrthographicOffCenter(0, _renderSize.X, _renderSize.Y, 0, znear, zfar);
                view = Matrix4.Identity;
            }
            else
            {
                aspect = _renderSize.X / _renderSize.Y;

                projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), aspect, znear, zfar);
                view = Matrix4.LookAt(eye, look, up);
            }
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            if (!_ortho)
            {
                eye = parent.position;
                view = Matrix4.LookAt(eye, look, up);
            }
        }

        public override void FixedUpdate()
        {
            
        }

        public override void OnDestroy()
        {
            
        }

        public override void OnPreRender()
        {
            
            if(_renderTexture)
            {
                // render to texture
            }
            else
            {

            }
        }

        public override void OnRenderObject()
        {
            
        }

        public override void OnPostRender()
        {
            
        }


        #endregion
    }
}
