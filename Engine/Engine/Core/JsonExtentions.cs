// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using System;

using OpenTK;

namespace CoreEngine.Engine.Core
{
    #region Converter Extensions
    /// <summary>
    /// Vector2 converter
    /// </summary>
    public class Vector2Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector2);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Vector2(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vector2 vec = (Vector2)value;
            serializer.Serialize(writer, new { X = vec.X, Y = vec.Y });
        }
    }

    /// <summary>
    /// Vector3 converter
    /// </summary>
    public class Vector3Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector3);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Vector3(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault(), ((float?)temp["Z"]).GetValueOrDefault());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vector3 vec = (Vector3)value;
            serializer.Serialize(writer, new { X = vec.X, Y = vec.Y, Z = vec.Z });
        }
    }

    /// <summary>
    /// Vector4 converter
    /// </summary>
    public class Vector4Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector4);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject temp = JObject.Load(reader);
            return new Vector4(((float?)temp["X"]).GetValueOrDefault(), ((float?)temp["Y"]).GetValueOrDefault(), ((float?)temp["Z"]).GetValueOrDefault(), ((float?)temp["W"]).GetValueOrDefault());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vector4 vec = (Vector4)value;
            serializer.Serialize(writer, new { X = vec.X, Y = vec.Y, Z = vec.Z, W = vec.W });
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
    #endregion
}
