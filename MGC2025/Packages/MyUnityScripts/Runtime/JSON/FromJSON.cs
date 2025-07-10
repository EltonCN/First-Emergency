using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;
//using SFB;

namespace MyUnityScripts.JSON
{
    /// <summary>
    /// Converts JSON to ScriptableObjects
    /// </summary>
    public class FromJSON
    {
        /// <summary>
        /// Creates an ScriptableObject from a JSON file path.
        /// </summary>
        /// <param name="path">JSON file path.</param>
        /// <returns>Created ScriptableObject</returns>
        public static ScriptableObject SOFromFilePath(string path)
        {
            StreamReader reader = new StreamReader(path);
            string json = reader.ReadToEnd();
            reader.Close();

            ScriptableObject so = SOFromJSON(json);
            so.name = Path.GetFileNameWithoutExtension(path);
            return so;
        }

        /// <summary>
        /// Creates multiples ScriptableObjects from JSON files paths.
        /// </summary>
        /// <param name="path">JSON files paths.</param>
        /// <returns>Created ScriptableObjects</returns>
        public static ScriptableObject[] SOFromFilePath(string[] paths)
        {
            ScriptableObject[] objects = new ScriptableObject[paths.Length];
            
            for(int i = 0; i<paths.Length; i++)
            {
                objects[i] = SOFromFilePath(paths[i]);
            }

            return objects;
        }

        /// <summary>
        /// Creates an ScriptableObject from a string with json.
        /// </summary>
        /// <param name="json">String with json object encoding.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the json data doesn't contains 'type' field.</exception>
        public static ScriptableObject SOFromJSON(string json)
        {
            JObject data = JObject.Parse(json);
            
            if(!data.ContainsKey("type"))
            {
                throw new ArgumentException("JSON must contain a 'type' field with Scriptable Object type.");
            }

            string typeName = data["type"].Value<string>();

            ScriptableObject obj = ScriptableObject.CreateInstance(typeName);

            //JsonConvert.PopulateObject(json, obj);
            JsonUtility.FromJsonOverwrite(json, obj);

            return obj;
        }

    }
}