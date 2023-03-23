using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 7.0f;

    //push only when player falling
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0.0f)
        {
            Push(collision);
        }
    }

    //desrtoy when enter fall zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    //push player upwards
    private void Push (Collision2D objectToPush)
    {
        Rigidbody2D rigidbody2D = objectToPush.gameObject.GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            Vector2 velocity = rigidbody2D.velocity;
            velocity.y = _jumpForce;
            rigidbody2D.velocity = velocity;
        }
    }

}
