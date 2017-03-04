using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace CoreEngine.Engine.Utils
{
    public class ConverterLoader
    {
        public static void Load()
        {
            System.ComponentModel.TypeDescriptor.AddAttributes(typeof(Vector2), new System.ComponentModel.TypeConverterAttribute(typeof(VectorConverter)));
            System.ComponentModel.TypeDescriptor.AddAttributes(typeof(Vector3), new System.ComponentModel.TypeConverterAttribute(typeof(VectorConverter)));
            System.ComponentModel.TypeDescriptor.AddAttributes(typeof(Vector4), new System.ComponentModel.TypeConverterAttribute(typeof(VectorConverter)));
        }
    }
}
