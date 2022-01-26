using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileCollisionController : MonoBehaviour
{
    public float downTileSpeed;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DownTile());
        }
    }


    IEnumerator DownTile()
    {
        yield return new WaitForSeconds(downTileSpeed);
        transform.DOMove(new Vector3(transform.position.x,-5,transform.position.z),10).OnComplete(() => Destroy(gameObject));
        TileManager.Instance.TileSpawner();
    }
}
