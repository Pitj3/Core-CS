// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using CoreEngine.Engine.Logging;

namespace CoreEngine.Engine.Resources
{
    /// <summary>
    /// Main Shader class
    /// </summary>
    public class Shader : Resource
    {
        #region Data
        private uint _program;

        public string vsSource = "";
        public string fsSource = "";

        public string path = "";
        #endregion

        #region Constructors
        public Shader(string filepath)
        {
            path = filepath;
            Debug.Assert(Load(filepath));
        }
        #endregion

        #region Public API
        /// <summary>
        /// Loads the shader resource
        /// </summary>
        /// <param name="source">Filepath (without extension)</param>
        public override bool Load(string source)
        {
            if (!File.Exists(source + ".vs"))
            {
                Logger.Log(LogLevel.ERROR, "Shader not found at location: " + source);
            }
            else
            {
                using (StreamReader sr = File.OpenText(source + ".vs"))
                {
                    vsSource = sr.ReadToEnd();
                }
            }
            if (!File.Exists(source + ".fs"))
            {
                Logger.Log(LogLevel.ERROR, "Shader not found at location: " + source);
            }
            else
            {
                using (StreamReader sr = File.OpenText(source + ".fs"))
                {
                    fsSource = sr.ReadToEnd();
                }
            }

            uint vertShader = (uint)GL.CreateShader(ShaderType.VertexShader);
            uint fragShader = (uint)GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource((int)vertShader, vsSource);
            GL.CompileShader(vertShader);

            int vertLogLength = 0;
            StringBuilder outVertLog = new StringBuilder();
            GL.GetShaderInfoLog(vertShader, 1024, out vertLogLength, outVertLog);
            if (vertLogLength > 1) Logger.Log(LogLevel.ERROR, outVertLog.ToString());

            GL.ShaderSource((int)fragShader, fsSource);
            GL.CompileShader(fragShader);

            int fragLogLength = 0;
            StringBuilder outFragLog = new StringBuilder();
            GL.GetShaderInfoLog(vertShader, 1024, out fragLogLength, outFragLog);
            if (vertLogLength > 1) Logger.Log(LogLevel.ERROR, outFragLog.ToString());

            _program = (uint)GL.CreateProgram();
            GL.AttachShader(_program, vertShader);
            GL.AttachShader(_program, fragShader);
            GL.LinkProgram(_program);

            int programLogLength = 0;
            StringBuilder programLog = new StringBuilder();
            GL.GetProgramInfoLog(_program, 1024, out programLogLength, programLog);
            if (programLogLength > 1) Logger.Log(LogLevel.ERROR, programLog.ToString());

            GL.DeleteShader(vertShader);
            GL.DeleteShader(fragShader);

            return true;
        }

        /// <summary>
        /// Binds the shader
        /// </summary>
        public void Bind()
        {
            GL.UseProgram(_program);
        }

        /// <summary>
        ///  Unbinds the shader
        /// </summary>
        public void Unbind()
        {
            GL.UseProgram(0);
        }

        /// <summary>
        /// Returns the location of the variable in the shader
        /// </summary>
        /// <param name="name">Name of the variable in the shader (case sensitive)</param>
        public int GetVariableLocation(string name)
        {
            return GL.GetUniformLocation(_program, name);
        }

        /// <summary>
        /// Returns the program handle
        /// </summary>
        public uint GetProgram()
        {
            return _program;
        }

        #endregion
    }
}
