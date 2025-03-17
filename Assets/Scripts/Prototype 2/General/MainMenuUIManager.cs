using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject controlsMenu;

    [SerializeField]
    private GameObject levelSelectMenu;

    private void Start()
    {
        controlsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void OnPlayGamePress()
    {
        levelSelectMenu.SetActive(true);
    }

    public void OnPlayLevelOnePress()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnPlayTwoOnePress()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void OnPlayThreeOnePress()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void OnControlsMenuPress()
    {
        controlsMenu.SetActive(true);
    }

    public void OnControlsMenuBackPress()
    {
        controlsMenu.SetActive(false);
    }

    public void OnLevelSelectMenuBackPress()
    {
        levelSelectMenu.SetActive(false);
    }

    public void OnExitGamePress()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
