using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySpawnControler : MonoBehaviour
{
    
    [SerializeField]
    GameObject EnemyPrefab1;
    [SerializeField]
    GameObject EnemyPrefab2;
    [SerializeField]
    GameObject EnemyPrefab3;
    float timer = 0;
    [SerializeField] TMP_Text Amount;
    bool bossAlive;
    int amount;
    float timeBetweenEnemies = 1.5f;
    int enemyAB;
    string text; 
    int enemySpawned = 45;
    int bossSpawns;
    int numberToSpawn;
    void Update()
    {   
        amount=0;
        numberToSpawn = 1 + enemySpawned / 3;
        IsBossAlive(); 
        if(bossAlive== false)
        {
        timer += Time.deltaTime;
        if(timer > timeBetweenEnemies)
        {
            if(numberToSpawn >= 12 )
            {
   
                Instantiate(EnemyPrefab3);
                enemySpawned = 0;
                numberToSpawn = 0;
                bossSpawns++;
                
            }

            for(int i =0; i < numberToSpawn; numberToSpawn--)
            {
                amount += 1;
                enemyAB = Random.Range(0, 3);
                if (enemyAB == 0)
                {
                    Instantiate(EnemyPrefab2);
                }
                else
                {
                    Instantiate(EnemyPrefab1);
                }
                
            }
            enemySpawned++;

            timer = 0;
            UpdateText();
            
            

            // for (int i = 15, enemySpawned / i )
        }
        }
    }
public void IsBossAlive()
{
    if(GameObject.FindGameObjectWithTag("Boss")== true)
    {bossAlive = true;}
    else{bossAlive= false;}
}
     private void UpdateText()
  {
    text = amount.ToString();
    Amount.text = text;
  }

}

