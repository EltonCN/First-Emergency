using UnityEngine;

namespace MyUnityScripts.JSON
{
    /// <summary>
    /// Converts ScriptableObjects to JSON
    /// </summary>
    public class ToJSON
    {
        /// <summary>
        /// Converts an ScriptableObject to JSON string.
        /// </summary>
        /// <param name="so">ScriptableObject to convert</param>
        /// <returns>Generated JSON string.</returns>
        public static string SOToJSON(ScriptableObject so)
        {
            string json = JsonUtility.ToJson(so, true);

            string type_string = ",\n    \"type\": \"" + so.GetType().FullName + "\"";

            json = json.Insert(json.Length - 2, type_string);

            return json;
        }
    }
}