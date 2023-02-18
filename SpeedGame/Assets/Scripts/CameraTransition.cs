using UnityEngine;

public class SmoothCameraTarget : MonoBehaviour
{
    public Transform newTarget; // The new camera target

    public float transitionTime = 1.0f; // The time it takes for the transition to complete

    private Transform currentTarget; // The camera's current target
    private float transitionTimer; // The current progress of the transition

    void Start()
    {
        currentTarget = Camera.main.transform.parent; // Get the camera's current target
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start the transition when the user presses the space bar
            transitionTimer = 0.0f;
        }

        if (transitionTimer < transitionTime)
        { 
            Vector3 newPos = Vector3.Lerp(currentTarget.position, newTarget.position, transitionTimer / transitionTime);
            Camera.main.transform.parent.position = newPos;
            transitionTimer += Time.deltaTime;
        }
        else
        {
            currentTarget = newTarget;
        }
    }
}
