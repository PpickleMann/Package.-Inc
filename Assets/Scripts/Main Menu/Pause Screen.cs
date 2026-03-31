using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject howToPlayScreen;
    public GameObject OptionsPage;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        howToPlayScreen.SetActive(false);
        OptionsPage.SetActive(false);
    }

    public void HowToPlay()
    {
        howToPlayScreen.SetActive(true);
    }

    public void Options()
    {
        OptionsPage.SetActive(true);
    }

    public void BackToHomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                howToPlayScreen.SetActive(false);
                OptionsPage.SetActive(false);
            }
        }
    }
}
