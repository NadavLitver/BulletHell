using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public UnityEvent PlayerLost;
    public UnityEvent PlayerWon;
    public bool isBulletSpeedDoubled;
    public bool isSixPhaseReached;
    public bool isFirstPhaseStarted;
    public UnityEvent FirstPhaseStarted;
    public Boss BossRef;
    public UIManager UIManager;


    public bool isPaused => UIManager.isPaused;

    private void Awake()
    {
        if (gm == null)
            gm = this;
        if (PlayerLost == null)
            PlayerLost = new UnityEvent();
        if (PlayerWon == null)
            PlayerWon = new UnityEvent();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager != null)
            {
                UIManager.TogglePause();
            }
        }
    }
    public void CallDeactivateAndActiveGO(GameObject GO)
    {
        StartCoroutine(DeactivateAndActivateGO(GO));
    }
    private void Start()
    {
        BossRef.ThirtyPercentEvent.AddListener(SetBulletSpeedDoubled);
        FirstPhaseStarted.AddListener(SetFirstPhase);

        GameManager.gm.isSixPhaseReached = false;
        AudioManager.am.PlaySound(AudioManager.am.boss_Start, .8f);
        UIManager.SetPause(false);
    }
    void SetFirstPhase()
    {
        isFirstPhaseStarted = true;
    }
    private IEnumerator DeactivateAndActivateGO(GameObject GO)
    {
        GO.SetActive(false);
        yield return new WaitForSeconds(5f);
        GO.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); ;
    }
    void SetBulletSpeedDoubled()
    {
        isBulletSpeedDoubled = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
