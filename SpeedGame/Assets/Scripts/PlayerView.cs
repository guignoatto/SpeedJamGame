using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private List<Color> _playerColors;
    [SerializeField] private List<Color> _activeDisabledColors;
    [SerializeField] private List<Image> _spriteSelector;
    private Animator _arrowAnimator;
    private SpriteRenderer _arrowSprite;

    public void Initialize()
    {
        _arrowAnimator = _arrow.GetComponent<Animator>();
        _arrowSprite = _arrow.GetComponent<SpriteRenderer>();
    }

    public void SetUpArrow(int activePlayer)
    {
        _arrowAnimator.SetTrigger("onClick");
        _arrowSprite.color = _playerColors[activePlayer];
    }

    public void ChangeSelectedSprite(int activePlayer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == activePlayer)
                _spriteSelector[i].color = _activeDisabledColors[0];
            else
                _spriteSelector[i].color = _activeDisabledColors[1];

        }
    }
}
