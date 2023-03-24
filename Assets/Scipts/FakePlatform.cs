using UnityEngine;
/// <summary>
/// Platform that destroys when player ground on it
/// </summary>
public class FakePlatform : Platform
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
