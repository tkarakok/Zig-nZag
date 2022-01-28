using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : Singleton<TileManager>
{
    [Header("Tile Objects")]
    public Transform tileParent, diamondParent;
    public GameObject diamondPrefab;
    [Header("Spawn Speed Settings")]
    public float spawnTileSpeed;
    [Header("Game Mode and Spawn Position")]
    public Transform[] upPoints;
    public Transform[] downPoints;
    [Header("Eulor For Tile")]
    public Quaternion downRotation;
    [Header("Last Tile")]
    [SerializeField] private GameObject _lastTile;
    [System.Serializable] public struct Tile
    {
        public Queue<GameObject> tileQueue;
        public GameObject tilePrefab;
        public int totalTile;
    }
    [Header("Tile Pool")]
    [SerializeField] Tile tilePool;


    public void FirstStart()
    {
        if (GameManager.Instance.GameMode == GameMode.Down)
        {
            _lastTile.transform.position = downPoints[Random.Range(0, downPoints.Length)].position;
            _lastTile.transform.rotation = downRotation;
        }
        else
        {
            _lastTile.transform.position = upPoints[Random.Range(0, upPoints.Length)].position;
            
        }

        tilePool.tileQueue = new Queue<GameObject>();
        for (int i = 0; i < tilePool.totalTile; i++)
        {
            GameObject tile = Instantiate(tilePool.tilePrefab, tileParent);
            if (GameManager.Instance.GameMode == GameMode.Down)
            {
                tile.transform.rotation = downRotation;
            }
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
    public void SpawnTile()
    {
        if (StateManager.Instance.state == State.EndGame)
        {
            return;
        }
        var tile = GetTile();
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            tile.transform.position = _lastTile.transform.GetChild(0).position;
            _lastTile = tile;
            SpawnDiamond(tile);
        }
        else
        {
            tile.transform.position = _lastTile.transform.GetChild(1).position;
            _lastTile = tile;
            SpawnDiamond(tile);
        }
    }

    void SpawnDiamond(GameObject tile)
    {

        int diamondRandom = Random.Range(0, 100);
        if (diamondRandom <= 90)
        {
            return;
        }
        else if (diamondRandom > 90)
        {
            GameObject diamond = Instantiate(diamondPrefab, diamondParent);
            diamond.transform.position = tile.transform.GetChild(2).transform.position;
        }
        
    }

}
