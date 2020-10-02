using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set up the session for a rematch

public class PlayAgain : MonoBehaviour
{
  GameSession gameSession;

  private void Start()
  {
    gameSession = FindObjectOfType<GameSession>();
  }

  public void Restart()
  {
    gameSession.PlayAgain();
  }
}
