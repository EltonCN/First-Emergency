using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    /// <summary>
    /// Scriptable object variable that stores game object values.
    /// </summary>
    [CreateAssetMenu(menuName = "My Unity Scripts/Scriptable Variables/Game Object Variable")]
    public class GameObjectVariable : ScriptableVariable<GameObject>
    {
    }
}