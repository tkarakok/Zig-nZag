using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    private int _score;


    public int Score { get => _score; set => _score = value; }

    private void Start()
    {
        
        Score = 0;
    }

}
