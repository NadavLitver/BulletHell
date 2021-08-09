using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject MainMenu;
    public GameObject CreditsCanvas;
    public GameObject CreditsMenu;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        MainMenuCanvas.SetActive(false);
        CreditsMenu.SetActive(true);
        CreditsCanvas.SetActive(true);
    }

    public void BackButton()
    {
        CreditsMenu.SetActive(false);
        CreditsCanvas.SetActive(false);
        MainMenu.SetActive(true);
        MainMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
