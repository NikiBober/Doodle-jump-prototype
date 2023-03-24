using UnityEngine;
/// <summary>
/// Controls player movement
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 2.0f;
    [SerializeField]
    private Camera _camera;

    private float _score = 0.0f;
    private float _horizontalInput;
    private Rigidbody2D _playerRigidbody;

    // get reference to player`s rigidbody
    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // update score depends on player`s highest position
    private void Update()
    {
        if (transform.position.y > _score)
        {
            _score = transform.position.y;
            GameManager.Instance.UpdateScore((int)_score);
        }
    }

    //take input and do movements
    private void FixedUpdate()
    {
        _horizontalInput = Input.acceleration.x;

#if UNITY_EDITOR //this is for testing in editor. Note: must be commented for testing with Unity Remote
        //_horizontalInput = Input.GetAxis("Horizontal");
#endif

        MovePlayer(_horizontalInput);
        // mirror player`s position when he reaches camera`s viewport bounds
        Vector3 viewPosition = _camera.WorldToViewportPoint(transform.position);
        if (viewPosition.x > 1 || viewPosition.x < 0)
        {
            MirrorPlayer();
        }
    }

    // game over when player enter fall zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.GameOver((int)_score);
        Destroy(gameObject);
    }

    // move player`s rigidbody
    private void MovePlayer (float horizontalInput)
    {
        Vector2 velocity = _playerRigidbody.velocity;
        velocity.x = horizontalInput * _movementSpeed;
        _playerRigidbody.velocity = velocity;
    }

    //change player`s position to opposite
    private void MirrorPlayer()
    {
        Vector3 position = _playerRigidbody.position;
        position.x = -position.x;
        _playerRigidbody.position = position;
    }
}
