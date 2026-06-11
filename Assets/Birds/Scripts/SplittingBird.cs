using UnityEngine;

public class SplittingBird : Bird
{
    [SerializeField] private Bird smallBirdPrefab;
    [SerializeField] private int smallBirdCount = 5;

    [SerializeField] private float spreadStrength = 3f;
    [SerializeField] private float upwardBoost = 1f;
    [SerializeField] private float spawnDistance = 0.4f;

    private bool wasActivated = false;

    public override void Activate()
    {
        if (wasActivated)
        {
            return;
        }

        wasActivated = true;

        Vector3 mainVelocity = rigidbody.linearVelocity;

        if (mainVelocity.magnitude < 0.1f)
        {
            mainVelocity = transform.forward * activationSpeed;
        }

        Vector3 forwardDirection = mainVelocity.normalized;

        for (int i = 0; i < smallBirdCount; i++)
        {
            Vector3 spreadDirection = GetSpreadDirection(forwardDirection, i);

            Bird smallBird = Instantiate(
                smallBirdPrefab,
                transform.position + spreadDirection * spawnDistance,
                transform.rotation
            );

            smallBird.rigidbody.isKinematic = false;
            smallBird.rigidbody.linearVelocity =
                mainVelocity + spreadDirection * spreadStrength + Vector3.up * upwardBoost;
        }

        Destroy(gameObject);
    }

    private Vector3 GetSpreadDirection(Vector3 forwardDirection, int index)
    {
        float angleStep = 360f / smallBirdCount;
        float angle = angleStep * index;

        Vector3 sideDirection = Quaternion.AngleAxis(angle, Vector3.up) * forwardDirection;

        return sideDirection.normalized;
    }
}