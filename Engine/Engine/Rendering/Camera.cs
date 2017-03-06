// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using System.Drawing;

using CoreEngine.Engine.Resources;
using CoreEngine.Engine.Components;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CoreEngine.Engine.Rendering
{
    /// <summary>
    /// Camera class
    /// </summary>
    public class Camera : CoreComponent
    {
        #region Data

        [IgnoreInSave]
        public static Camera Current;

        public Matrix4 Projection;
        public Matrix4 View;

        public Color ClearColor { get; set; }

        public float ZNear { get; set; }
        public float ZFar { get; set; }
        public float Fov { get; set; }

        public Vector2 RenderSize { get; set; }
        public ClearBufferMask ClearFlags { get; set; }
        public Vector3 Look { get; set; }
        public Vector3 Up { get; set; }

        private bool _orthographic
        {
            get
            {
                return orthographic;
            }
            set
            {
                orthographic = value;
                if(value)
                {
                    ZNear = -10;
                    ZFar = 10;

                    Projection = Matrix4.CreateOrthographicOffCenter(0, RenderSize.X, RenderSize.Y, 0, ZNear, ZFar);
                    View = Matrix4.Identity;
                }
                else
                {
                    ZNear = 0.01f;
                    ZFar = 10000.0f;

                    _aspect = RenderSize.X / RenderSize.Y;

                    if (Parent != null)
                    {
                        Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), _aspect, ZNear, ZFar);
                        View = Matrix4.LookAt(Parent.LocalTransform.Position, Look, Up);
                    }
                }
            }
        }

        private float _aspect;
        private Texture2D _renderTexture = null;
        public bool orthographic { get; set; }

        #endregion

        #region Construction
        public Camera()
        {
            RenderSize = new Vector2(1280, 720);
            Fov = 60.0f;

            ClearFlags |= ClearBufferMask.ColorBufferBit;
            ClearFlags |= ClearBufferMask.DepthBufferBit;

            ClearColor = Color.FromArgb(1, 54, 57, 62);

            orthographic = false;

            _orthographic = orthographic;
            if (_orthographic)
            {
                ZNear = -10;
                ZFar = 10;
            }
            else
            {
                ZNear = 0.01f;
                ZFar = 10000.0f;
            }
        }
        #endregion

        #region Public API

        public override void Awake()
        {
            Look = Vector3.Zero;
            Up = new Vector3(0, 1, 0);

            if (_orthographic)
            {
                // create ortho matrix
                Projection = Matrix4.CreateOrthographicOffCenter(0, RenderSize.X, RenderSize.Y, 0, ZNear, ZFar);
                View = Matrix4.Identity;
            }
            else
            {
                _aspect = RenderSize.X / RenderSize.Y;

                Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), _aspect, ZNear, ZFar);
                View = Matrix4.LookAt(Parent.LocalTransform.Position, Look, Up);
            }
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            _orthographic = orthographic;

            if (!_orthographic)
            {
                Parent.LocalTransform.Position = Parent.LocalTransform.Position;
                Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), _aspect, ZNear, ZFar);
                View = Matrix4.LookAt(Parent.LocalTransform.Position, Look, Up);
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

        }

        public override void OnRenderObject()
        {
            GL.Clear(ClearFlags);
            GL.ClearColor(ClearColor);
        }

        public override void OnPostRender()
        {
            
        }


        #endregion
    }
}
