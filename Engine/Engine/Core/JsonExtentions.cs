// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using System;

using OpenTK;

using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Resources;

namespace CoreEngine.Engine.Core
{
    #region Converter Extensions
    /// <summary>
    /// Vector converter
    /// </summary>
    public class VectorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector2) ||
                objectType == typeof(Vector3) ||
                objectType == typeof(Vector4);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            if(objectType == typeof(Vector2))
                return new Vector2(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault());
            if(objectType == typeof(Vector3))
                return new Vector3(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault(), ((float?)temp["Z"]).GetValueOrDefault());
            if(objectType == typeof(Vector4))
                return new Vector4(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault(), ((float?)temp["Z"]).GetValueOrDefault(), ((float?)temp["W"]).GetValueOrDefault());

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(Vector2))
            {
                Vector2 vec = (Vector2)value;
                serializer.Serialize(writer, new { X = vec.X, Y = vec.Y });
            }
            if (value.GetType() == typeof(Vector3))
            {
                Vector3 vec = (Vector3)value;
                serializer.Serialize(writer, new { X = vec.X, Y = vec.Y, Z = vec.Z });
            }
            if (value.GetType() == typeof(Vector4))
            {
                Vector4 vec = (Vector4)value;
                serializer.Serialize(writer, new { X = vec.X, Y = vec.Y, Z = vec.Z, W = vec.W });
            }
        }
    }

    /// <summary>
    /// Quaternion converter
    /// </summary>
    public class QuaternionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Quaternion);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Quaternion(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault(), ((float?)temp["Z"]).GetValueOrDefault(), ((float?)temp["W"]).GetValueOrDefault());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Quaternion quat = (Quaternion)value;
            serializer.Serialize(writer, new { X = quat.X, Y = quat.Y, Z = quat.Z, W = quat.W });
        }
    }

    public class Matrix4Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Matrix4);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Matrix4(((float?)temp["M11"]).GetValueOrDefault(), ((float?)temp["M12"]).GetValueOrDefault(), ((float?)temp["M13"]).GetValueOrDefault(), ((float?)temp["M14"]).GetValueOrDefault(),
                ((float?)temp["M21"]).GetValueOrDefault(), ((float?)temp["M22"]).GetValueOrDefault(), ((float?)temp["M23"]).GetValueOrDefault(), ((float?)temp["M24"]).GetValueOrDefault(),
                ((float?)temp["M31"]).GetValueOrDefault(), ((float?)temp["M32"]).GetValueOrDefault(), ((float?)temp["M33"]).GetValueOrDefault(), ((float?)temp["M34"]).GetValueOrDefault(),
                ((float?)temp["M41"]).GetValueOrDefault(), ((float?)temp["M42"]).GetValueOrDefault(), ((float?)temp["M43"]).GetValueOrDefault(), ((float?)temp["M44"]).GetValueOrDefault());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Matrix4 quat = (Matrix4)value;
            serializer.Serialize(writer, new
            {
                M11 = quat.M11,
                M12 = quat.M12,
                M13 = quat.M13,
                M14 = quat.M14,
                M21 = quat.M21,
                M22 = quat.M22,
                M23 = quat.M23,
                M24 = quat.M24,
                M31 = quat.M31,
                M32 = quat.M32,
                M33 = quat.M33,
                M34 = quat.M34,
                M41 = quat.M41,
                M42 = quat.M42,
                M43 = quat.M43,
                M44 = quat.M44,
            });
        }
    }

    public class MeshConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Mesh);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);

            MeshVertex[] vertices = temp["vertices"].ToObject<MeshVertex[]>(serializer);
            ushort[] indices = temp["indices"].ToObject<ushort[]>(serializer);

            return new Mesh(vertices, indices);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Mesh mesh = (Mesh)value;
            serializer.Serialize(writer, new
            {
                vertices = mesh.vertices,
                indices = mesh.indices
            });
        }
    }

    public class ShaderConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Shader);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Shader(temp["path"].ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Shader shader = (Shader)value;
            serializer.Serialize(writer, new
            {
                path = shader.path
            });
        }
    }

    public class Texture2DConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Texture2D);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Texture2D(temp["path"].ToString()); // TODO: Load other texture data
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Texture2D texture = (Texture2D)value;
            serializer.Serialize(writer, new
            {
                path = texture.path // TODO: Write other texture data
            });
        }
    }

    public class MaterialConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Material);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            Material mat = new Material(new Shader(temp["shader"]["path"].ToString()));
            mat.diffuseTexture = new Texture2D(temp["diffuseTexture"]["path"].ToString());

            return mat;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Material mat = (Material)value;
            serializer.Serialize(writer, new
            {
                shader = mat.shader,
                diffuseTexture = mat.diffuseTexture
            });
        }
    }
    #endregion
}
