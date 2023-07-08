using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public GameObject basicEnemy;
    public GameObject armorEnemy;
    public GameObject magicEnemy;
    public GameObject hero;
    public Transform spawnParent;
    private float nextSpawn = 2f;
    private bool spawnHorde = true;
    private Vector2Int spawnArea;
    public UnityEngine.Tilemaps.Tilemap background;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < background.size.x; i++)
        {
            for (int j = 0; j < background.size.y; j++)
            {
                if (Mathf.Abs(spawnArea.x) > Mathf.Abs(background.CellToWorld(new Vector3Int(i, j, 0)).x))
                {
                    spawnArea.x = Mathf.FloorToInt(background.CellToWorld(new Vector3Int(i, j, 0)).x);
                }
                if (Mathf.Abs(spawnArea.y) < Mathf.Abs(background.CellToWorld(new Vector3Int(i, j, 0)).y))
                {
                    spawnArea.y = Mathf.FloorToInt(background.CellToWorld(new Vector3Int(i, j, 0)).y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            // Change the next update (current second + random value between 0.5s and 2s)
            nextSpawn = (Time.time) + (Random.Range(0.5f, 2));

            int randomValue = Random.Range(0, 3);

            switch (randomValue)
            {
                case 0:
                    SpawnEnemy(basicEnemy);
                    break;
                case 1:
                    SpawnEnemy(armorEnemy);
                    break;
                case 2:
                    SpawnEnemy(magicEnemy);
                    break;
                default:
                    break;
            }
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        CircleCollider2D spawnCircleCollider = hero.GetComponent<CircleCollider2D>();
        Vector3Int pos = new Vector3Int(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0);
        UnityEngine.Tilemaps.TileBase tile = background.GetTile(pos);

        while (spawnCircleCollider.OverlapPoint(new Vector2(pos.x, pos.y)) || tile == null){
            pos = new Vector3Int(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0);
            tile = background.GetTile(pos);
        }

        if (!spawnHorde)
        {
            Instantiate(enemy, pos, Quaternion.identity, spawnParent);
        }
        else
        {
            for (int i = 0; i < Random.Range(3, 7); i++)
            {
                Instantiate(enemy, PositionNearby(pos), Quaternion.identity, spawnParent);
            }
        }


    }

    Vector3 PositionNearby(Vector3 pos)
    {
        pos.x = Mathf.Clamp((pos.x += Random.Range(5, 10)), -spawnArea.x, spawnArea.x);
        pos.y = Mathf.Clamp((pos.y += Random.Range(5, 10)), -spawnArea.y, spawnArea.y);
        return pos;
    }
}
