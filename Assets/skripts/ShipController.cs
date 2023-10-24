using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ShipController : MonoBehaviour
{
  int CurrentHp = 1;
  int maxhp = 3;
  void Start()
  {
    CurrentHp = maxhp;

  }

  [SerializeField]
  GameObject bulletPrefab;
  [SerializeField]
  Transform gunPosition;

  [SerializeField]
  float speed = 5f;
  [SerializeField]
  Slider HealthSlider;
  [SerializeField]
  TMP_Text healthText;
  float shotTimer = 0;
  float timeBetweenShots = 0.5f;

  // Update is called once per frame
  void Update()
  {
    float speed = 5; // rutor per sekund

    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    Vector2 movement = new Vector2(moveX, moveY);
    movement = movement.normalized * speed * Time.deltaTime;

    transform.Translate(movement);


    if (Mathf.Abs(transform.position.y) < -Camera.main.orthographicSize - 0.5)
    {

      transform.Translate(Vector2.up  * movement.y);

    }
    if (transform.position.y > Camera.main.orthographicSize - 0.5)
    {
       transform.Translate(Vector2.down * movement.y);
     
    }

    print(Camera.main.aspect);

    if (Mathf.Abs(transform.position.x) > Camera.main.orthographicSize * Camera.main.aspect -0.5)
    {
      transform.Translate(Vector2.left * movement.x);
  
    }

    shotTimer += Time.deltaTime;

    if (Input.GetAxisRaw("Fire1") > 0 && shotTimer > timeBetweenShots)
    {
      Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
      shotTimer = 0;
    }

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "enemy")
    {
      CurrentHp -= 1;

    }
    if (other.gameObject.tag == "EnemyBolt")
    {
      CurrentHp -= 1;

    }
      UpdateHealthSlider(); 
      if (CurrentHp <= 0)
      {
        SceneManager.LoadScene(1);
      }
  }
  private void UpdateHealthSlider()
  {
    HealthSlider.maxValue = maxhp;
    HealthSlider.value = CurrentHp;

    healthText.text = CurrentHp + "/" + maxhp;
  }

}
/*

*/