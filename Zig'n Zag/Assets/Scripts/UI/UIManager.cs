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
