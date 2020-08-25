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

  // Scoring a point
  private void OnTriggerEnter(Collider other)
  {
    // Checking who scored the point
    if (other.gameObject.tag == "Trigger P1")
    {
      // Adding a point to player score
      FindObjectOfType<GameSession>().ScorePointP2();
      // Reseting both player positions
      foreach (var x in FindObjectsOfType<PlayerController>())
      {
        x.SetPlayerPosition();
      }
    }
    if (other.gameObject.tag == "Trigger P2")
    {
      FindObjectOfType<GameSession>().ScorePointP1();
      foreach (var x in FindObjectsOfType<PlayerController>())
      {
        x.SetPlayerPosition();
      }
    }
    // Relaunching the ball
    StartCoroutine("WaitLaunch");
  }

  // Delay for ball launch
  IEnumerator WaitLaunch()
  {
    yield return new WaitForSeconds(3.0f); // Waiting 3 seconds 
    transform.position = new Vector3(0.0f, 0.0f, 0.0f); // Reseting ball position
    LaunchBall(); // Launching the ball
  }
}
