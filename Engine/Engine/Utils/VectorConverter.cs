using System;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;

using OpenTK;


namespace CoreEngine.Engine.Utils
{
    public class VectorConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string)
            {
                string[] v = ((string)value).Split(',');
                if(v.Length == 2) // Vector2
                {
                    return new Vector2(float.Parse(v[0]), float.Parse(v[1]));
                }
                if (v.Length == 3) // Vector3
                {
                    return new Vector3(float.Parse(v[0]), float.Parse(v[1]), float.Parse(v[2]));
                }
                if (v.Length == 4) // Vector4
                {
                    return new Vector4(float.Parse(v[0]), float.Parse(v[1]), float.Parse(v[2]), float.Parse(v[3]));
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if(destinationType == typeof(string))
            {
                if(value is Vector2)
                {
                    Vector2 v = (Vector2)value;
                    return v.X + "," + v.Y;
                }

                if (value is Vector3)
                {
                    Vector3 v = (Vector3)value;
                    return v.X + "," + v.Y + "," + v.Z;
                }

                if (value is Vector4)
                {
                    Vector4 v = (Vector4)value;
                    return v.X + "," + v.Y + "," + v.Z + "," + v.W;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
