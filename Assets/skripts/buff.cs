using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour
{
  float speed = 6;

    void Update()
    {
        Vector2 movement = new Vector2(0, -speed) * Time.deltaTime;

        transform.Translate(movement);
        // kollar om den är utan för skärmen 
        if (transform.position.y < -Camera.main.orthographicSize - 2)
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }
    // gör saker för att göras + kollar om den nuddar spelare 
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }
}
