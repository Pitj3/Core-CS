using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine.Logging;

namespace CoreEngine.Engine.Graphics
{
    #region Enums
    /// <summary>
    /// Defines an elements in the BufferLayout
    /// </summary>
    public struct BufferElement
    {
        public string name;
        public VertexAttribPointerType type;
        public uint size;
        public uint count;
        public uint offset;
        public bool normalized;
    };
    #endregion

    /// <summary>
    /// Buffer Layout class
    /// </summary>
    public class BufferLayout
    {
        #region Data
        private uint _size;
        private List<BufferElement> _layout;
        #endregion

        #region Push API
        public void Push<T>(string name, uint count, bool normalized)
        {
            Type type = typeof(T);
            Logger.Log(LogLevel.DEBUG, type.ToString());
        }

        #endregion

        #region Public API
        public List<BufferElement> GetLayout() { return _layout; }
        public uint GetStride() { return _size; }
        #endregion

        #region Private API
        private void Push(string name, VertexAttribPointerType type, uint size, uint count, bool normalized)
        {
            if (_layout == null)
                _layout = new List<BufferElement>();

            _layout.Add(new BufferElement() { name = name, type = type, size = size, count = count, normalized = normalized });
            this._size += size * count;
        }
        #endregion
    }
}