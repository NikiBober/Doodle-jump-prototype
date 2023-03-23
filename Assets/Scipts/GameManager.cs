using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _gameOverText;
    [SerializeField]
    private GameObject _pauseMenu;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void GameOver(int finalScore)
    {
        _scoreText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(true);
        _gameOverText.text = "Your score is " + finalScore;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

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
}