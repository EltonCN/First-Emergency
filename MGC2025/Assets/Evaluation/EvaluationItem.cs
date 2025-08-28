using UnityEngine;

[CreateAssetMenu(fileName = "EvaluationItem", menuName = "Medical Simulator/Evaluation Item")]
public class EvaluationItem : ScriptableObject
{
    public string description;
    public float score;
}
