using UnityEngine;

public class InflateBird : Bird
{
    public float InflateScale;
    
    public override void Activate()
    {
        transform.localScale = transform.localScale.normalized * InflateScale;
    }
}
