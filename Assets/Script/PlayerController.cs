using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Vector2 direction = new Vector2(moveH, moveV);
        rb2d.velocity = direction;

        FindObjectOfType<AnimationControler>().SetDirection(direction);

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            SceneManager.LoadScene(SceneManager.sceneCount);
        }
    }
}
