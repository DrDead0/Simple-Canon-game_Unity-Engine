using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    public float distance = 2.0f; // Distance to move up and down
    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on time
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * distance;

        // Apply the new position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
