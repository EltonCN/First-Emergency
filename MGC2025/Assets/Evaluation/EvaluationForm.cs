using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EvaluationForm : MonoBehaviour
{
    public List<EvaluationItem> items = new();
    ListView listView;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument document = GetComponent<UIDocument>();

        listView = document.rootVisualElement.Query<ListView>().AtIndex(0);

        listView.bindItem = (element, index) =>
        {
            element.Query<Label>("item_score").AtIndex(0).text = items[index].score.ToString();
            element.Query<Label>("item_description").AtIndex(0).text = items[index].description;
        };

        listView.itemsSource = items;

        float totalScore = 0;
        foreach (EvaluationItem item in items)
        {
            totalScore += item.score;
        }

        document.rootVisualElement.Query<Label>("score").AtIndex(0).text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        listView.Rebuild();
    }
}
