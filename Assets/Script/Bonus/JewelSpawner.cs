using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JewelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jewel;//префаб коштовності
    [SerializeField] private GameObject victoryPanel;//панель пермоги

    private TMP_Text bonusText;//текст який показує поточну кількість коштовностей
    private int jewelMaxQuantity;//максимальна кількість коштовностей

    public static int jewelCounter = 0;//кількість зібраних коштовностей


    void Start()
    {
        bonusText = GameObject.Find("BonusScoreText").GetComponent<TMP_Text>();

        jewelMaxQuantity = Random.RandomRange(5, 30);
        
        StartCoroutine("Spawn");
        victoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        bonusText.text = $"{jewelCounter}/{jewelMaxQuantity}";
        if(jewelCounter >= jewelMaxQuantity)
        {
            Time.timeScale = 0;
            victoryPanel.SetActive(true);
        }
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
            yield return new WaitForSeconds(0.5f);
        }
    }
}
