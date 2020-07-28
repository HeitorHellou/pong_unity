using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed, zMin, zMax;

  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
    // Moving the player
    // Since the player is Kinematic a few steps are necessary to assure it will move
    float moveZ = Input.GetAxis("Vertical") * speed; // Getting input from the player to move the paddle multiplied by it's speed

    Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // Getting the current paddle possition
    pos.z = moveZ; // Assining the movement on the z axis, since the camera is top - down

    transform.Translate(0, 0, pos.z); // Moving the paddle
    CheckBoundaries(); // Checking if the player didn't reach the top nor the bottom of the screen
  }

  // Checking the limits within the player can move
  public void CheckBoundaries()
  {
    if (transform.position.z < zMin)
      transform.position = new Vector3(-18.5f, 0.0f, zMin);
    if (transform.position.z > zMax)
      transform.position = new Vector3(-18.5f, 0.0f, zMax);

  }
}
