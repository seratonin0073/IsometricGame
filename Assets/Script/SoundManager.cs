using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip blasterShoot;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip enemyDeath;
    [SerializeField] private AudioClip jewelCollected;
    [SerializeField] private AudioClip levelCompleted;
    [SerializeField] private AudioClip playerDamage;
    [SerializeField] private AudioClip playerDeath;
    [SerializeField] private AudioSource audioClip;

    public void PlayBlasterShoot()
    {
        audioClip.PlayOneShot(blasterShoot);
    }

    public void PlayButtonClick()
    {
        audioClip.PlayOneShot(buttonClick);
    }

    public void PlayEnemyDeath()
    {
        audioClip.PlayOneShot(enemyDeath);
        
    }

    public void PlayJewelCollected()
    {
        audioClip.PlayOneShot(jewelCollected);
    }

    public void PlayLevelCompleted()
    {
        audioClip.PlayOneShot(levelCompleted);
    }

    public void PlayPlayerDamage()
    {
        audioClip.PlayOneShot(playerDamage);
    }

    public void PlayPlayerDeath()
    {
        audioClip.PlayOneShot(playerDeath);
    }
}
