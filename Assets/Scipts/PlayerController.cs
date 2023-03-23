using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 2.0f;
    private float _sideBound = 2.8125f;
    private float _score = 0;
    private float _horizontalInput;
    private Rigidbody2D _playerRigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y > _score)
        {
            _score = transform.position.y;
            GameManager.Instance.UpdateScore((int)_score);
        }

        if (transform.position.x > _sideBound || transform.position.x < -_sideBound)
        {
            MirrorPlayer();
        }

    }

    private void FixedUpdate()
    {
        _horizontalInput = Input.acceleration.x;

#if UNITY_EDITOR
        _horizontalInput = Input.GetAxis("Horizontal");
#endif

        MovePlayer(_horizontalInput);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over!");
    }

    private void MovePlayer (float horizontalInput)
    {
        Vector2 velocity = _playerRigidbody.velocity;
        velocity.x = horizontalInput * _movementSpeed;
        _playerRigidbody.velocity = velocity;
    }

    private void MirrorPlayer()
    {
        Vector3 position = _playerRigidbody.position;
        position.x = -position.x;
        _playerRigidbody.position = position;
    }


}
