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
    void Awake()
    {
        body = GetComponent<Rigidbody2D>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 diraction = player.transform.position - transform.position;
        body.velocity = new Vector3(diraction.x, diraction.y, body.rotation).normalized * speed;
        
        

    }

    // Update is called once per frame
    void Update()
    {
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");
    Vector2 movement = new Vector2(moveX, moveY);
    if (Mathf.Abs(transform.position.x) > Camera.main.orthographicSize * Camera.main.aspect -0.5)
    {
      GameObject.Destroy(this.gameObject);
  
    }
    }
}
