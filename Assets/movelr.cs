using UnityEngine;

public class movelr : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement
    public float distance = 2.0f; // Distance to move left and right
    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on time for left-right movement
        float newX = startPosition.x + Mathf.Sin(Time.time * speed) * distance;

        // Apply the new position
        transform.position = new Vector3(newX, startPosition.y, startPosition.z);
    }
}
