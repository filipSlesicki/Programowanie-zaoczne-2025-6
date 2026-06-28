using UnityEngine;
using System.Collections;

public class PumpBird : Bird
{
    [SerializeField] float sizeMultiplier;

    private Vector3 growSize;

    private void Start()
    {
        growSize = transform.localScale * sizeMultiplier;
    }
    public override void Activate()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        while (transform.localScale.x < growSize.x)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
