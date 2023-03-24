using UnityEngine;
/// <summary>
/// Platform that moves in setted limits
/// </summary>
public class MovingPlatform : Platform
{
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _sideBound = 2.0f;
    [SerializeField]
    private bool _isVertical = false;
    [SerializeField]
    private float _verticalLimit = 1.0f;

    private Vector3 _movementDirection = Vector3.right;
    private float _initialPosition;

    // changes for vertical platform
    private void Start()
    {
        _initialPosition = transform.position.y;

        if (_isVertical)
        {
            _movementDirection = Vector3.up;
        }
    }

    // move platform once per frame
    private void Update()
    {
        float positionOffset = transform.position.y - _initialPosition;
        // reverse movement direction when platform reaches limits
        if (transform.position.x > _sideBound || transform.position.x < -_sideBound
            || positionOffset > _verticalLimit || positionOffset < -_verticalLimit)
        {
            _movementDirection = -_movementDirection;
        }

        transform.Translate(_movementDirection * Time.deltaTime * _speed);
    }
}
