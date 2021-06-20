using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public void PlayButton()
    {
        StartCoroutine(PlayButtonSequence());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator PlayButtonSequence()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }


}
