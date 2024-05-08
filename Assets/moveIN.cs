using UnityEngine;

public class moveIN : MonoBehaviour
{
    public float speed = 2.0f; // Speed of movement in the Y-axis

    void Update()
    {
        // Calculate the new position based on user input for up-down movement
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Apply the new position
        transform.Translate(0f, movement, 0f);
    }
}
