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
        StartCoroutine(PlaySound(blasterShoot, blasterShoot.length));
    }

    public void PlayButtonClick()
    {
        StartCoroutine(PlaySound(buttonClick, buttonClick.length));
    }

    public void PlayEnemyDeath()
    {
        StartCoroutine(PlaySound(enemyDeath, enemyDeath.length));
    }

    public void PlayJewelCollected()
    {
        StartCoroutine(PlaySound(jewelCollected, jewelCollected.length));
    }

    public void PlayLevelCompleted()
    {
        audioClip.PlayOneShot(levelCompleted);
    }

    public void PlayPlayerDamage()
    {
        StartCoroutine(PlaySound(playerDamage, playerDamage.length));
    }

    public void PlayPlayerDeath()
    {
        StartCoroutine(PlaySound(playerDeath, playerDeath.length));
    }

    IEnumerator PlaySound(AudioClip audioClip, float time)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = audioClip;
        audio.pitch = Random.Range(0.9f, 1.1f);
        audio.Play();
        yield return new WaitForSeconds(time);
        Destroy(audio);
    }
}
