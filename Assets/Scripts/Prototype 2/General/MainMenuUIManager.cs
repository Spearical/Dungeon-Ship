using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject controlsMenu;

    private void Start()
    {
        controlsMenu.SetActive(false);
    }

    public void OnPlayGamePress()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnControlsMenuPress()
    {
        controlsMenu.SetActive(true);
    }

    public void OnControlsMenuBackPress()
    {
        controlsMenu.SetActive(false);
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
