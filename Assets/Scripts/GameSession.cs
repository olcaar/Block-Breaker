using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f, 100f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] Text livesText;


    // state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] public int currentLives = 5;

    // cached reference
    SceneLoader mySceneLoader;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = scoreText.ToString();
        livesText.text = currentLives.ToString();
        mySceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
        livesText.text = currentLives.ToString();
        MoveToNextScene();
    }

    public void DecLives()
    {
        currentLives--;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void DestroyGameStatus()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    private void MoveToNextScene()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            mySceneLoader.LoadNextScene();
        }
    }
}
