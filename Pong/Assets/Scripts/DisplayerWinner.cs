using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayerWinner : MonoBehaviour
{
  // Script for displaying the winner of the match
  public TextMeshProUGUI winnerText;
  GameSession gameSession;

  private void Start()
  {
    winnerText.GetComponent<TextMeshProUGUI>();
    gameSession = FindObjectOfType<GameSession>(); // Linking to the game session to get the winner
  }

  private void Update()
  {
    winnerText.text = gameSession.GetWinner(); // Attributing the winner from the match to the text
  }
}
