using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField]
    private float _sideBound = 2;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private bool _isVertical = false;
    [SerializeField]
    private float _verticalLimit = 1;

    private Vector3 _movementDirection = Vector3.right;
    private float _initialPosition;

    // Start is called before the first frame update
    private void Start()
    {
        _initialPosition = transform.position.y;

        if (_isVertical)
        {
            _movementDirection = Vector3.up;
        }
    }

    // Update is called once per frame
    private void Update()
    {

        float positionOffset = transform.position.y - _initialPosition;

        if (transform.position.x > _sideBound || transform.position.x < -_sideBound
            || positionOffset > _verticalLimit || positionOffset < -_verticalLimit)
        {
            _movementDirection = -_movementDirection;
        }


        transform.Translate(_movementDirection * Time.deltaTime * _speed);
    }
}
