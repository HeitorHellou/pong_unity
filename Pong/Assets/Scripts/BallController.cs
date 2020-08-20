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
  }

  // Launching the ball
  public void LaunchBall()
  {
    float dx = Random.Range(0, 2) == 0 ? -1 : 1; // Random x number to determine which side the ball will go
    float dz = Random.Range(0, 2) == 0 ? -1 : 1; // Where the ball will go in the z axis
    rb.velocity = new Vector3(-1, 0.0f, dz) * speed; // Launching the ball
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Trigger P1")
    {
      FindObjectOfType<GameSession>().ScorePointP2();
    }
    if (other.gameObject.tag == "Trigger P2")
    {
      FindObjectOfType<GameSession>().ScorePointP1();
    }
    StartCoroutine("WaitLaunch");
  }

  IEnumerator WaitLaunch()
  {
    yield return new WaitForSeconds(3.0f);
    transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    LaunchBall();
  }
}
