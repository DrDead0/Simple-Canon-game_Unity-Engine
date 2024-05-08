using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3f;
    public float impactForceMagnitude = 10f; // Define impact force magnitude here
    public float explosionLifetime; // Lifetime to pass to the explosion script

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is a target object based on its tag
        if (collision.gameObject.CompareTag("Target"))
        {
            Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (targetRigidbody != null)
            {
                // Apply a force to the target object in the direction of the projectile's velocity
                Vector3 impactForce = GetComponent<Rigidbody>().velocity.normalized * impactForceMagnitude;
                targetRigidbody.AddForce(impactForce, ForceMode.Impulse);
            }
        }

        // Pass lifetime to explosion script
        var explosion = GetComponent<Explosion>();
        if (explosion != null)
        {
            explosion.explosionLifetime = explosionLifetime;
        }
    }
}