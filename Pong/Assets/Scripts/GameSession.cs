using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Store information regarding the match
// And set up proper displays

public class GameSession : MonoBehaviour
{
  public int score_p1 = 0, score_p2 = 0; // Score player 1 and 2
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

    // Displaying the score
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
      p1_score.text = "";
      p2_score.text = "";

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
      p1_score.text = "";
      p2_score.text = "";

      sceneLoader.LoadNextScene();
    }
  }

  // Returns the winner of the match
  public string GetWinner()
  {
    if (score_p1 > score_p2) // Checking which score is higher
      return "Player 1 won!";
    return "Player 2 won!";
  }

  // On Play Againg destroy current game session
  public void PlayAgain()
  {
    Destroy(gameObject);
    sceneLoader.LoadGame();
  }
}
