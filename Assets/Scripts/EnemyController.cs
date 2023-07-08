using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public GameObject basicEnemy;
    public GameObject armorEnemy;
    public GameObject magicEnemy;
    public SpriteRenderer background;
    public GameObject hero;
    private float nextSpawn = 2f;
    private bool spawnHorde = true;
    private float spawnDistanceRadius = 10f;
    private Vector2 spawnArea;

    // Start is called before the first frame update
    void Start()
    {
        spawnArea.x = background.transform.position.x + (background.bounds.size.x / 2f) - 1f;
        spawnArea.y = background.transform.position.y + (background.bounds.size.y / 2f) - 1f;
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
        Vector3 pos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0);

        while (pos.x == 0 && hero.transform.position.x - spawnDistanceRadius <= pos.x && hero.transform.position.x + spawnDistanceRadius >= pos.x)
        {
            pos.x = Random.Range(-spawnArea.x, spawnArea.x);
        }
        while (pos.y == 0 && hero.transform.position.y - spawnDistanceRadius <= pos.y && hero.transform.position.y + spawnDistanceRadius >= pos.y)
        {
            pos.y = Random.Range(-spawnArea.y, spawnArea.y);
        }

        if (!spawnHorde)
        {
            Instantiate(enemy, pos, Quaternion.identity);
        }
        else
        {
            for (int i = 0; i < Random.Range(3, 7); i++)
            {
                Instantiate(enemy, PositionNearby(pos), Quaternion.identity);
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
