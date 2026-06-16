using UnityEngine;

public class ExpandingBird : Bird
{
    private bool bWasActivated = false;
    [SerializeField] private float ExpandScale = 2f;

    public override void Activate()
    {
        if (!bWasActivated)
        {
            transform.localScale *= ExpandScale;
            bWasActivated = true;
        }
    }
}


