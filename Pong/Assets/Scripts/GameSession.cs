﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
  public int score_p1 = 0, score_p2 = 0;
  public Text p1_score, p2_score;
  public TextMeshProUGUI winnerText;

  SceneLoader sceneLoader;

  private void Awake()
  {
    int gameSessionCount = FindObjectsOfType<GameSession>().Length;// If game already have a session keep that
    if (gameSessionCount > 1)
    {
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

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

    if (score_p1 >= 1)
    {
      p1_score.text = "";
      p2_score.text = "";
      winnerText.text = "Player 1 won!";

      sceneLoader.LoadNextScene();
    }
  }

  // Adding point to player 2 score
  public void ScorePointP2()
  {
    score_p2++;
    p2_score.text = score_p2.ToString();

    if (score_p2 >= 1)
    {
      p1_score.text = "";
      p2_score.text = "";
      winnerText.text = "Player 2 won!";

      sceneLoader.LoadNextScene();
    }
  }

  public string GetWinner()
  {
    if (score_p1 > score_p2)
      return "Player 1 won!";
    return "Player 2 won!";
  }

  public void PlayAgain()
  {
    Destroy(gameObject);
    sceneLoader.LoadGame();
  }
}
