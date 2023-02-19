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

    [SerializeField] private TextMeshProUGUI textComponent;

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
                textComponent.gameObject.transform.parent.gameObject.SetActive(false);
                StopAllCoroutines();
            }
        }
    }

    public void StartTyping(string text, float speed)
    {
        if (!isTyping)
        {
            textComponent.gameObject.transform.parent.gameObject.SetActive(true);
            typingSpeed = speed;
            fullText = text;
            currentText = "";
            isTyping = true;
            StartCoroutine(TypeText());
        }
    }

    private IEnumerator TypeText()
    {
        foreach (var t in fullText)
        {
            currentText += t;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        yield return new WaitForSeconds(3);
        typingSpeed = normalTypingSpeed;
        textComponent.gameObject.transform.parent.gameObject.SetActive(false);
    }
}