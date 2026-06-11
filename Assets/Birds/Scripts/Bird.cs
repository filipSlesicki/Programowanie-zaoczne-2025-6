using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float activationSpeed = 10;
    [SerializeField] Bird birdPrefab;

    float timeToSplit = .7f;
    float timeElapsed = 0f;
    bool wasSplit = false;
    bool wasActivated = false;

    private void Update()
    {
        // Debug.Log("Update");
        if (!wasActivated) return;
        if (wasSplit) return;

        timeElapsed += Time.deltaTime; // Timer

        if (timeElapsed >= timeToSplit)
        {
            Spilt();

        }
    }

    public virtual void Activate()
    {

    }


    public void Shoot()
    {
        // Debug.Log("Shoot!");
        wasActivated = true;
    }

    private void Spilt()
    {
        var b1 = Instantiate(birdPrefab, transform.position, Quaternion.identity);
        var b2 = Instantiate(birdPrefab, transform.position, Quaternion.identity);
        var b3 = Instantiate(birdPrefab, transform.position, Quaternion.identity);

        b1.rigidbody.linearVelocity = rigidbody.linearVelocity;
        b2.rigidbody.linearVelocity = rigidbody.linearVelocity;
        b3.rigidbody.linearVelocity = rigidbody.linearVelocity;

        timeElapsed = 0f;
        wasSplit = true;

        // TODO Destroy this go
    }
}
