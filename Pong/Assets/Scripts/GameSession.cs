﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
  public int score_p1 = 0, score_p2 = 0;
  public Text p1_score, p2_score;

  SceneLoader sceneLoader;

  private void Start()
  {
    sceneLoader = FindObjectOfType<SceneLoader>();

    p1_score.text = score_p1.ToString();
    p2_score.text = score_p2.ToString();
  }

  // Adding point to player 1 score
  public void ScorePointP1()
  {
    score_p1++;
    p1_score.text = score_p1.ToString();

    if (score_p1 >= 5)
    {
      sceneLoader.LoadNextScene();
    }
  }

  // Adding point to player 2 score
  public void ScorePointP2()
  {
    score_p2++;
    p2_score.text = score_p2.ToString();

    if (score_p2 >= 5)
    {
      sceneLoader.LoadNextScene();
    }
  }
}
