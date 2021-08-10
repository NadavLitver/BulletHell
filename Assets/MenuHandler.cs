using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject MainMenu;
    public GameObject CreditsCanvas;
    public GameObject CreditsMenu;

    public static MenuHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {
        CreditsMenu.SetActive(true);
        CreditsCanvas.SetActive(true);
        MainMenu.SetActive(false);
        MainMenuCanvas.SetActive(false);
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        MainMenuCanvas.SetActive(true);
        CreditsMenu.SetActive(false);
        CreditsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
