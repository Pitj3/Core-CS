// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

namespace CoreEngine.Engine.Rendering.Lighting
{
    /// <summary>
    /// Light interface
    /// </summary>
    public interface Light
    {
        bool CastShadows { get; set; }
        float Intensity { get; set; }
    }
}
