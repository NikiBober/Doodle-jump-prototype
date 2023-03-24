using UnityEngine;
/// <summary>
/// Move camera up when player reaches camera center
/// </summary>
public class CameraFollow : MonoBehaviour
{   
    [SerializeField]
    private Transform _target;

    private void LateUpdate()
    {
        if (_target != null && _target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
