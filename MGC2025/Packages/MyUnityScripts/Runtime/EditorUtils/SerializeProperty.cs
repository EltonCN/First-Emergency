//https://forum.unity.com/threads/serialize-c-properties-how-to-with-code.506027/
//Modified to suport one level serialized struct
using System;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MyUnityScripts
{
    /// <summary>
    /// Marks the field to use a property when editing in Inspector.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class SerializeProperty : PropertyAttribute
    {
        /// <summary>
        /// Name of the corresponding property
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// SerializeProperty constructor
        /// </summary>
        /// <param name="propertyName">Name of the corresponding property.</param>
        public SerializeProperty(string propertyName)
        {
            PropertyName = propertyName;
        }
    }

}