using System;
using UnityEngine;

namespace MyUnityScripts
{
    [Serializable]
    public class Optional<T>
    {
        [SerializeField] public bool enabled = false;
        [SerializeField] public T value;

        public static implicit operator T(Optional<T> optional)
        {
            return optional.value;
        }
    }
}