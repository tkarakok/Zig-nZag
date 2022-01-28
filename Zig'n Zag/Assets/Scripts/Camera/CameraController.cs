using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public GameObject upCamera, downCamera;
    private GameObject _currentCamera;

    public GameObject CurrentCamera { get => _currentCamera; set => _currentCamera = value; }

    private void Start()
    {
        CurrentCamera = upCamera;
    }
    public void ChangePOsition()
    {
        upCamera.SetActive(false);
        downCamera.SetActive(true);
        CurrentCamera = downCamera;
    }
}
