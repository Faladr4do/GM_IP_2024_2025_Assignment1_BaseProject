using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int game_score = 0;

    [SerializeField]
    private TextMeshProUGUI textScore;

    private void Start()
    {
        UpdateScore();
    }
    public void AddScore(int score)
    {
        game_score += score;
        UpdateScore();
    }
    private void UpdateScore()
    {
        textScore.text = game_score.ToString();
    }
}
