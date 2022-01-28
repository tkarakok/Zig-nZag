using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateActions();
    public StateActions MainMenu;
    public StateActions InGame;
    public StateActions EndGame;

    public delegate void Collect();
    public Collect Diamond;

    private void Awake()
    {
        MainMenu += SubscribeAllEvent;
        MainMenu();
    }

    void SubscribeAllEvent()
    {
        InGame += UIManager.Instance.UpdateScoreText;

        EndGame += UIManager.Instance.GameOver;
        EndGame += AdManager.Instance.InterstitialAdShow;

        Diamond += UIManager.Instance.PointTextAnimation;
        Diamond += GameManager.Instance.CollectDiamond;
    }

}
