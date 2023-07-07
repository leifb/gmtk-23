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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 2.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float y = background.transform.position.y + (background.bounds.size.y / 2f) - 1f;
        float x = background.transform.position.x + (background.bounds.size.x / 2f) -1f;
        int randomValue = Random.Range(0, 3);
        switch (randomValue)
        {
            case 0:
                Instantiate(basicEnemy, new Vector3(Random.Range(-x, x), Random.Range(-y, y), 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(armorEnemy, new Vector3(Random.Range(-x, x), Random.Range(-y, y), 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(magicEnemy, new Vector3(Random.Range(-x, x), Random.Range(-y, y), 0), Quaternion.identity);
                break;
            default:
                break;
        }
        
    }

}
