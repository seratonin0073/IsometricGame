using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Patrol patrol;
    public AIDestinationSetter destinator;
    public int health = 5;
    public Slider hpBar;
    public float agrRadius = 3f;

    private GameObject patrolPoints;
    private GameObject target;
    private bool isDead = false;
    private Animator anim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        patrolPoints = GameObject.FindGameObjectWithTag("PatrolPoints");
        patrol.targets = patrolPoints.GetComponentsInChildren<Transform>();
        destinator.target = target.transform;

        hpBar.maxValue = health;
        hpBar.value = health;
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance < agrRadius && !isDead)
        {
            patrol.enabled = false;
            destinator.enabled = true;
        }
        else if(distance >= agrRadius && !isDead)
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
                isDead = true;
                patrol.enabled = false;
                destinator.enabled = false;
                GetComponent<AIPath>().canMove = false;
                GetComponent<Collider2D>().enabled = false;
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayEnemyDeath();
                anim.Play("Death");
            }
        }
    }


    private void SetWhiteColor()
    {
        transform.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agrRadius);
    }
}
