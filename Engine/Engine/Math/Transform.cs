using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

using System.ComponentModel;
using CoreEngine.Engine.Utils;

namespace CoreEngine.Engine.Math
{
    public class Transform
    { 
        public Vector3 position { get; set; }
        public Vector3 scale { get; set; }
        public Quaternion rotation;
        public Vector3 eulerRotation
        {
            get
            {
                return _rotationEuler;
            }
            set
            {
                _rotationEuler = value;
                rotation = Quaternion.FromEulerAngles(value);
            }
        }

        private Vector3 _rotationEuler;
    }
}
