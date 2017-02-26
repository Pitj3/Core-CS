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
    #endregion
}
