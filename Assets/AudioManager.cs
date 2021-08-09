using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float MasterVolume;


    public static AudioManager am;

    [Header("General")]
    public AudioClip Ambiance;
    private float ambianceSavedTime = 60;
    
    public AudioClip Pickup;
    public AudioClip StatuesMoving;
    public AudioClip Sarc;





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
    //public AudioClip boss_Death;
    //public AudioClip boss_swapState;


    [Header("Sources Ref")]
    [SerializeField] private AudioSource m_source;
    [SerializeField] private List<AudioSource> m_randomSources;
    [SerializeField] private AudioSource m_sourceAmbiance;


    private void Awake()
    {
        if (am == null)
        {
            am = this;
        }
    }

    private void OnEnable()
    {
        m_sourceAmbiance.clip = Ambiance;
        m_sourceAmbiance.Play();
        m_sourceAmbiance.time = ambianceSavedTime;
    }
    private void OnDisable()
    {
        ambianceSavedTime = m_sourceAmbiance.time;
    }

    public void PlaySound(AudioClip ac, float volume, bool isRandom, float volumeRange)
    {
        volume *= MasterVolume;
        if (isRandom)
        {
            m_randomSources[Random.Range(0,m_randomSources.Count)].PlayOneShot(ac, volume + Random.Range(-volumeRange/2, volumeRange/2));
        }
        else
        {
            PlaySound(ac, volume);
        }
    }
    public void PlaySound(AudioClip ac, float volume)
    {
        m_source.PlayOneShot(ac, volume);
    }
    public void PlaySound(AudioClip ac, float volume, float delay)
    {
        StartCoroutine(playSoundWithDelayCoru(ac, volume, delay));
    }
    private IEnumerator playSoundWithDelayCoru(AudioClip ac, float volume, float delay)
    {
        yield return new WaitForSeconds(delay);
        m_source.PlayOneShot(ac, volume);
    }
}
