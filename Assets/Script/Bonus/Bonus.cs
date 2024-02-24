using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bonus : MonoBehaviour
{
    private static TMP_Text bonusText;
    private static int score;

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
            bonusText.text = score.ToString();
            Destroy(gameObject);
        }
    }
}
