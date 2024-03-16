using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Patrol patrol;
    public AIDestinationSetter destinator;
    public GameObject target;
    public int health = 5;
    public Slider hpBar;

    void Start()
    {
        hpBar.maxValue = health;
        hpBar.value = health;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance < 3f)
        {
            patrol.enabled = false;
            destinator.enabled = true;
        }
        else
        {
            patrol.enabled = true;
            destinator.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerSettings>().Damage(transform.position);
        }
        else if(collision.gameObject.CompareTag("Blast"))
        {
            health--;
            hpBar.value = health;
            Destroy(collision.gameObject);

            transform.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            Invoke("SetWhiteColor", 0.2f);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void SetWhiteColor()
    {
        transform.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
