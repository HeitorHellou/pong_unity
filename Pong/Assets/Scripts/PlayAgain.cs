using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
