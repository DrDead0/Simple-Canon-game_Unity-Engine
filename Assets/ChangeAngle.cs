using UnityEngine;

public class ChangeAngle : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the rotation speed as needed

    void Update()
    {
        // Check for input to rotate the cylinder
        float rotationInput = Input.GetAxis("Horizontal"); // Get input from horizontal axis (left and right arrow keys)
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

        // Rotate the cylinder around its Z-axis
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
