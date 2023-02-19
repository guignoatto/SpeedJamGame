using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButtonHover : MonoBehaviour
{
    public Action OnObjectInteraction;
    public Action OnCantInteract;

    [SerializeField] private int _whoCanInteract;
    [SerializeField] private GameObject _objectDoor;
    private BoxCollider2D _collider2D;
    private PlayerMovement _player;
    private bool _canInteract = false;
    private List<int> _playersInside = new List<int>();
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MyNumber myNumber))
        {
            if (_whoCanInteract == myNumber.myNumber)
            {
                _playersInside.Add(myNumber.myNumber);
                _canInteract = true;
                _objectDoor.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MyNumber myNumber))
        {
            if (_whoCanInteract == myNumber.myNumber)
            {
                _playersInside.Remove(myNumber.myNumber);
                _canInteract = false;
                _objectDoor.SetActive(true);
            }
        }
    }
}
