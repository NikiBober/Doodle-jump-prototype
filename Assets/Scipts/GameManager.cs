using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// <summary>
/// Manages UI and level generation
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _gameOverText;
    [SerializeField]
    private GameObject _pauseMenu;

    [Header("Plarforms generation")]
    [SerializeField]
    [Tooltip("Normal platform must be first")]
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
    private Vector3 _spawnPosition;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Create starting number of platforms
    private void Start()
    {
        _spawnPosition = new()
        {
            y = _startVerticalPosition
        };

        if (_platformPrefab != null)
        {
            for (int i = 0; i < _startNumberOfPlatforms; i++)
            {
                SpawnPlatform();
            }
        }
    }

    //update in game score text
    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    //displays game over menu
    public void GameOver(int finalScore)
    {
        _scoreText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(true);
        _gameOverText.text = "Your score is " + finalScore;
    }

    //reload current scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //change time scle
    public void TogglePause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            _pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            _pauseMenu.SetActive(false);
        }
    }

    //spawn platform on random position in setted limits.
    //can spawn only one special platform after setted number of normal platforms
    public void SpawnPlatform()
    {
        int platformIndex;

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

        _spawnPosition.y += Random.Range(_minVerticalOffset, _maxVerticalOffset);
        _spawnPosition.x = Random.Range(-_sideBound, _sideBound);
        Instantiate(_platformPrefab[platformIndex], _spawnPosition, Quaternion.identity);
    }
}