using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class EnemySpawnControler : MonoBehaviour
{
    
    [SerializeField]
    GameObject EnemyPrefab1;
    [SerializeField]
    GameObject EnemyPrefab2;
    [SerializeField]
    GameObject EnemyPrefab3;
    [SerializeField]
    GameObject EnemyPrefab4;
    float timer = 0;
    [SerializeField] TMP_Text Amount;
    bool bossAlive;
    int amount;
    float timeBetweenEnemies = 1.5f;
    int enemyAB;
    string text; 
    int enemySpawned;
    int bossSpawns;
    
    int numberToSpawn;
    void Update()
    {      
    
        amount=0;

        numberToSpawn = 1 + enemySpawned / 2;
        // kollar om bossen lever
        IsBossAlive(); 
        // kollar om bossen inte lever 
        if(bossAlive== false)
        {
        // om man har dödat bossen 
        if(bossSpawns >= 3)
        {SceneManager.LoadScene(3);}
        timer += Time.deltaTime;
        if(timer > timeBetweenEnemies)
        {
        // hur mycket det behövs för att bossen ska spawnas 
            if(numberToSpawn >= 3 )
            {
                // Spawnar bossen 
                Instantiate(EnemyPrefab3);
                enemySpawned = 0;
                numberToSpawn = 0;
                bossSpawns++;
          
                
                
            }
            // spawnar små fiender
            for(int i =0; i < numberToSpawn; numberToSpawn--)
            {
                amount += 1;
                enemyAB = Random.Range(0, 3);
                if (enemyAB == 0)
                {
                    Instantiate(EnemyPrefab2);
                }
                if (enemyAB == 1)
                {
                    Instantiate(EnemyPrefab4);
                }
                if (enemyAB == 2)
                {
                    Instantiate(EnemyPrefab1);
                }
                
            }
            enemySpawned++;

            timer = 0;
            // updaterar textn för hur många fiender som ska spawnas 
            UpdateText();
            
            


        }
        }
    }
    // kollar om bossen lever
public void IsBossAlive()
{
    if(GameObject.FindGameObjectWithTag("Boss")== true)
    {bossAlive = true;}
    else{bossAlive= false;}
   
}
    // updaterar texten för hur många fiedner som spawnas 
    private void UpdateText()
  {
    text = amount.ToString();
    Amount.text = text;
  }

}

