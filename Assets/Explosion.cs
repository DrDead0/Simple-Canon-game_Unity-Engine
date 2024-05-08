using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private GameObject _particlesPrefab;
    private bool _hasExploded = false;
    public float explosionLifetime; // Lifetime received from Projectile script

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasExploded && collision.relativeVelocity.magnitude >= _triggerForce)
        {
            Explode();
        }
    }

    private void Explode()
    {
        _hasExploded = true;

        var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var obj in surroundingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;

            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1);
        }

        GameObject particles = Instantiate(_particlesPrefab, transform.position, Quaternion.identity);
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();

        // Destroy the particle prefab after its duration
        Destroy(particles, particleSystem.main.duration);

        Destroy(gameObject, explosionLifetime); // Destroy the explosion after the given lifetime
    }
}
