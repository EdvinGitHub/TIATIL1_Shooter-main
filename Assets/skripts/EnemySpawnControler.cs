using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControler : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;
    float timer = 0;
    [SerializeField]

    float timeBetweenEnemies = 1.5f;
   
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenEnemies)
        {
      
            Instantiate(EnemyPrefab);
            timer = 0;
        }
    }


}

