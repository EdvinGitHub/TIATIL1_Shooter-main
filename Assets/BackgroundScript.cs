using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    // Start is called before the first frame update
 
 
    // Update is called once per frame
    void Update()
    {
     
        float moveY = -4f;

        Vector2 movement = new Vector2(0, moveY);
        movement = movement.normalized * Time.deltaTime;

        transform.Translate(movement);
        if (transform.position.y <= -17.8)
        {
            transform.Translate(0,24f,0); 
        }
    }
}
