using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{

  [SerializeField]
  GameObject explosionPrefab;


  float speed = 6;
  void Update()
  {
    // vilken riktning den ska åka + hastighet 
    Vector2 movement = new Vector2(0, speed) * Time.deltaTime;
    //updaterar bolts psition 
    transform.Translate(movement);
    // kollar om bolten är under kärmen + 1
    if (transform.position.y > Camera.main.orthographicSize + 1)
    {
      //förstörden 
      Destroy(this.gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    //kollar om den nuddar bossen 
    if (other.gameObject.tag == "Boss")
    {
      //gör kola saker
      GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

      Destroy(this.gameObject);

      Destroy(explosion, 0.3f);

    }
  }
}
