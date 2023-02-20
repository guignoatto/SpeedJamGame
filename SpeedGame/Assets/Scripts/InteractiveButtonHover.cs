using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButtonHover : MonoBehaviour
{
    public Action OnObjectInteraction;
    public Action OnCantInteract;

    [SerializeField] private int _whoCanInteract;
    [SerializeField] private Animator _objectDoor;
    [SerializeField] private float _taskTime;
    [SerializeField] private IObjectType _objectType;
    private BoxCollider2D _collider2D;
    private PlayerMovement _player;
    private bool _startTimer = false;
    private float _timer = 0;
    private List<int> _playersInside = new List<int>();
    private InteractiveButtonView _interactiveButtonView;
    public AK.Wwise.Event LockPickSound;

    private void Start()
    {
        _interactiveButtonView = GetComponent<InteractiveButtonView>();
        

    }

    private void Update()
    {
        if (_startTimer)
        {
            _timer += Time.deltaTime;
            if (_timer >= _taskTime)
            {
                switch (_objectType)
                {
                    case IObjectType.CHEST:
                        _objectDoor.GetComponent<Animator>().SetTrigger("OnOpenDoor");
                        break;
                }
                _interactiveButtonView.RefreshProgressBar(_timer,_taskTime);
                StartCoroutine(OpenDoorDelay());
            }
            _interactiveButtonView.RefreshProgressBar(_timer,_taskTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MyNumber myNumber))
        {
            if (_whoCanInteract == myNumber.myNumber || _whoCanInteract == 5)
            {
                _playersInside.Add(myNumber.myNumber);
                _interactiveButtonView.ToggleProgressBarEnabled(true);
                _startTimer = true;
                switch (_objectType)
                {
                    case IObjectType.CHEST:
                        if (myNumber.myNumber == 3)
                        {
                            //som rápido
                        }
                        else
                            LockPickSound.Post(gameObject);
                        break;
                    case IObjectType.WARDROBE:
                        if (myNumber.myNumber == 3)
                        {
                            //som rápido
                        }
                        else
                        {
                            //outro som
                        }
                        break;
                    case IObjectType.BOOKSHELF:
                        if (myNumber.myNumber == 3)
                        {
                            //som rápido
                        }
                        else
                        {
                            //outro som
                        }
                        break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out MyNumber myNumber))
        {
            if (_whoCanInteract == myNumber.myNumber || _whoCanInteract == 5)
            {
                _playersInside.Remove(myNumber.myNumber);
                _interactiveButtonView.ToggleProgressBarEnabled(false);
                _interactiveButtonView.RefreshProgressBar(0,0,true);
                _timer = 0;
                _startTimer = false;
                switch (_objectType)
                {
                    case IObjectType.CHEST:
                        if (myNumber.myNumber == 3)
                        {
                            //som rápido
                        }
                        else
                            LockPickSound.Stop(gameObject);
                        break;
                    case IObjectType.WARDROBE:
                        if (myNumber.myNumber == 3)
                        {
                            //som rápido
                        }
                        else
                        {
                            //outro som
                        }
                        break;
                    case IObjectType.BOOKSHELF:
                        if (myNumber.myNumber == 3)
                        {
                            //som rápido
                        }
                        else
                        {
                            //outro som
                        }
                        break;
                }

                
            }
        }
    }

    private IEnumerator OpenDoorDelay()
    {
        yield return new WaitForSeconds(.3f);
        _interactiveButtonView.ToggleProgressBarEnabled(false);
        GetComponent<BoxCollider2D>().enabled = false;
        _startTimer = false;
        _timer = 0;
    }
}
