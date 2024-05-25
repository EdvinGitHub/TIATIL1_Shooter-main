using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boss : Entity
{

    [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject bossBulletPrefab;
    [SerializeField]
    Transform gunPosition1;
    [SerializeField]
    Transform gunPosition2;

    [SerializeField]
    Transform gunPosition3;
    [SerializeField]
    Transform gunPosition4;
    [SerializeField]
    Image bossHealth;
    [SerializeField]
    Image bossHealth2;
    [SerializeField]
    TMP_Text bossHealthText;
    
   
    float shotTimer = 0f;
    int whatShot;
    float timeBetweenShots = 2f;
    
    int maxhp = 25;
  
    void Awake()
    {
        // boss saker
        CurrentHp = maxhp;
        bossHealth = GameObject.Find("BossHpFull").GetComponent<Image>();
        bossHealth2 = GameObject.Find("HpNo1").GetComponent<Image>();
        bossHealthText = GameObject.Find("BossHealthText").GetComponent<TMP_Text>();
        // bossHealth.gameObject.SetActive(true);
        // bossHealthText.gameObject.SetActive(true);
        bossHealth.GetComponent<Image>().enabled = true;
        bossHealth2. GetComponent<Image>().enabled = true;
        bossHealthText. GetComponent<TMP_Text>().enabled = true;

        
  

        float x = 0.11f;
        float y = 3.9f;
        Vector2 pos = new Vector2(x,y);

        transform.position = pos;
        
    }
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > timeBetweenShots)
        {   
            // vad den ska skuta 
            whatShot = Random.Range(1,5);
            // om den ska skuta normala skott
            if(whatShot == 1)
            {
            Instantiate(bulletPrefab, gunPosition1.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition2.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition3.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition4.position, Quaternion.identity);
            }
            if(whatShot > 1)
            {
                // ska skuta boss skot 
            Instantiate(bossBulletPrefab, gunPosition1.position, Quaternion.identity);
            Instantiate(bossBulletPrefab, gunPosition2.position, Quaternion.identity);
            Instantiate(bossBulletPrefab, gunPosition3.position, Quaternion.identity);
            Instantiate(bossBulletPrefab, gunPosition4.position, Quaternion.identity);
            }
            shotTimer = 0f;
        }
    }
        // kollar om den kolidar med något
    private void OnTriggerEnter2D(Collider2D other)
    {
        // minskar hp
        if (other.gameObject.tag == "bolt")
        {
            CurrentHp--;
        }
        if (other.gameObject.tag == "Player")
        {
            CurrentHp--;
        }
        // kollar om man dog
        if(CurrentHp <=0)
        {
            bossHealth.GetComponent<Image>().enabled = false;
            bossHealth2. GetComponent<Image>().enabled = false;
            bossHealthText. GetComponent<TMP_Text>().enabled = false;
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.7f);
        
        }
        // updaterar UI
    UpdateHealthSlider();
    }
    // updaterrar text och hp silder för bossen 
private void UpdateHealthSlider()
  {
   
    bossHealth.fillAmount = CurrentHp /25f;

    bossHealthText.text = CurrentHp + "/" + maxhp;
  }

}
