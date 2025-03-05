using UnityEngine;

public enum GameState { Playing, GameOver, Victory }
public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject player;
    [SerializeField]
    private GameState gameState;

    private void Awake()
    {
        SetUpAllBrickInstances();
        SetUpPlayerInstance();
    }

    private void Start()
    {
        NewGame();
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
