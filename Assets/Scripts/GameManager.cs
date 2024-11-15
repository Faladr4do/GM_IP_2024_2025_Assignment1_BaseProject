using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int game_score = 0;
    public int enemies_destroyed = 0;

    [SerializeField]
    private TextMeshProUGUI textScore;

    private void Start()
    {
        UpdateScore();
    }
    public void AddScore(int score)
    {
        game_score += score;
        print(enemies_destroyed);
        UpdateScore();
    }
    private void UpdateScore()
    {
        textScore.text = "Score: " + game_score.ToString();
    }
}
