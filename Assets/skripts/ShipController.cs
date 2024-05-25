using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
public class ShipController : Entity
{

  int maxhp = 99999;

  [SerializeField]
  float maxSpeed = 6;
  void Start()
  {
    speed = maxSpeed;
    CurrentHp = maxhp;

  }

  [SerializeField]
  GameObject bulletPrefab1;

  [SerializeField]
  Transform gunPosition;

  [SerializeField]
  float whatGun = 1;
  [SerializeField]
  public Image Hpfull;
  [SerializeField]
  TMP_Text healthText;
  public float healthAmount = 99f;

  int amountOfShots = 5;
  float shotTimer = 0;
  float timeBetweenShots = 0.5f;

  // Update is called once per frame
  void Update()
  {


    //movment kåd 
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    Vector2 movement = new Vector2(moveX, moveY);
    movement = movement.normalized * speed * Time.deltaTime;

    transform.Translate(movement);

    // gör så att man kan inte åka över eller under skärmen
    if (Mathf.Abs(transform.position.y) > Camera.main.orthographicSize - 0.6)
    {

      transform.Translate(Vector2.down * movement.y);

    }


    // gör så att man kan inte åka ut på höger och vänser sida 
    if (Mathf.Abs(transform.position.x) > Camera.main.orthographicSize * Camera.main.aspect - 0.5)
    {
      transform.Translate(Vector2.left * movement.x);

    }
    //updaterar skotens tid inan den kan skuta 
    shotTimer += Time.deltaTime;
    // kollar om man skuter 
    if (Input.GetAxisRaw("Fire1") > 0 && shotTimer > timeBetweenShots)
    {
      // nolställer rotationen om man sköt andra typen av skot innan 
      Quaternion rotation = Quaternion.Euler(0, 0, 0);
      // skuter normalt 
      if (whatGun == 0)
      {
        Instantiate(bulletPrefab1, gunPosition.position, Quaternion.identity);
        shotTimer = 0;
      }
      // gör så att man skuter en shotgun 
      if (whatGun == 1)
      {
        rotation.z = -0.6f;
        for (int i = 5; i > 0; i--)
        {
          rotation.z += 0.2f;
          Instantiate(bulletPrefab1, gunPosition.position, rotation);

        }
        shotTimer = 0;
        amountOfShots--;
        if (amountOfShots <= 0)
        {
          whatGun = 0;
          amountOfShots = 5;
        }
      }
    }

  }
  void OnTriggerEnter2D(Collider2D other)
  {
    // kollar om man nuddar saker om gör skada till en 
    if (other.gameObject.tag == "enemy" || other.gameObject.tag == "EnemyBolt" || other.gameObject.tag == "Boss")
    {
      CurrentHp -= 10;

    }

    // kollar om man nuddar buff 
    if (other.gameObject.tag == "Buff")
    {
      whatGun = 1;

    }
    //updaterar up text + slider 
    UpdateHealthSlider();
    // kollar om man dog 
    if (CurrentHp <= 10)
    {
      SceneManager.LoadScene(1);
    }
  }
  //updaterar up text + slider 
  private void UpdateHealthSlider()
  {
    healthAmount = CurrentHp;
    Hpfull.fillAmount = healthAmount /40f;
    healthText.text = -1+CurrentHp/10 + "/" + 3;
  }

}
/*

*/