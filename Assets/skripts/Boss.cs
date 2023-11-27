using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform gunPosition1;
    [SerializeField]
    Transform gunPosition2;

    [SerializeField]
    Transform gunPosition3;
    [SerializeField]
    Transform gunPosition4;
    [SerializeField]
    float speed = 5;
    float shotTimer = 0f;
    int WhatShot;
    float timeBetweenShots = 1.5f;
    void Start()
    {
        shotTimer = Random.Range(0f, 1.5f);
        {
            float x = 0.11f;
            float y = 3.9f;
            Vector2 pos = new Vector2(x,y);

            transform.position = pos;
        }
    }
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > timeBetweenShots)
        {   
            WhatShot = Random.Range(1,3);
            if(WhatShot == 1)
            {
            Instantiate(bulletPrefab, gunPosition1.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition2.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition3.position, Quaternion.identity);
            Instantiate(bulletPrefab, gunPosition4.position, Quaternion.identity);
            }
            if(WhatShot == 2)
            {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            Instantiate(bulletPrefab, gunPosition1.position, rotation);
            Instantiate(bulletPrefab, gunPosition2.position, rotation);
            Instantiate(bulletPrefab, gunPosition3.position, rotation);
            Instantiate(bulletPrefab, gunPosition4.position, rotation);
            }
            shotTimer = 0f;
        }

        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        transform.Translate(movement);
        if (transform.position.y < -Camera.main.orthographicSize - 2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bolt")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(explosion, 0.3f);

        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab , transform.position, Quaternion.identity);

            Destroy(explosion, 0.3f);

        }
    }
}
