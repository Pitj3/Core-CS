using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using CoreEngine.Engine.Components;

namespace CoreEngine.Engine.Utils
{
    public static class ComponentUtils
    {
        public static FieldInfo[] GetFields(CoreComponent comp)
        {
            List<FieldInfo> returnFields = new List<FieldInfo>();

            System.Reflection.FieldInfo[] fields = comp.GetType().GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                bool ignoreField = false;
                var attributes = field.GetCustomAttributes(true);
                foreach (Attribute at in attributes)
                {
                    if (at is IgnoreInspectorAttribute)
                    {
                        ignoreField = true;
                        break;
                    }
                }
                if (!ignoreField)
                {
                    returnFields.Add(field);
                }
                else
                {
                    continue;
                }
            }

            return returnFields.ToArray();
        }

        public static PropertyInfo[] GetProperties(CoreComponent comp)
        {
            List<PropertyInfo> returnProps = new List<PropertyInfo>();

            System.Reflection.PropertyInfo[] properties = comp.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                bool ignoreProp = false;
                var attributes = prop.GetCustomAttributes(true);
                foreach (Attribute at in attributes)
                {
                    if (at is IgnoreInspectorAttribute)
                    {
                        ignoreProp = true;
                        break;
                    }
                }
                if (!ignoreProp)
                {
                    returnProps.Add(prop);
                }
                else
                {
                    continue;
                }
            }

            return returnProps.ToArray();
        }

        public static string GetName(PropertyInfo prop)
        {
            string[] arr = prop.Name.Split('.');
            return arr[arr.Length-1];
        }
        
        public static string GetName(FieldInfo field)
        {
            string[] arr = field.Name.Split('.');
            return arr[arr.Length - 1];
        }

        public static object GetValue(CoreComponent comp, PropertyInfo prop)
        {
            return prop.GetValue(comp);
        }

        public static object GetValue(CoreComponent comp, FieldInfo field)
        {
            return field.GetValue(comp);
        }
    }
}
