using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using UnityEngine;

public class CameraSwitchSmooth : MonoBehaviour
{
    public Transform newTarget; // The new camera target
     
    public float transitionTime = 1.0f; // The time it takes for the transition to complete
     
    [SerializeField] private Transform currentTarget; // The camera's current target
    private float transitionTimer; // The current progress of the transition

    public void GetNewTarget(Transform target)
    {
        if (newTarget == target) return;
        newTarget = target;
        var pos = target.position;
        pos.z = 0;
        newTarget.position = pos;
        transitionTimer = 0.0f;
    }
    void Update()
    {
        if (transitionTimer < transitionTime)
        { 
            Vector3 newPos = Vector3.Lerp(currentTarget.position, newTarget.position, transitionTimer / transitionTime);
            newPos.z = transform.position.z;
            transform.position = newPos;
            transitionTimer += Time.deltaTime;
        }
        else
        {
            currentTarget = newTarget;
            var pos = currentTarget.position;
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }
}
