using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text scoreText;

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
    }
}
