using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    private static TMP_Text bonusText;
    public static int score;

    private void Start()
    {
        if(bonusText == null)
        {
            bonusText = GameObject.Find("BonusScoreText").GetComponent<TMP_Text>();
            score = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            score++;
            //int maxScore = JewelSpawner.jewelMaxQuantity;
            //bonusText.text = $"{score}/{maxScore}";
            Destroy(gameObject);
        }
    }
}
