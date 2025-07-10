using System.IO;
using UnityEngine;
using UnityEditor;


namespace MyUnityScripts.JSON
{
    /// <summary>
    /// Converts JSON to ScriptableObjects
    /// </summary>
    public class FromJSONMenu
    {
        /// <summary>
        /// Creates an ScriptableObject from TextAsset.
        /// </summary>
        [MenuItem("Assets/Create/My Unity Scripts/JSON/Scriptable Object from JSON", false, 0)]
        static void SOFromTextAsset()
        {
            foreach(UnityEngine.Object obj in Selection.objects)
            {
                TextAsset text = (TextAsset) obj;
                string json = text.ToString();

                ScriptableObject so = FromJSON.SOFromJSON(json);

                string path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID())); 
                path += "/"+text.name+".asset";

                AssetDatabase.CreateAsset(so, path);
            }
            
            AssetDatabase.SaveAssets();
        }
            
        /// <summary>
        /// Validates if the select file is a TextAsset to convert to ScriptableObject.
        /// </summary>
        /// <returns>True if the activeObject is a TextAsset.</returns>
        [MenuItem("Assets/Create/My Unity Scripts/JSON/Scriptable Object from JSON", true)]
        static bool SOFromTextAssetValidator()
        {
            foreach(UnityEngine.Object obj in Selection.objects)
            {
                TextAsset test = Selection.activeObject as TextAsset;
                if(test == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}