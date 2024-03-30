using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jewel;//префаб коштовності
    [SerializeField] private GameObject victoryPanel;//панель пермеги

    public static int jewelMaxQuantity;//максимальна кількість коштовностей


    void Start()
    {
        jewelMaxQuantity = Random.RandomRange(5, 30);
        StartCoroutine("Spawn");    
        victoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < jewelMaxQuantity; i++)
        {
            Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            float x = Random.Range(bottomLeft.x, topRight.x);
            float y = Random.Range(bottomLeft.y, topRight.y);

            Instantiate(jewel, new Vector3(x, y, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
}
