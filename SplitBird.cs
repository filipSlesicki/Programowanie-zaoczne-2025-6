using UnityEngine;

public class SplitBird : Bird
{
    [SerializeField] private Bird splitPrefab;
    [SerializeField] private float spreadAngle = 20f;
    [SerializeField] private float spawnOffset = 0.6f;

    public override void Activate()
    {
        Spawn(-spreadAngle);
        Spawn(spreadAngle);
        Destroy(gameObject);
    }

    private void Spawn(float angle)
    {
        Vector3 velocity = Quaternion.AngleAxis(angle, Vector3.up) * rigidbody.linearVelocity;
        Bird spawned = Instantiate(splitPrefab, transform.position + velocity.normalized * spawnOffset, transform.rotation);
        spawned.rigidbody.linearVelocity = velocity;
    }
}