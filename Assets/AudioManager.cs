using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private float Master_Volume;
    private float Music_Volume => musicSlider.value * Master_Volume;
    private float SFX_Volume => sfxSlider.value * Master_Volume;

    public static AudioManager am;

    [Header("General")]
    public AudioClip Ambiance;
    private float ambianceSavedTime = 0;
    
    public AudioClip Pickup;
    public AudioClip StatuesMoving;
    public AudioClip Sarc;
    public AudioClip Button_Click;




    [Header("Player")]

    public AudioClip Player_Teleport;
    public AudioClip Player_AuraBurst;
    public AudioClip Player_Retribution;
    public AudioClip Player_Penance;
    public AudioClip Player_HolyShock;
    public AudioClip player_Step;
    public AudioClip player_Hit;

    [Header("Beatle")]
    public AudioClip beatle_Death;
    public AudioClip beatle_hit;


    [Header("Mummy")]
    public AudioClip mummy_Attack;
    public AudioClip mummy_Hit;
    public AudioClip mummy_Death;


    [Header("Boss")]
    public AudioClip boss_Attack;
    public AudioClip boss_Hit;
    public AudioClip boss_Death;
    public AudioClip boss_swapState;
    public AudioClip boss_Start;


    [Header("Sources Ref")]
    [SerializeField] private AudioSource m_defaultSource;
    [SerializeField] private List<AudioSource> m_randomSources;
    [SerializeField] private AudioSource m_musicSource;


    private void Awake()
    {
        if (am == null)
        {
            am = this;
        }
    }
    private void Start()
    {
        Master_Volume = masterSlider.value;
    }
    public void ButtonClick()
    {
        PlaySound(Button_Click, 1);
    }
    public void ButtonClick(int index)
    {
        float volume;
        switch (index)
        {
            case 0: volume = Master_Volume;break;
            case 1: volume = Music_Volume;break;
            case 2: volume = SFX_Volume;break;
            default:
                volume = 0.5f;
                Debug.LogError("Invalid index selected on button play sound");
                break;
        }
        PlaySound(Button_Click, volume);
        UpdateAllSources();
    }
    private void UpdateMusicSource()
    {
        m_musicSource.volume = Music_Volume;
    }
    private void UpdateAllSources()
    {
        foreach (AudioSource item in m_randomSources)
        {
            item.volume = SFX_Volume;
        }
        m_defaultSource.volume = SFX_Volume;
        UpdateMusicSource();
    }
    public void SetMasterVolumeMenu()
    {
        Master_Volume = masterSlider.value;
        UpdateAllSources();
    }
    public void SetMusicVolumeMenu()
    {
        UpdateMusicSource();
    }

    private void OnEnable()
    {
        m_musicSource.clip = Ambiance;
        m_musicSource.Play();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    public void PlaySound(AudioClip ac, float volume, bool isRandom, float volumeRange)
    {
        if (ac == null)
        {
            Debug.Log(ac + " is invalid");
            return;
        }
        if (isRandom)
        {
            volume *= SFX_Volume;
            m_randomSources[Random.Range(0,m_randomSources.Count)].PlayOneShot(ac, volume + Random.Range(-volumeRange/2, volumeRange/2));
        }
        else
        {
            PlaySound(ac, volume);
        }
    }
    public void PlaySound(AudioClip ac, float volume)
    {
        if (ac == null)
        {
            Debug.Log(ac + " is invalid");
            return;
        }
        volume *= SFX_Volume;
        m_defaultSource.PlayOneShot(ac, volume);
    }
    public void PlaySound(AudioClip ac, float volume, float delay)
    {
        if (ac == null)
        {
            Debug.Log(ac + " is invalid");
            return;
        }
        volume *= SFX_Volume;
        StartCoroutine(playSoundWithDelayCoru(ac, volume, delay));
    }
    private IEnumerator playSoundWithDelayCoru(AudioClip ac, float volume, float delay)
    {
        if (ac == null)
        {
            Debug.Log(ac + " is invalid");
            yield break;
        }
        yield return new WaitForSeconds(delay);
        m_defaultSource.PlayOneShot(ac, volume);
    }
}
