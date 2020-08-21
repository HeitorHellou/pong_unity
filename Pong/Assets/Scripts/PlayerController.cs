using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;

  float zMin = -9, zMax = 9;

  private void FixedUpdate()
  {
    if (gameObject.tag == "Player")
    {
      MovePaddle("Vertical");
    }
    else
    {
      MovePaddle("Vertical2");
    }
  }

  // Checking the limits in which the player can move
  public void CheckBoundaries()
  {
    if (gameObject.tag == "Player")
    {
      if (transform.position.z < zMin)
        transform.position = new Vector3(-18.5f, 0.0f, zMin);
      if (transform.position.z > zMax)
        transform.position = new Vector3(-18.5f, 0.0f, zMax);
    }
    if (gameObject.tag == "Player 2")
    {
      if (transform.position.z < zMin)
        transform.position = new Vector3(18.5f, 0.0f, zMin);
      if (transform.position.z > zMax)
        transform.position = new Vector3(18.5f, 0.0f, zMax);
    }
  }

  public void MovePaddle(string axis)
  {
    // Moving the player (axis = Vertical for player 1 / Vertical2 for player 2
    // Since the player is Kinematic a few steps are necessary to assure it will move
    float moveZ = Input.GetAxis(axis); // Getting input from the player to move the paddle 
    Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // Getting the current paddle possition
    pos.z = moveZ; // Assining the movement on the z axis, since the camera is top - down

    transform.Translate(0, 0, pos.z * speed * Time.fixedDeltaTime); // Moving the paddle
    CheckBoundaries(); // Checking if the player didn't reach the top nor the bottom of the screen
  }

  // Setting the players position to the original position after scoring
  public void SetPlayerPosition()
  {
    if (gameObject.tag == "Player")
    {
      transform.position = new Vector3(-18.5f, 0.0f, 0.0f);
    }
    if (gameObject.tag == "Player 2")
    {
      transform.position = new Vector3(18.5f, 0.0f, 0.0f);
    }
  }
}
