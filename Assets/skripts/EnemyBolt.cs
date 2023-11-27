using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBolt : MonoBehaviour
{
  // Start is called before the first frame update
  // [SerializeField]

  // Update is called once per frame
  float speed = -7;
  void Update()
  {

    Vector2 movement = new Vector2(0, speed) * Time.deltaTime;

    transform.Translate(movement);

    
    
    if (transform.position.y < -Camera.main.orthographicSize - 2)
    {
      Destroy(this.gameObject);
    }
  }
    private void OnTriggerEnter2D(Collider2D other)
    {

      if (other.gameObject.tag == "Player")
      {
        Destroy(this.gameObject);
      }

    }
}
