using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    [SerializeField]private GameObject _lastTile;
    public GameObject tilePrefab;
    public Transform tileParent;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            TileSpawner();
        }
    }

    public void TileSpawner()
    {
        GameObject tile = Instantiate(tilePrefab, tileParent);
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            tile.transform.position = _lastTile.transform.GetChild(0).position;
            _lastTile = tile;
        }
        else
        {
            tile.transform.position = _lastTile.transform.GetChild(1).position;
            _lastTile = tile;
        }
    }
}
