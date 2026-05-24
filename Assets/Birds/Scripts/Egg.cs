using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionStrength;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float explosionDuration;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bird")
        {
            GameObject explosition = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in collidersInRange)
            {
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(explosionStrength, transform.position, explosionRadius);
                }
            }
            Destroy(explosition, explosionDuration);
            Destroy(gameObject);
        }
    }
}
