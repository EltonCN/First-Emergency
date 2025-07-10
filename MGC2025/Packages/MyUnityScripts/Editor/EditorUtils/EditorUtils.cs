using UnityEngine;
using UnityEditor;
using System.IO;
using System.Reflection;

namespace MyUnityScripts
{
    public static class EditorUtils
    {
        public static void saveSO(ScriptableObject so, string dir="Assets")
        {
            
            string path = Path.Join(dir, so.name+".asset");
            AssetDatabase.CreateAsset(so, path);
            AssetDatabase.SaveAssets();
        }

        public static void saveSO(ScriptableObject[] sos, string dir="Assets")
        {
            foreach(ScriptableObject so in sos)
            {
                string path = Path.Join(dir, so.name+".asset");
                AssetDatabase.CreateAsset(so, path);
            }
            
            AssetDatabase.SaveAssets();
        }

        public static string getActiveFolderPath()
        {
            var _tryGetActiveFolderPath = typeof(ProjectWindowUtil).GetMethod( "TryGetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic );

            object[] args = new object[] { null };
            bool found = (bool)_tryGetActiveFolderPath.Invoke( null, args );
            string path = (string)args[0];

            if(found)
            {
                return path;
            }
            else
            {
                return "";
            }
        }
    }
}