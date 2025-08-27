using UnityEngine;
using MyUnityScripts.ScriptableVariables;
using TMPro;


public class ECGController : MonoBehaviour
{
    public FloatVariable heartRate;
    public TMP_Text text;

    public Renderer screen;


    void OnEnable()
    {
        UpdateHeartRate(heartRate.Value);

        heartRate.ValueChange.AddListener(UpdateHeartRate);
    }

    void OnDisable()
    {
        heartRate.ValueChange.RemoveListener(UpdateHeartRate);
    }

    public void UpdateHeartRate(float value)
    {
        text.text = $"{value}";

        screen.material.SetFloat("_heartRate", value);
    }
}
