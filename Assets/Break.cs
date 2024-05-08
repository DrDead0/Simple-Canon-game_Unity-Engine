using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    [SerializeField] private bool _broken = true;

    void OnCollisionEnter(Collision collision)
    {
        if (!_broken && collision.relativeVelocity.magnitude >= _breakForce)
        {
            _broken = false; // Set broken to true upon collision and only if it's not already true
            var replacement = Instantiate(_replacement, transform.position, transform.rotation);

            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier, collision.contacts[0].point, 2);
            }

            Destroy(gameObject);
        }
    }
}
