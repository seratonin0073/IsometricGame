using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector2 worldPosition;

    public GameObject gun;
    public GameObject player;

    private SpriteRenderer gunSprite;

    void Start()
    {
        gunSprite = gun.GetComponent<SpriteRenderer>();
        gunSprite.sortingOrder = 16;
    }

    // Update is called once per frame
    void Update()
    {

        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = new Vector3(worldPosition.x, worldPosition.y, 0) - transform.position;

        if(transform.rotation.z > -0.7f && transform.rotation.z < 0.7f)
        {
            gunSprite.flipY = false;
        }
        else
        {
            gunSprite.flipY = true;
        }

        if(player.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            gunSprite.sortingOrder = 14;
        }
        else if(player.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            gunSprite.sortingOrder = 16;
        }

    }
}
