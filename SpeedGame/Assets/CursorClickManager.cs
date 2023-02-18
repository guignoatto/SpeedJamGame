using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CursorClickManager : MonoBehaviour
{  
    [SerializeField] private Transform _target;
    [SerializeField] private Animator _arrowAnimator;
    [SerializeField] private GameObject _boxCollider2D;
    private Vector3 _click;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _click = Input.mousePosition;
            _click = Camera.main.ScreenToWorldPoint(_click);
            _click.z = 0;
            _target.position = _click;
            ClickArrowAnimation();
        }
        if (Input.GetMouseButtonDown(0))
        {
            _boxCollider2D.gameObject.SetActive(!_boxCollider2D.gameObject.activeSelf);
        }
    }

    private void ClickArrowAnimation()
    {
    }
}
