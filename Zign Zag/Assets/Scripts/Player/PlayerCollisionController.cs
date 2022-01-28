using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            EventManager.Instance.Diamond();
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.gameObject,.5f);
            
        }
        else if (other.CompareTag("GameOver"))
        {
            EventManager.Instance.EndGame();
        }

    }
}
