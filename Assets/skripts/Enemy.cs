using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity 
{
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject buffPrefab;
    [SerializeField]
    Transform gunPosition;

    [SerializeField]
    float maxSpeed;
    float shotTimer = 0f;
    float timeBetweenShots = 1.5f;
    int buffOrNot; 
    void Awake()
    {
        speed = maxSpeed;  
        // när den ska skuta 
        shotTimer = Random.Range(-1f, 2f);
        // vart den spawnar på x kordinat
        float x = Random.Range(-5f, 5f);
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 1);

        transform.position = pos;
    
    }
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0f;
        }

        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        transform.Translate(movement);
        // kollar om den är under kamran 
        if (transform.position.y < -Camera.main.orthographicSize - 2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
        // kollar om den kolidar med något
    private void OnTriggerEnter2D(Collider2D other)
    {
        // kollar om den ska ge en buff eller inte 
        buffOrNot = Random.Range(1,11);
        // dör till bolt + spelare 
        if (other.gameObject.tag == "bolt" || other.gameObject.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if(buffOrNot ==10)
            {
            GameObject buff = Instantiate(buffPrefab, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
            
            Destroy(explosion, 0.3f);

        }

    }


}
