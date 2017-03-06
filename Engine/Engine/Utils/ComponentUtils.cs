// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Collections.Generic;
using System.Reflection;

using CoreEngine.Engine.Components;

namespace CoreEngine.Engine.Utils
{
    /// <summary>
    /// Component utilities
    /// </summary>
    public static class ComponentUtils
    {
        #region Public API
        /// <summary>
        /// Returns all the fields in the given component
        /// </summary>
        /// <param name="comp"></param>
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
                    if (at is IgnoreInSaveAttribute)
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

        /// <summary>
        /// Returns all the properties in the given component
        /// </summary>
        /// <param name="comp"></param>
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
                    if (at is IgnoreInSaveAttribute)
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

        /// <summary>
        /// Returns the name of the property
        /// </summary>
        /// <param name="prop"></param>
        public static string GetName(PropertyInfo prop)
        {
            string[] arr = prop.Name.Split('.');
            return arr[arr.Length-1];
        }
        
        /// <summary>
        /// Returns the name of the field
        /// </summary>
        /// <param name="field"></param>
        public static string GetName(FieldInfo field)
        {
            string[] arr = field.Name.Split('.');
            return arr[arr.Length - 1];
        }

        /// <summary>
        /// Returns the value of the property inside the given component
        /// </summary>
        /// <param name="comp"></param>
        /// <param name="prop"></param>
        public static object GetValue(CoreComponent comp, PropertyInfo prop)
        {
            return prop.GetValue(comp);
        }

        /// <summary>
        /// Return the value of the field inside the given component
        /// </summary>
        /// <param name="comp"></param>
        /// <param name="field"></param>
        public static object GetValue(CoreComponent comp, FieldInfo field)
        {
            return field.GetValue(comp);
        }

        #endregion
    }
}
