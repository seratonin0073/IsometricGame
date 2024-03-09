using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField]private float blastSpeed = 100f;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * blastSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 0.5f);
    }   
}
