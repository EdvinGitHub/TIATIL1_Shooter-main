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
        shotTimer = Random.Range(-1f, 2f);
        
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
        if (transform.position.y < -Camera.main.orthographicSize - 2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        buffOrNot = Random.Range(1,11);
        if (other.gameObject.tag == "bolt")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if(buffOrNot ==10)
            {
            GameObject buff = Instantiate(buffPrefab, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
            
            Destroy(explosion, 0.3f);

        }
        if (other.gameObject.tag == "Player")
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
