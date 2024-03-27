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
    Vector2 rotation = transform.position - player.transform.position;
    body.velocity = new Vector3(diraction.x, diraction.y, body.rotation).normalized * speed;
    transform.up = rotation;




  }

  // Update is called once per frame
  void Update()
  {
    if (Mathf.Abs(transform.position.x) > Camera.main.orthographicSize * Camera.main.aspect - 0.5 || Mathf.Abs(transform.position.y) > Camera.main.orthographicSize * Camera.main.aspect - 0.5)
    {
      GameObject.Destroy(this.gameObject);

    }
  }
}
