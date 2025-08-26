using UnityEngine;

[CreateAssetMenu(fileName = "PatientInfo", menuName = "Medical Simulator/Patient Info")]
public class PatientInfo : ScriptableObject
{
    public string patientName;
    public string sex;
    public string gender;

    [Range(0, 200)]
    public int age;

    [TextArea]
    public string history;

}
