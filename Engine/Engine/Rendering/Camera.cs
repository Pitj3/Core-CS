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

        [IgnoreInspector]
        public Matrix4 projection;
        [IgnoreInspector]
        public Matrix4 view;

        public Color clearColor { get; set; }

        public float znear { get; set; }
        public float zfar { get; set; }
        public float fov { get; set; }

        public Vector2 renderSize { get; set; }
        public ClearFlags clearFlags { get; set; }
        public Vector3 look { get; set; }
        public Vector3 up { get; set; }

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

                    projection = Matrix4.CreateOrthographicOffCenter(0, renderSize.X, renderSize.Y, 0, znear, zfar);
                    view = Matrix4.Identity;
                }
                else
                {
                    znear = 0.01f;
                    zfar = 10000.0f;

                    _aspect = renderSize.X / renderSize.Y;

                    projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), _aspect, znear, zfar);
                    view = Matrix4.LookAt(parent.transform.position, look, up);
                }
            }
        }

        private float _aspect;
        private Texture2D _renderTexture = null;
        private bool _ortho = true;

        #endregion

        #region Construction
        public Camera()
        {
            renderSize = new Vector2(1280, 720);
            fov = 60.0f;

            clearFlags |= ClearFlags.Depth;

            clearColor = Color.CornflowerBlue;

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
            parent.transform.position = new Vector3(10, 10, 10);
            look = Vector3.Zero;
            up = new Vector3(0, 1, 0);

            if (_ortho)
            {
                // create ortho matrix
                projection = Matrix4.CreateOrthographicOffCenter(0, renderSize.X, renderSize.Y, 0, znear, zfar);
                view = Matrix4.Identity;
            }
            else
            {
                _aspect = renderSize.X / renderSize.Y;

                projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), _aspect, znear, zfar);
                view = Matrix4.LookAt(parent.transform.position, look, up);
            }
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            if (!_ortho)
            {
                parent.transform.position = parent.transform.position;
                projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), _aspect, znear, zfar);
                view = Matrix4.LookAt(parent.transform.position, look, up);
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
