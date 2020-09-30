using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackspaceKey : MonoBehaviour
{
    public InputField inputField;
    public Button btn;
    void Start()
    {
        btn.onClick.AddListener(OnKeyPress);
    }
    void OnKeyPress() {
        if (inputField.text.Length != 0)
        {
            inputField.text =inputField.text.Remove(inputField.text.Length - 1);
        }
    }
}
