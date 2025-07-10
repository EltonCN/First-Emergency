using UnityEditor;
using UnityEngine;

namespace MyUnityScripts.JSON
{
    public class FromJSONWizard : ScriptableWizard
    {
        public string[] filePaths;    
        
        [MenuItem("Tools/My Unity Scripts/Scriptable objects from JSONs")]
        static void CreateWizard()
        {
            DisplayWizard<FromJSONWizard>("Scriptable objects from JSONs", "Create", "Paste paths");
        }

        void OnWizardUpdate()
        {
            if(filePaths == null || filePaths.Length == 0)
            {
                //isValid = false;
            }


        } 

        void OnWizardOtherButton()
        {
            string raw = GUIUtility.systemCopyBuffer;

            string[] paths = raw.Split("\n");

            for(int i = 0; i<paths.Length; i++)
            {
                paths[i] = paths[i].Trim('\"', '\'', ' ', (char) 13);
            }

            filePaths = paths;
        }

        void OnWizardCreate()
        {
            if(filePaths == null || filePaths.Length == 0)
            {
                return;
            }
            ScriptableObject[] sos = FromJSON.SOFromFilePath(filePaths);
            EditorUtils.saveSO(sos, EditorUtils.getActiveFolderPath());
        }
    }
}