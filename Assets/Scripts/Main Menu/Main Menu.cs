using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image boxSpriteRender;

    public Sprite BoxSprite1;
    public Sprite BoxSprite2;

    public GameObject howToPlay;
    public GameObject OptionsPage;
    public GameObject mainMenu;

    public void PressedBox()
    {
        if (boxSpriteRender.sprite == BoxSprite1)
        {
            boxSpriteRender.sprite = BoxSprite2;
            boxSpriteRender.SetNativeSize();
        }
        else
        {
            boxSpriteRender.sprite = BoxSprite1;
            boxSpriteRender.SetNativeSize();
        }
    }

    public void Back()
    {
        howToPlay.SetActive(false);
        OptionsPage.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Options()
    {
        OptionsPage.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
