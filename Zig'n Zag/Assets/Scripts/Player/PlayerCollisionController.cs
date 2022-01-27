using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.Score += 2;
            UIManager.Instance.UpdateScoreText();
            UIManager.Instance.PointTextAnimation();
        }
    }
}
