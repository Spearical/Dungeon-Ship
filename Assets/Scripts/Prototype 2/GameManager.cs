using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int score = 0;
    public int lives = 3;
    public bool enableDebug = false;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        lives = 3;

        if (enableDebug) LoadPlayground();
        else LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        currentLevel = level;
        SceneManager.LoadScene("Level_" + level);
    }

    private void LoadPlayground()
    {
        SceneManager.LoadScene("Playground");
    }
}
