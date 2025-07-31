using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;
using System.Collections.Generic;
using System.Linq;

namespace UNICAMP.MedicalSimulator.Editor
{
    [Graph(AssetExtension)]
    [Serializable]
    public class MedicalSimulatorGraph : Graph
    {
        public const string AssetExtension = "mgraph";

        [MenuItem("Assets/Create/Medical Simulator/Medical Graph", false)]
        static void CreateAssetFile()
        {
            GraphDatabase.PromptInProjectBrowserToCreateNewAsset<MedicalSimulatorGraph>();
        }

        public override void OnGraphChanged(GraphLogger infos)
        {
            base.OnGraphChanged(infos);

            CheckGraphErrors(infos);
        }

        void CheckGraphErrors(GraphLogger infos)
        {
            List<StartNode> startNodes = GetNodes().OfType<StartNode>().ToList();

            switch (startNodes.Count)
            {
                case 0:
                    infos.LogError("Add a StartNode in your Medical Simulator graph.", this);
                    break;
                case >= 1:
                    {
                        foreach (var startNode in startNodes.Skip(1))
                        {
                            infos.LogWarning($"Medical Simulator only supports one StartNode per graph. Only the first created one will be used.", startNode);
                        }
                        break;
                    }
            }
        }
    }
}
