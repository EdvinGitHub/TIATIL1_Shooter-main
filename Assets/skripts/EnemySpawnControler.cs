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
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenEnemies)
        {
            enemyAB = Random.Range(0,3);
            if(enemyAB == 0)
            {
            Instantiate(EnemyPrefab2);
            }
            else
            {
            Instantiate(EnemyPrefab);
            }
            timer = 0;
        }
    }


}

