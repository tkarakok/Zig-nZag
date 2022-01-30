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
    public Material material;
    [Range(0,1)]
    public float lerpTime;
    public Color[] colors;
    public Color defaultColor;

    private Color _currentColor;
    private int _score;
    private int _bestScore;
    private int _totalDiamond;
    private int _diamondCounter;
    private GameMode gameMode;

    #region EnCapsullaiton
    public int Score { get => _score; set => _score = value; }
    public GameMode GameMode { get => gameMode; set => gameMode = value; }
    public int BestScore { get => _bestScore; set => _bestScore = value; }
    public int DiamondCounter { get => _diamondCounter; set => _diamondCounter = value; }
    public int TotalDiamond { get => _totalDiamond; set => _totalDiamond = value; }
    #endregion

    private void Start()
    {
        Score = 1;
        DiamondCounter = 0;
        BestScore = PlayerPrefs.GetInt("BestScore");
        TotalDiamond = PlayerPrefs.GetInt("Diamond");
        UIManager.Instance.mainMenuBestScoreText.text = BestScore.ToString();
        _currentColor = defaultColor;
    }

    private void Update()
    {
        material.color = Color.Lerp(material.color, _currentColor, lerpTime * Time.deltaTime);
    }

    public void CollectDiamond()
    {
        DiamondCounter++;
        Score += 2;
    }
    public void ChangeColor()
    {
        _currentColor = colors[Random.Range(0, colors.Length)];
    }
    public void ChangeDefaultColor()
    {
        material.color = defaultColor;
    }
}
