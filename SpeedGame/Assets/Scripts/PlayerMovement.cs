using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private List<NavMeshAgent> _agents;
    [SerializeField] private Transform _arrow;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private CameraSwitchSmooth _cameraSwitch;
    public bool paused = false;

    public int ActiveAgent = 0;

    private PlayerView _playerView;
    

    void Start()
    {
        Initialize();
    }

    private void Update()
    {
        InputsHandler();
    }

    private void Initialize()
    {
        _playerView = GetComponent<PlayerView>();
        _playerView.Initialize();
        foreach (var a in _agents)
        {
            a.updateRotation = false;
            a.updateUpAxis = false;
        }
    }

    private void InputsHandler()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HandleMouseClick();
            _playerView.SetUpArrow(ActiveAgent);
            _arrow.parent = _targets[ActiveAgent];
            _arrow.localPosition = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _boxCollider2D.gameObject.SetActive(!_boxCollider2D.gameObject.activeSelf);
            _playerView.ChangeSelectedSprite(ActiveAgent);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActiveAgent = 0;
            ChangePlayer();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ActiveAgent = 1;
            ChangePlayer();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ActiveAgent = 2;
            ChangePlayer();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ActiveAgent = 3;
            ChangePlayer();
        }
    }

    private void HandleMouseClick()
    {
        if (paused)
            return;
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = _agents[ActiveAgent].transform.position.z;
        
        _targets[ActiveAgent].position = mousePosition;

        _agents[ActiveAgent].SetDestination(_targets[ActiveAgent].position);

    }

    private void ChangePlayer()
    {
        if (paused)
            return;
        _cameraSwitch.GetNewTarget(_agents[ActiveAgent].gameObject.transform);
        _playerView.ChangeSelectedSprite(ActiveAgent);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
    }
}