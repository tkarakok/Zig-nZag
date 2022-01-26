using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
   
    public Transform tileParent;
    public float spawnTileSpeed;
    [SerializeField] private GameObject _lastTile;


    [System.Serializable]
    public struct Tile
    {
        public Queue<GameObject> tileQueue;
        public GameObject tilePrefab;
        public int totalTile;
    }

    [SerializeField] Tile tilePool;

    private void Awake()
    {
        tilePool.tileQueue = new Queue<GameObject>();
        for (int i = 0; i < tilePool.totalTile; i++)
        {
            GameObject tile = Instantiate(tilePool.tilePrefab, tileParent);
            tile.SetActive(false);
            tilePool.tileQueue.Enqueue(tile);
        }
        for (int i = 0; i < 30; i++)
        {
            SpawnTile();
        }

        StartSpawnTile();
    }

    // get tile object
    public GameObject GetTile()
    {
        GameObject tile = tilePool.tileQueue.Dequeue();
        tile.SetActive(true);
        tilePool.tileQueue.Enqueue(tile);
        return tile;
    }

    // start spawn tile corotuine for in game
    public void StartSpawnTile()
    {
        StartCoroutine(SpawnTileInGame());
    }

    IEnumerator SpawnTileInGame()
    {
        while (true)
        {
            SpawnTile();
            yield return new WaitForSeconds(spawnTileSpeed);
        }
        
    }

    // when we were first start game this function called
    void SpawnTile()
    {
        var tile = GetTile();
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
