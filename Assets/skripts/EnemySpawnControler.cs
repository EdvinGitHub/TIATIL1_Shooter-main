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
    bool yes;
    int amount;
    float timeBetweenEnemies = 1.5f;
    int enemyAB;
    string text; 
    int enemySpawned=60;
    int i = 20;
    void Update()
    {   
        amount=0;
        IsBossAlive(); 
        if(yes== false)
        {
        timer += Time.deltaTime;
        if(timer > timeBetweenEnemies)
        {
            int numberToSpawn = 1 + enemySpawned / 3;
            if(numberToSpawn >= 15)
            {
                
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
            if(i < amount)
            {
                
               
                i += enemySpawned * 20;
                Instantiate(EnemyPrefab3);
                enemySpawned = 0;
                
                
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
    {yes = true;}
    else{yes= false;}
}
     private void UpdateText()
  {
    text = amount.ToString();
    Amount.text = text;
  }

}

