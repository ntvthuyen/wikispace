using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key: MonoBehaviour
{
    public InputField inputField;
    public char _char;
    public Button btn;
    void Start()
    {
        btn.onClick.AddListener(OnKeyPress);
    }
    void OnKeyPress() {
        inputField.text = inputField.text + _char;
    }
}
