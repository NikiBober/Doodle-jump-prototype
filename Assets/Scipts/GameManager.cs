using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore (int score)
    {
        _scoreText.text = "Score: " + score;
    }
}
