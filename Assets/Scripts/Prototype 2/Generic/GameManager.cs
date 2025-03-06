using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Playing, GameOver, Victory }
public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject player;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameState gameState;

    void Awake()
    {
        SetUpAllBrickInstances();
        SetUpPlayerInstance();
    }

    void Start()
    {
        NewGame();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    private void NewGame()
    {
        score = 0;
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
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
}
