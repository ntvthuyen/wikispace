using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearKey : MonoBehaviour
{
    public InputField inputField;
    public Button btn;
    void Start()
    {
        btn.onClick.AddListener(OnKeyPress);
    }
    void OnKeyPress()
    {
        inputField.text = "";
    }
}
