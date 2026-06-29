using UnityEngine;

public class PullBird : Bird
{
    [SerializeField] private float pullRadius;
    [SerializeField] private float pullStrength;
    [SerializeField] private float pullDuration;

    public override void Activate()
    {
        StartCoroutine(Pull());
    }

    private System.Collections.IEnumerator Pull()
    {
        float timer = 0f;
        while (timer < pullDuration)
        {
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, pullRadius);
            foreach (Collider collider in collidersInRange)
            {
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    Vector3 direction = transform.position - collider.transform.position;
                    rigidbody.AddForce(direction.normalized * pullStrength);
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
