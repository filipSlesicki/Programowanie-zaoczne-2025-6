using UnityEngine;
using UnityEngine.InputSystem;

public class BomberBird : Bird
{
    [SerializeField] Rigidbody egg;
    [SerializeField] bool eggReady = true;

    public override void Activate()
    {
        if (eggReady)
        {
            rigidbody.AddForce(new Vector3(0,rigidbody.mass,0) * activationSpeed, ForceMode.Impulse);
            //rigidbody.linearVelocity += Vector3.up * activationSpeed;
            egg.gameObject.SetActive(true);
            egg.transform.parent = null;
            egg.linearVelocity += Vector3.down * activationSpeed / 2;
            eggReady = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bird")
        {
            eggReady = false;
        }
    }
}
