using UnityEngine;
using UnityEngine.UIElements;

public class EvaluationForm : MonoBehaviour
{
    int totalScore = 0;

    VisualElement createItem(string description, int score)
    {
        VisualElement ve = new();
        ve.style.flexDirection = FlexDirection.RowReverse;

        ve.Add(new Label(score.ToString()));
        ve.Add(new Label(description));

        totalScore += score;

        return ve;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument document = GetComponent<UIDocument>();

        ListView listView = document.rootVisualElement.Query<ListView>().AtIndex(0);

        listView.Add(createItem("Test", 22));

        document.rootVisualElement.Query<Label>("score").AtIndex(0).text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
