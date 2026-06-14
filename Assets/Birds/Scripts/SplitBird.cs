using UnityEngine;

public class SplitBird : Bird
{
    [SerializeField] private int splitCount = 3;
    [SerializeField] private float spreadAngle = 30f;
    [SerializeField] private Bird splitPrefab;

    private bool hasActivated = false;

    public override void Activate()
    {
        if (hasActivated) return;
        hasActivated = true;

        Vector3 currentVelocity = rigidbody.linearVelocity;
        float speed = currentVelocity.magnitude;

        for (int i = 0; i < splitCount; i++)
        {
            float angle = -spreadAngle + (spreadAngle * 2f / (splitCount - 1)) * i;
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * currentVelocity.normalized;

            Bird fragment = Instantiate(splitPrefab, transform.position, transform.rotation);
            fragment.rigidbody.isKinematic = false;
            fragment.rigidbody.linearVelocity = direction * speed;
        }

        Destroy(gameObject);
    }
}
