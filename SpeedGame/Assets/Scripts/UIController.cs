using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private WrittingEffectText _globalMessage;
    [SerializeField] private float _textSpeed;
    [SerializeField] private string _text;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            WriteText(_text);
        }
    }

    public void WriteText(string text)
    {
        _text = text;
        _globalMessage.StartTyping(text,_textSpeed);
    }
}