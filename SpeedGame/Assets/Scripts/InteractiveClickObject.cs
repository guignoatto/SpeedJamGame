using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveClickObject : MonoBehaviour
{
    public Action OnObjectInteraction;
    public Action OnCantInteract;

    [SerializeField] private int _whoCanInteract;
    private BoxCollider2D _collider2D;
    private PlayerMovement _player;
    private bool _canInteract = false;
    private List<int> _playersInside = new List<int>();

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }

    private void OnMouseDown()
    {
        if (_canInteract)
        {
            if (_player.ActiveAgent == _whoCanInteract)
            {
                OnObjectInteraction?.Invoke();
                Debug.Log("Interacted");
            }
            else if (_playersInside.Contains(_player.ActiveAgent))
            {
                OnCantInteract?.Invoke();
                Debug.Log("Can't Interact");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MyNumber myNumber))
        {
            _playersInside.Add(myNumber.myNumber);
            _canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MyNumber myNumber))
        {
            _playersInside.Remove(myNumber.myNumber);
            _canInteract = false;
        }
    }
}