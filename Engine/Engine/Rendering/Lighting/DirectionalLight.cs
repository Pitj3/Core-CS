// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using CoreEngine.Engine.Components;

namespace CoreEngine.Engine.Rendering.Lighting
{
    /// <summary>
    /// Directional Light
    /// </summary>
    public class DirectionalLight : CoreComponent, Light
    {
        public DirectionalLight() : base()
        {
            CastShadows = false;
            Intensity = 1.0f;
        }

        public bool CastShadows
        {
            get; set;
        }

        public float Intensity
        {
            get; set;
        }
    }
}
