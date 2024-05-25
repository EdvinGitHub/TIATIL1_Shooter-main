using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler3 : Entity 
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
    [SerializeField]
    float maxSpeedX;
    float shotTimer = 0f;
    float timeBetweenShots = 1.5f;
    int buffOrNot; 
    float x ;
    void Awake()
    {
        // vart den spawnar 
        x = Random.Range(-5f, 5f);
        speed = maxSpeed;
        //  när den ska skuta 
        shotTimer = Random.Range(-1f, 2f);
        //  gör så att den börjar över kamran 
        Vector2 pos = new Vector2(x, Camera.main.orthographicSize + 1);

        transform.position = pos;
        maxSpeedX = -4;
    
    }
    void Update()
    {
        shotTimer += Time.deltaTime;
        // när den ska skuta
        if (shotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0f;
        }
    
        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        // Fixade fiende 3 movment så att den kan inte jitra på plats ibland
        //  så att den åker höger till vänster 
        if(transform.position.x>= x +2)
        {
            maxSpeedX = 4;
        }
        else if(transform.position.x<=x -2)
        {
           maxSpeedX = -4;
        }
        // MOVMENT
        movement = new Vector2(maxSpeedX, -speed) * Time.deltaTime;
        transform.Translate(movement);
        // kollar om dens position är under kamran 
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
        // dör till bolt 
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
