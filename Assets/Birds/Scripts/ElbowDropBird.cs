using UnityEngine;

public class ElbowDropBird : Bird
{
    [SerializeField] private float elbowForce = 25f;

    public override void Activate()
    {
        rigidbody.AddForce(Vector3.down * elbowForce, ForceMode.Impulse);
    }

}
