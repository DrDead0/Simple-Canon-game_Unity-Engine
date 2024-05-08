using UnityEngine;

public class thrower : MonoBehaviour
{
    private Rigidbody rb;
    private bool gravityActivated = false;

    void Start()
    {
        // Get the Rigidbody component attached to the sphere
        rb = GetComponent<Rigidbody>();

        // Disable gravity initially
        rb.useGravity = false;
    }

    void Update()
    {
        // Check if the space bar is pressed and gravity is not already activated
        if (Input.GetKeyDown(KeyCode.Space) && !gravityActivated)
        {
            // Activate gravity
            rb.useGravity = true;
            gravityActivated = true;
        }
    }
}
