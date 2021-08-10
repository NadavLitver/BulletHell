using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    TextMeshProUGUI[] GameTexts;
    public static UIManager uiManagerInstace;
    [SerializeField] private Animator backAnim;
    
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Animator pauseAnim;
    
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Animator optionsAnim;

    public bool isPaused { get;private set; }
    private void Awake()
    {
        uiManagerInstace = this;
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        SetPause(isPaused);
    }
    public void SetPause(bool pause)
    {
        isPaused = pause;
        Time.timeScale = isPaused ? 0 : 1;
        pauseAnim.SetBool("IsActive", isPaused);
        backAnim.SetBool("IsActive", isPaused);
        optionsAnim.SetBool("IsActive", false);
    }
    public void SetOptions(bool options)
    {
        optionsAnim.SetBool("IsActive", options);
        pauseAnim.SetBool("IsActive", !options);
    }

}
