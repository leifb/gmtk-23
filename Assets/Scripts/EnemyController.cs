using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public GameObject basicEnemy;
    public GameObject armorEnemy;
    public GameObject magicEnemy;
    public float spawnPadding = 2f;
    public GameObject hero;
    public Transform spawnParent;
    private float nextSpawn = 1f;
    private bool spawnHorde = true;
    public Tilemap background;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            // Change the next update (current second + random value between 0.5s and 2s)
            nextSpawn = (Time.time) + (Random.Range(0.5f, 1));

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

        BoundsInt bounds = background.cellBounds;
        Vector3Int minCell = bounds.min;
        Vector3Int maxCell = bounds.max;

        Vector3 minWorldPos = background.CellToWorld(minCell);
        Vector3 maxWorldPos = background.CellToWorld(maxCell);
        minWorldPos += new Vector3(spawnPadding,spawnPadding,0);
        maxWorldPos -= new Vector3(spawnPadding,spawnPadding,0);

        Vector3 pos = new Vector3(Random.Range(minWorldPos.x, maxWorldPos.x), Random.Range(minWorldPos.y, maxWorldPos.y), 0);

        while (spawnCircleCollider.OverlapPoint(new Vector2(pos.x, pos.y)) || background.WorldToCell(pos) == null){
            pos = new Vector3(Random.Range(minWorldPos.x, maxWorldPos.x), Random.Range(minWorldPos.y, maxWorldPos.y), 0);
        }

        if (!spawnHorde)
        {
            Instantiate(enemy, pos, Quaternion.identity, spawnParent);
        }
        else
        {
            for (int i = 0; i < Random.Range(3, 7); i++)
            {
                Instantiate(enemy, PositionNearby(pos, minWorldPos, maxWorldPos), Quaternion.identity, spawnParent);
            }
        }
    }

    Vector3 PositionNearby(Vector3 pos, Vector3 minWorldPos, Vector3 maxWorldPos)
    {
        pos.x = Mathf.Clamp((pos.x += Random.Range(5, 10)), minWorldPos.x, maxWorldPos.x);
        pos.y = Mathf.Clamp((pos.y += Random.Range(5, 10)), minWorldPos.y, maxWorldPos.y);
        return pos;
    }
}
