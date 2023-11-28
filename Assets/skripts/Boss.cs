using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Boss : MonoBehaviour
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
    Slider bossHealth;
   
    float shotTimer = 0f;
    int whatShot;
    float timeBetweenShots = 2f;
    int CurrentHp = 1;
    int maxhp = 45;
  
    void Start()
    {
        CurrentHp = maxhp;

   

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
            whatShot = Random.Range(1,3);
            if(whatShot == 1)
            {
            Instantiate(bulletPrefab, gunPosition1.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition2.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition3.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition4.position, Quaternion.identity);
            }
            if(whatShot == 2)
            {
        
            
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            Instantiate(bossBulletPrefab, gunPosition1.position, Quaternion.identity);
            Instantiate(bossBulletPrefab, gunPosition2.position, Quaternion.identity);
            Instantiate(bossBulletPrefab, gunPosition3.position, Quaternion.identity);
            Instantiate(bossBulletPrefab, gunPosition4.position, Quaternion.identity);
            }
            shotTimer = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bolt")
        {
            CurrentHp--;
        }
        if (other.gameObject.tag == "Player")
        {
            CurrentHp--;
        }
        if(CurrentHp <=0)
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(explosion, 0.7f);
        }
    UpdateHealthSlider();
    }

     private void UpdateHealthSlider()
  {
    bossHealth.maxValue = maxhp;
    bossHealth.value = CurrentHp;

  }
}
