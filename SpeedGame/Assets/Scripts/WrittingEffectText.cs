using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WrittingEffectText : MonoBehaviour
{
    public float typingSpeed = 0.1f;
    public string fullText;

    private float normalTypingSpeed;
    private string currentText = "";
    private bool isTyping = false;

    public AK.Wwise.Event DialogueSound;

    [SerializeField] private TextMeshProUGUI textComponent;
    private IEnumerator typeEnumerator; 

    private void Start()
    {
        normalTypingSpeed = typingSpeed;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
                typingSpeed /= 10;
            else
            {
                if (typeEnumerator!= null) StopCoroutine(typeEnumerator);
                isTyping = false;
                textComponent.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void StartTyping(string text, float speed)
    {
        if (!isTyping)
        {
            if (typeEnumerator != null) StopCoroutine(typeEnumerator);
            typeEnumerator = TypeText();
            StartCoroutine(typeEnumerator);
            textComponent.gameObject.transform.parent.gameObject.SetActive(true);
            typingSpeed = speed;
            fullText = text;
            currentText = "";
            isTyping = true;
        }
    }

    private IEnumerator TypeText()
    {
        foreach (var t in fullText)
        {
            currentText += t;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
            DialogueSound.Post(gameObject);
        }

        yield return new WaitForSeconds(3);
        isTyping = false;
        typingSpeed = normalTypingSpeed;
        textComponent.gameObject.transform.parent.gameObject.SetActive(false);
    }
}