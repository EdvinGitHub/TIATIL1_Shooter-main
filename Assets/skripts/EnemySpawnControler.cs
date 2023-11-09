using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControler : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    GameObject EnemyPrefab2;
    float timer = 0;
    [SerializeField]

    float timeBetweenEnemies = 1.5f;
    int enemyAB;
    int enemySpawned;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenEnemies)
        {
            int numberToSpawn = 1 + enemySpawned / 3;

            for(int i =0; i < numberToSpawn; numberToSpawn--)
            {
                enemyAB = Random.Range(0, 3);
                if (enemyAB == 0)
                {
                    Instantiate(EnemyPrefab2);
                }
                else
                {
                    Instantiate(EnemyPrefab);
                }
            }
            enemySpawned++;

            timer = 0;



            // for (int i = 15, enemySpawned / i )
        }

    }


}

