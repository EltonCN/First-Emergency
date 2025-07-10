using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{ 
    [AddComponentMenu("My Unity Scripts/Scriptable Variables/Setters/Set Game Object Variable")]
    public class SetGameObjectVariable : SetVariable<GameObjectVariable, GameObject>
    {
    }
}