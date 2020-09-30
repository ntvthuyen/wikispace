using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSearchButtonClick : MonoBehaviour
{
    public InputField input;
    public List<Text> texts;
    public List<GameObject> button;
    public GameObject results_canvas;
    public Button yourButton;

    // Start is called before the first frame update
    public void OnSearchButtonPress() {
        string query = input.text;
        if (query != "")
        {
            results_canvas.SetActive(true);
            StartCoroutine(WikipediaApi.ShowResults(query, texts, button));
        }
    }
    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(OnSearchButtonPress);
    }
}
