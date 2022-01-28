using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuPanel,gameModePanel,inGamePanel,endGamePanel;
    public Text inGameScoreText,endGameScoreText,endGameBestScoreText,mainMenuBestScoreText;
    public Transform canvas;
    public GameObject pointText;

    private GameObject _currentPanel;

    private void Start()
    {
        _currentPanel = mainMenuPanel;
        mainMenuBestScoreText.text = GameManager.Instance.BestScore.ToString();
    }

    #region GameOver
    public void GameOver()
    {
        PanelChange(endGamePanel);
        endGameScoreText.text = inGameScoreText.text;
        if (GameManager.Instance.BestScore < GameManager.Instance.Score)
        {
            PlayerPrefs.SetInt("BestScore",GameManager.Instance.Score);
            endGameBestScoreText.text = GameManager.Instance.Score.ToString();
        }
        else
        {
            endGameBestScoreText.text = GameManager.Instance.BestScore.ToString();
        }
    }
    #endregion


    #region Buttons
    public void StartButton()
    {
        PanelChange(gameModePanel);
    }
    #endregion

    #region Panel
    public void PanelChange(GameObject openPanel)
    {
        _currentPanel.SetActive(false);
        openPanel.SetActive(true);
        _currentPanel = openPanel;
    }
    #endregion

    #region Game Mode Selection
    public void GameModeUpButton()
    {
        GameManager.Instance.GameMode = GameMode.Up;
        TileManager.Instance.FirstStart();
        StateManager.Instance.state = State.InGame;
        PanelChange(inGamePanel);
    }

    public void GameModeDownButton()
    {
        GameManager.Instance.GameMode = GameMode.Down;
        TileManager.Instance.FirstStart();
        CameraController.Instance.ChangePOsition();
        StateManager.Instance.state = State.InGame;
        PanelChange(inGamePanel);
    }

    #endregion

    #region Update Score
    public void UpdateScoreText()
    {
        inGameScoreText.text = GameManager.Instance.Score.ToString();
    }
    #endregion

    #region Text Animation
    public void PointTextAnimation()
    {
        var point = Instantiate(pointText, canvas);
        point.transform.DOMove(inGameScoreText.transform.position, 1).OnComplete(() => UpdateScoreText()).OnComplete(() => Destroy(point));
    }
    #endregion

}
