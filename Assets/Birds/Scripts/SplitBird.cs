using UnityEngine;

public class SplitBird : Bird
{
    [SerializeField] private GameObject miniBirdPrefab;
    [SerializeField] private float splitAngle = 20f;
    [SerializeField] private float speedMultiplier = 1.2f;

    private bool activated = false;

    public override void Activate()
    {
        if (activated) return;
        if (rigidbody == null || miniBirdPrefab == null) return;

        Vector3 currentVelocity = rigidbody.linearVelocity;

        Vector3[] directions = new Vector3[]
        {
            currentVelocity,
            Quaternion.Euler(0, 0, splitAngle) * currentVelocity,
            Quaternion.Euler(0, 0, -splitAngle) * currentVelocity
        };

        foreach (Vector3 dir in directions)
        {
            GameObject mini = Instantiate(miniBirdPrefab, transform.position, transform.rotation);
            Rigidbody miniRb = mini.GetComponent<Rigidbody>();
            if (miniRb != null)
            {
                miniRb.linearVelocity = dir.normalized * currentVelocity.magnitude * speedMultiplier;
            }
        }

        activated = true;
        Destroy(gameObject);
    }
}
