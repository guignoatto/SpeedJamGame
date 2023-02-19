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
        }

        if (Input.GetKeyDown(KeyCode.Q)) ActiveAgent = 0;
        if (Input.GetKeyDown(KeyCode.W)) ActiveAgent = 1;
        if (Input.GetKeyDown(KeyCode.E)) ActiveAgent = 2;
        if (Input.GetKeyDown(KeyCode.R)) ActiveAgent = 3;
    }

    private void HandleMouseClick()
    {
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = _agents[ActiveAgent].transform.position.z;
        
        _targets[ActiveAgent].position = mousePosition;

        _agents[ActiveAgent].SetDestination(_targets[ActiveAgent].position);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
    }
}