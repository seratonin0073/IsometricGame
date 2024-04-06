using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    private int health = 3;
    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite[] healthImage;
    private Rigidbody2D rb;
    void Start()
    {
        healthBar.sprite = healthImage[health];
        rb = GetComponent<Rigidbody2D>();
    }


    public void Damage(Vector3 enemyPos)
    {
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayPlayerDamage();
        health--;
        Vector2 impulse = enemyPos - transform.position;
        //GetComponent<Rigidbody2D>().AddForce(impulse * 100f, ForceMode2D.Impulse);
        transform.Translate(-impulse * 3f);
        //rb.AddForce(-impulse*100f, ForceMode2D.Impulse);
        Debug.LogError(rb.name);
        if(health <= 0)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayPlayerDeath();
            Application.LoadLevel(0);
        }
        healthBar.sprite = healthImage[health];

    }
}
