using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { Playing, GameOver, Victory }
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bossManagerObject;
    [SerializeField]
    private GameObject musicManagerObject;
    private AudioSource musicManagerAudioSource;
    [SerializeField]
    private bool levelHasBoss;
    private BossManager bossManager;
    public int score = 0;
    [SerializeField]
    private float PAR_TIME = 120;
    [SerializeField]
    private float MAX_MULTIPLER = 100;
    public GameObject player;
    public UnityEvent onGameOver;
    public UnityEvent onVictory;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI parTimeText;
     [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI finalScoreText;
    [SerializeField]
    private TextMeshProUGUI multiplierText;
    [SerializeField]
    private TextMeshProUGUI finalTimeText;
    [SerializeField]
    private GameObject bossHealthPanelObject;
    [SerializeField]
    private GameState gameState;
    [SerializeField]
    private float timer;
    [SerializeField]
    private bool isTimerStopped;

    void Awake()
    {
        levelHasBoss = bossManagerObject != null ? true : false;

        if (levelHasBoss)
        {
            bossManager = bossManagerObject.GetComponent<BossManager>();
        }

        musicManagerAudioSource = musicManagerObject.GetComponent<AudioSource>();
        
        SetUpAllBrickInstances();
        SetUpPlayerInstance();
        SetUpAllEnemyPortalInstances();
    }

    void Start()
    {
        NewGame();
    }

    void Update()
    {
        if (!isTimerStopped)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + UpdateTimerText(timer);
        }

        if (levelHasBoss)
        {
            if (CheckAllBrickInstancesDestroyed())
            {
                bossHealthPanelObject.SetActive(true);
                if (bossManager.isBossDead)
                {
                    SetGameState(GameState.Victory);
                }
            }
        }
        else
        {
            if (CheckAllBrickInstancesDestroyed())
            {
                SetGameState(GameState.Victory);
            }
        }
        
        scoreText.text = "Score: " + score;
    }

    private void NewGame()
    {
        isTimerStopped = false;
        timer = 0;
        score = 0;
        string parTimeCalculation = string.Format("{0:00}:{1:00}", PAR_TIME / 60, PAR_TIME % 60);
        parTimeText.text = "Par Time: " + parTimeCalculation;
        gameState = GameState.Playing;
    }

    private string UpdateTimerText(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;
    }

    private int FinalScoreMultiplier(float time)
    {
        // Source: https://math.stackexchange.com/questions/4476575/calculate-score-in-a-game-based-on-time-passed
        float muliplierFloat = (MAX_MULTIPLER + 1) / Mathf.Pow(MAX_MULTIPLER + 1, time / PAR_TIME);
        return Mathf.CeilToInt(muliplierFloat);
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
        if (gameState == GameState.GameOver)
        {
            StartCoroutine(GameOverCoroutine());
        }
        else if (gameState == GameState.Victory)
        {
            SetVictoryState();
        }
    }

    private void SetVictoryState()
    {
        isTimerStopped = true;
        onVictory.Invoke();
        player.SetActive(false);

        finalTimeText.text = "Final Time: " + UpdateTimerText(timer);

        int muliplier = FinalScoreMultiplier(timer);
        multiplierText.text = "Time Multiplier: " + muliplier;
        if (levelHasBoss)
        {
            scoreText.text = "Score: " + bossManager.bossScore + score;
            finalScoreText.text = "Final Score: " + (bossManager.bossScore + score) * muliplier;
        }
        else
        {
            scoreText.text = "Score: " + score;
            finalScoreText.text = "Final Score: " + score * muliplier;
        }
    }

    private void SetGameOverState()
    {
        isTimerStopped = true;
        onGameOver.Invoke();
        scoreText.text = "Score: " + score;
    }

    IEnumerator GameOverCoroutine()
    {
        musicManagerAudioSource.Stop();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1f;
        SetGameOverState();
        yield return null;
    }

    private void SetUpAllBrickInstances()
    {
        var foundBrickObjects = FindObjectsByType<BrickBehavior>(FindObjectsSortMode.None);

        foreach (BrickBehavior brick in foundBrickObjects)
        {
            brick.SetGameManager(this);
        }
    }

    private void SetUpPlayerInstance()
    {
        var foundPlayerObject = FindObjectOfType<PlayerHealth>();
        foundPlayerObject.SetGameManager(this);
    }

    private void SetUpAllEnemyPortalInstances()
    {
        var foundEnemySpawnerObjects = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

        foreach (EnemySpawner enemySpawner in foundEnemySpawnerObjects)
        {
            enemySpawner.SetGameManager(this);
        }
    }

    private bool CheckAllBrickInstancesDestroyed()
    {
        var foundBrickInstances = GameObject.FindGameObjectsWithTag("Brick");
        return foundBrickInstances.Length <= 0;
    }

}
