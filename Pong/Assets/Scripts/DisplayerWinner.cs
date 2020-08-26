using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayerWinner : MonoBehaviour
{
  public TextMeshProUGUI winnerText;
  GameSession gameSession;

  private void Start()
  {
    winnerText.GetComponent<TextMeshProUGUI>();
    gameSession = FindObjectOfType<GameSession>();
  }

  private void Update()
  {
    winnerText.text = gameSession.GetWinner();
  }
}
