using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
public class PatientSheet : MonoBehaviour
{
    public UnityEvent callback;
    Button button;

    public void invoke(ClickEvent evt)
    {
        callback.Invoke();
    }

    void OnEnable()
    {
        UIDocument document = GetComponent<UIDocument>();

        button = document.rootVisualElement.Query<Button>().AtIndex(0);

        button.RegisterCallback<ClickEvent>(invoke);
    }

    void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(invoke);
    }
}
