using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private List<Color> _playerColors;
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
}
