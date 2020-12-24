using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
  public TextMeshProUGUI timer;
  public float startTime;

    // Start is called before the first frame update
    void Start()
    {
    startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
    float t = Time.time - startTime;
    string seconds = (t % 60).ToString("f1");

    timer.text = seconds;
    }
}
