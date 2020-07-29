using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  public float speed;

  Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>(); // Linking the rigidbody
    LaunchBall(); // Launching the ball
    Debug.Log(rb.velocity.magnitude);
  }

  // Adjusting the ball speed and direction after colliding with an object 
  private void OnCollisionEnter(Collision collision)
  {
    // Since the wall are above or below the ball make the calcs with the z axis
    if (collision.gameObject.tag == "Wall")
    {
      if (transform.position.z > collision.transform.position.z)
      {
        rb.AddForce(transform.forward.normalized * speed, ForceMode.Impulse);
      }
      if (transform.position.z < collision.transform.position.z)
      {
        rb.AddForce(transform.forward.normalized * -speed, ForceMode.Impulse);
      }
    }

    // As the player will be on it's side (right, or left) make the calcs with the x axis
    if (collision.gameObject.tag == "Player")
    {
      if (transform.position.x > collision.transform.position.x)
      {
        rb.AddForce(transform.right.normalized * speed, ForceMode.Impulse);
      }
      if (transform.position.x < collision.transform.position.x)
      {
        rb.AddForce(transform.right.normalized * -speed, ForceMode.Impulse);
      }
    }
    Debug.Log(rb.velocity.magnitude);
  }

  public void LaunchBall()
  {
    rb.velocity = new Vector3(-1.0f, 0.0f, Random.Range(-3.0f, 3.0f)) * speed;
  }
}
