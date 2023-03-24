using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Load MainScene from start screen
/// </summary>
public class PlayButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
