using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jewel;

    void Start()
    {
        StartCoroutine("Spawn");    
    }

    IEnumerator Spawn()
    {
        Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float x = Random.Range(bottomLeft.x, topRight.x);
        float y  = Random.Range(bottomLeft.y, topRight.y);

        Debug.Log("Spawn");
        Instantiate(jewel, new Vector3(x, y, 0), Quaternion.identity);
        yield return new WaitForSeconds(10);
        StartCoroutine("Spawn");
    }
}
