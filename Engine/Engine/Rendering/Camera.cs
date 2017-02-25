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
    [Flags]
    public enum ClearFlags
    {
        SolidColor = 0,
        Depth = 1,
        Nothing = 2
    }
    #endregion

    public class Camera : CoreComponent
    {
        #region Data
        public static Camera Current;

        private Matrix4 _projection;
        private Matrix4 _view;

        private Color _clearColor;

        private float _znear, _zfar;
        private float _fov;

        private float _aspect;

        private bool _orthographic;

        private Vector2 _renderSize;

        private ClearFlags _clearFlags;

        private Texture2D _renderTexture = null;

        private Vector3 _eye, _look, _up;
        #endregion

        #region Construction
        public Camera()
        {
            this._orthographic = true;
            _renderSize = new Vector2(CoreEngine.CurrentApplication.Width, CoreEngine.CurrentApplication.Height);
            _fov = 60.0f;

            _clearFlags |= ClearFlags.Depth;

            _clearColor = Color.CornflowerBlue;

            if (_orthographic)
            {
                _znear = -10;
                _zfar = 10;
            }
            else
            {
                _znear = 0.01f;
                _zfar = 10000.0f;
            }
        }
        #endregion

        #region Public API

        public override void Awake()
        {
            _eye = Vector3.Zero;
            _look = Vector3.Zero;
            _up = Vector3.UnitY;

            if (_orthographic)
            {
                // create ortho matrix
                _projection = Matrix4.CreateOrthographicOffCenter(0, _renderSize.X, _renderSize.Y, 0, _znear, _zfar);
                _view = Matrix4.Identity;
            }
            else
            {
                _aspect = _renderSize.X / _renderSize.Y;

                _projection = Matrix4.CreatePerspectiveFieldOfView(_fov, _aspect, _znear, _zfar);
                _view = Matrix4.LookAt(_eye, _look, _up);
            }
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            
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
