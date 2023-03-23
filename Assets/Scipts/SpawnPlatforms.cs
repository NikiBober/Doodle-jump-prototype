using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformPrefab;
    [SerializeField]
    private int _startNumberOfPlatforms = 100;
    [SerializeField]
    private float _sideBound = 2.0f;
    [SerializeField]
    private float _minVerticalOffset = 0.2f;
    [SerializeField]
    private float _maxVerticalOffset = 1.3f;
    [SerializeField]
    private float _startVerticalPosition = -5.0f;
    [SerializeField]
    private int _normalPlatfomsAtRow = 3;
    private int _counter = 0;

    // Start is called before the first frame update
    private void Start()
    {
        if (_platformPrefab != null)
        {
            Spawn(_startNumberOfPlatforms);
        }
    }

    private void Spawn(int spawnCount)
    {

        Vector3 spawnPosition = new()
        {
            y = _startVerticalPosition
        };

        int platformIndex;
        for (int i = 0; i < spawnCount; i++)
        {
            if (_counter < _normalPlatfomsAtRow)
            {
                platformIndex = 0;
                _counter++;
            }
            else
            {
                platformIndex = Random.Range(0, _platformPrefab.Length);
                if (platformIndex != 0)
                {
                    _counter = 0;
                } 
            }

            spawnPosition.y += Random.Range(_minVerticalOffset, _maxVerticalOffset);
            spawnPosition.x = Random.Range(-_sideBound, _sideBound);
            Instantiate(_platformPrefab[platformIndex], spawnPosition, Quaternion.identity);
        }
    }
}
