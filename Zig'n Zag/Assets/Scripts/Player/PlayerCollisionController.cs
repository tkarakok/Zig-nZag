using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.Score += 2;
            UIManager.Instance.PointTextAnimation();
        }
        else if (other.CompareTag("GameOver"))
        {
            StateManager.Instance.state = State.EndGame;
            CameraController.Instance.CurrentCamera.transform.SetParent(null);
            UIManager.Instance.GameOver();

        }

    }
}
