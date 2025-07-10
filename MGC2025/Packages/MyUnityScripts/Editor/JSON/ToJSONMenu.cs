using System.IO;
using UnityEditor;
using UnityEngine;

namespace MyUnityScripts.JSON
{
    /// <summary>
    /// Converts ScriptableObjects to JSON
    /// </summary>
    public class ToJSONMenu
    {
        /// <summary>
        /// Creates an TextAsset with JSON from a ScriptableObject
        /// </summary>
        [MenuItem("Assets/Create/My Unity Scripts/JSON/JSON from Scriptable Object", false, 0)]
        static void SOToTextAsset()
        {
            foreach (UnityEngine.Object obj in Selection.objects)
            {
                ScriptableObject so = (ScriptableObject)obj;
                string json = ToJSON.SOToJSON(so);

                string path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID()));
                path += "/" + so.name + ".json";

                StreamWriter writer = new StreamWriter(path);
                writer.Write(json);
                writer.Close();
            }

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Validates if all the selected objects are ScriptableObjects for conversion.
        /// </summary>
        /// <returns>True  if if all the selected objects are ScriptableObjects.</returns>
        [MenuItem("Assets/Create/My Unity Scripts/JSON/JSON from Scriptable Object", true)]
        static bool SOToTextAssetValidator()
        {
            foreach (UnityEngine.Object obj in Selection.objects)
            {
                ScriptableObject test = Selection.activeObject as ScriptableObject;

                if (test == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}