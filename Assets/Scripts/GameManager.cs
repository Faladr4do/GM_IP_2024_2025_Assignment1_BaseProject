using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int game_score = 0;
    private int enemies_destroyed = 0;
    private int enemies_limit = 10;

    [SerializeField]
    private TextMeshProUGUI textScore;

    private void Start()
    {
        UpdateScore();
    }
    public void AddScore(int score)
    {
        game_score += score;
        enemies_destroyed++;
        UpdateScore();
    }
    private void UpdateScore()
    {
        textScore.text = "Score: " + game_score.ToString();
    }
    private void FixedUpdate()
    {
        if (enemies_destroyed >= enemies_limit)
        {

        }
    }
    
}
