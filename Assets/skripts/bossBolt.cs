using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBolt : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody2D body;
    [SerializeField]
    float speed;
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 diraction = player.transform.position - transform.position;
        body.velocity = new Vector2(diraction.x, diraction.y).normalized * speed;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
