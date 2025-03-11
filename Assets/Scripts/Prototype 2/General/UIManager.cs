
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject controlsMenu;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private GameObject victoryMenu;
    [SerializeField]
    private GameObject musicManager;
    [SerializeField]
    private GameObject player;

    private PlayerController playerController;
    private AudioSource musicAudioSource;

    private bool isPaused;

    private bool isGameOver;
    private bool isVictory;

    private void Awake()
    {
        musicAudioSource = musicManager.GetComponent<AudioSource>();
        playerController = player.transform.GetChild(0).GetComponent<PlayerController>();
    }

    private void Start()
    {
        isGameOver = false;
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        victoryMenu.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.instance.PauseMenuInput)
        {
            if (!isPaused && !isGameOver)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
        
        if (isGameOver)
        {
            DisplayGameOverMenu();
        }
        
        if (isVictory)
        {
            DisplayVictoryMenu();
        }
    }

    public void SetGameOverTrue()
    {
        isGameOver = true;
    }

    public void SetVictoryTrue()
    {
        isVictory = true;
    }

    private void DisplayGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    private void DisplayVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        PausePlayer();
        OpenPauseMenu();
        PauseMusic();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
        UnpausePlayer();
        UnpauseMusic();
    }

    private void PauseMusic()
    {
        musicAudioSource.Pause();
    }

    private void UnpauseMusic()
    {
        musicAudioSource.UnPause();
    }

    private void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    private void CloseAllMenus()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    private void PausePlayer()
    {
        playerController.enabled = false;
    }

    private void UnpausePlayer()
    {
        playerController.enabled = true;
    }

    public void OnRestartPress()
    {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitToMenuPress()
    {
        Unpause();
        SceneManager.LoadScene("Main Menu");
    }

    public void OnControlsMenuPress()
    {
        controlsMenu.SetActive(true);
    }

        public void OnControlsMenuBackPress()
    {
        controlsMenu.SetActive(false);
    }
}
