
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject controlsMenu;
    [SerializeField]
    private GameObject musicManager;
    [SerializeField]
    private GameObject player;

    private PlayerController playerController;
    private AudioSource musicAudioSource;

    private bool isPaused;

    private void Awake()
    {
        musicAudioSource = musicManager.GetComponent<AudioSource>();
        playerController = player.transform.GetChild(0).GetComponent<PlayerController>();
        
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.instance.PauseMenuInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitToMenuPress()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnControlsMenuPress()
    {
        
    }
}
