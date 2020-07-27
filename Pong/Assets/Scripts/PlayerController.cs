using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public int speed;

  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
    float move = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(0.0f, 0.0f, move);

    rb.velocity = movement * speed;
  }
}
