using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text scoreText;
    public Transform canvas;
    public GameObject pointText;


    public void GameModeUpButton()
    {
        GameManager.Instance.GameMode = GameMode.Up;
        TileManager.Instance.FirstStart();
        StateManager.Instance.state = State.InGame;
    }

    public void GameModeDownButton()
    {
        GameManager.Instance.GameMode = GameMode.Down;
        TileManager.Instance.FirstStart();
        //CameraController.Instance.ChangePOsition();
        StateManager.Instance.state = State.InGame;
    }

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
    }

    public void PointTextAnimation()
    {
        var point = Instantiate(pointText,canvas);
        point.transform.DOMove(scoreText.transform.position,1).OnComplete(() => UpdateScoreText()).OnComplete(()=> Destroy(point));
    }
}
