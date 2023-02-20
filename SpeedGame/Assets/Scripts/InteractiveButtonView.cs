using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButtonView : MonoBehaviour
{
    [SerializeField] private Image _progressionBar;

    private void Start()
    {
        ToggleProgressBarEnabled(false);
    }

    public void RefreshProgressBar(float timer, float maxTime, bool setToZero = false)
    {
        if (setToZero) _progressionBar.fillAmount = 0;
        
        var fillAmount = timer / maxTime;
        if ((fillAmount <= 1 && fillAmount * 10 > _progressionBar.fillAmount * 10 + 2) || fillAmount >= 1)
            _progressionBar.fillAmount = fillAmount;
    }

    public void ToggleProgressBarEnabled(bool isEnabled)
    {
        _progressionBar.transform.parent.gameObject.SetActive(isEnabled);
    }
}
