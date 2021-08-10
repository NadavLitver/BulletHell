using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 selfDir;
    public float startingSpeed = 7f;
    internal float speed ;
    [SerializeField,Header("Time To Live")]
    private float TTL = 10;
    [SerializeField] private float launchDelay;
    public enum BulletType { HolyShock, Penance, AuraBurst, MummyAttack }

    [SerializeField] private BulletType m_type;

    [SerializeField] private bool doPlaySound;
    [SerializeField] private bool isRandomSound;


    private void OnEnable()
    {
        speed = startingSpeed;

        if (doPlaySound)
        {
            PlaySound();
        }
      
        if(GameManager.gm.isFirstPhaseStarted && gameObject.layer == 8)
            speed *=  0.75f;
       
        if (GameManager.gm.isBulletSpeedDoubled && gameObject.layer == 8)
            speed *=  1.6f;
    }

    private void PlaySound()
    {
        AudioClip ac;
        float volume;
        switch (m_type)
        {
            case BulletType.HolyShock:
                ac = AudioManager.am.Player_HolyShock;
                volume = .25f;
                break;
            case BulletType.Penance:
                ac = AudioManager.am.Player_Penance;
                volume = .2f;
                break;
            case BulletType.AuraBurst:
                ac = AudioManager.am.Player_AuraBurst;
                volume = .25f;
                break;
            case BulletType.MummyAttack:
                ac = AudioManager.am.mummy_Attack;
                volume = .1f;
                break;
            default:
                ac = AudioManager.am.Player_HolyShock;
                volume = 1f;
                Debug.LogError("No bullet chosen, playing default sound");
                break;
        }
        AudioManager.am.PlaySound(ac, volume,isRandomSound,0.2f);
    }
    public void SetMovement(Vector2 dir)
    {
        selfDir = dir;
    }
    private void FixedUpdate()
    {
        transform.Translate(selfDir * speed * Time.fixedDeltaTime);

    }
   
    void SelfDestroy()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        StopAllCoroutines();

    }
}
