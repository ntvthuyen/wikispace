using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    static GameObject modelPool;
    static Dictionary<string, string> modelNameFromTitle;

    static GameObject currentModel;

    // Start is called before the first frame update
    void Start()
    {
        modelPool = GameObject.Find("ModelPool");

        modelNameFromTitle = new Dictionary<string, string>();
        modelNameFromTitle.Add("Church_(building)", "Church");
        modelNameFromTitle.Add("Tiger", "Tiger");
        modelNameFromTitle.Add("Cat", "Cat");
        modelNameFromTitle.Add("Rock_(geology)", "Stones");
        modelNameFromTitle.Add("Butterfly", "Butterfly");
        modelNameFromTitle.Add("Rabbit", "Rabbit");
        modelNameFromTitle.Add("Spider", "Spider");
    }
    // http://answers.unity.com/answers/890789/view.html
    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }

    public static void ShowModel(string title)
    {
        if (currentModel != null)
        {
            currentModel.SetActive(false);
        }
        currentModel = null;

        if (!modelNameFromTitle.ContainsKey(title))
        { 
            return;
        }
        string modelName = modelNameFromTitle[title];
        GameObject newModel = FindObject(modelPool, modelName);
        newModel.SetActive(true);
        currentModel = newModel;
    }
}
