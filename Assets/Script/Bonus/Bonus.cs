using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    private void Start()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.01f);

        while(colliders.Length < 2)
        {
            Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            float x = Random.Range(bottomLeft.x, topRight.x);
            float y = Random.Range(bottomLeft.y, topRight.y);

            Vector3 position = new Vector3(x, y, 0);
            transform.position = position;
            colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayJewelCollected();
            JewelSpawner.jewelCounter++;
            Destroy(gameObject);
        }
    }
}
