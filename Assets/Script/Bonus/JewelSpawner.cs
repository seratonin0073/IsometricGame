using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JewelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jewel;//префаб коштовності
    [SerializeField] private GameObject victoryPanel;//панель пермоги
    [SerializeField] private float spawnRate = 5f;//час в секундах як часто спавняться коштовності

    private TMP_Text bonusText;//текст який показує поточну кількість коштовностей
    private int jewelMaxQuantity;//максимальна кількість коштовностей

    public static int jewelCounter = 0;//кількість зібраних коштовностей


    void Start()
    {
        jewelCounter = 0;
        bonusText = GameObject.Find("BonusScoreText").GetComponent<TMP_Text>();

        jewelMaxQuantity = Random.RandomRange(20, 50);

        InvokeRepeating("Spawn", spawnRate, spawnRate);
        victoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        bonusText.text = $"{jewelCounter}/{jewelMaxQuantity}";
        if(jewelCounter >= jewelMaxQuantity)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayLevelCompleted();
            Time.timeScale = 0;
            victoryPanel.SetActive(true);
        }
    }

    private void Spawn()
    {
        Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float x = Random.Range(bottomLeft.x, topRight.x);
        float y = Random.Range(bottomLeft.y, topRight.y);

        Instantiate(jewel, new Vector3(x, y, 0), Quaternion.identity);
    }
}
