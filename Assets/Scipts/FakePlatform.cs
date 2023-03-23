using UnityEngine;

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
