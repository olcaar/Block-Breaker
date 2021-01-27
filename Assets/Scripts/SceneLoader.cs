using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // cached refernce
    GameSession gameStatus;

    // Constants
    int startingSceneIndex = 0;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(startingSceneIndex);
        gameStatus.DestroyGameStatus();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
