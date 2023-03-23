using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformPrefab;
    [SerializeField]
    private int _numberOfPlatforms = 100;
    [SerializeField]
    private float _sideBound = 2.0f;
    [SerializeField]
    private float _minVerticalOffset = 0.2f;
    [SerializeField]
    private float _maxVerticalOffset = 2.0f;
    [SerializeField]
    private float _startVerticalPosition = -5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        if (_platformPrefab != null)
        {
            Spawn(_numberOfPlatforms);
        }
    }

    private void Spawn(int spawnCount)
    {

        Vector3 spawnPosition = new()
        {
            y = _startVerticalPosition
        };

        for (int i = 0; i < spawnCount; i++)
        {
            int platformIndex = Random.Range(0, _platformPrefab.Length);

            spawnPosition.y += Random.Range(_minVerticalOffset, _maxVerticalOffset);
            spawnPosition.x = Random.Range(-_sideBound, _sideBound);
            Instantiate(_platformPrefab[platformIndex], spawnPosition, Quaternion.identity);
        }
    }
}