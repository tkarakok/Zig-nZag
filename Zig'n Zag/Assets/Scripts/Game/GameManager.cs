using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Up,
    Down
}

public class GameManager : Singleton<GameManager>
{
    
    private int _score;
    private int _bestScore;
    private GameMode gameMode;

    public int Score { get => _score; set => _score = value; }
    public GameMode GameMode { get => gameMode; set => gameMode = value; }
    public int BestScore { get => _bestScore; set => _bestScore = value; }

    private void Start()
    {
        Score = 1;
        BestScore = PlayerPrefs.GetInt("BestScore");
    }

}
