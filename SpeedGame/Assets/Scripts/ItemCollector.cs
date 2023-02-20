using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private List<InteractiveButtonHover> _interactiveObjects;
    [SerializeField] private List<Image> _images;
    private int objectsFound = 0;
    private void Awake()
    {
        Random random = new Random();
        _interactiveObjects.Sort((a, b) => random.Next(-1, 2));
        foreach (var o in _interactiveObjects)
        {
            o.OnFindObject += AddToInterface;
        }
        for (int i = 0; i < 6; i++)
        {
            _interactiveObjects[i].hasItem = true;
        }
    }

    private void AddToInterface()
    {
        Color color = _images[objectsFound].color;
        color.a = 255;
        
        _images[objectsFound].color = color;
        objectsFound += 1;
    }
}
