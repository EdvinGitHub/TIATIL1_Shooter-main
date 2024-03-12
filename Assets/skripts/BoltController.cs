using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField]
  GameObject explosionPrefab;

  // Update is called once per frame
  float speed = 6;
  void Update()
  {

    Vector2 movement = new Vector2(0, speed) * Time.deltaTime;

    transform.Translate(movement);

    if (transform.position.y > Camera.main.orthographicSize + 1)
    {
      Destroy(this.gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other)  
  {
    if (other.gameObject.tag == "Boss")
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
            
            Destroy(explosion, 0.3f);

        }
  }
}
