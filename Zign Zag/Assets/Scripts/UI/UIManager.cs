using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    }

    #region GameOver
    public void GameOver()
    {
        PanelChange(endGamePanel);
        StateManager.Instance.state = State.EndGame;
        CameraController.Instance.CurrentCamera.transform.SetParent(null);
        PlayerPrefs.SetInt("Diamond", (GameManager.Instance.TotalDiamond + GameManager.Instance.DiamondCounter));

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

    public void RestartButton()
    {
        string _currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_currentSceneName);
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
        EventManager.Instance.InGame();
    }

    public void GameModeDownButton()
    {
        GameManager.Instance.GameMode = GameMode.Down;
        TileManager.Instance.FirstStart();
        CameraController.Instance.ChangePOsition();
        StateManager.Instance.state = State.InGame;
        PanelChange(inGamePanel);
        EventManager.Instance.InGame();
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
