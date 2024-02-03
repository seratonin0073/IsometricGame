using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1f;
    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb2d.velocity = new Vector2(moveH, moveV);
    }

    void Update()
    {
        
    }
}
