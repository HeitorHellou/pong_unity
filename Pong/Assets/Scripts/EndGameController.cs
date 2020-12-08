using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
  public List<GameObject> buttons = new List<GameObject>();
  public List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

  int selection = 0; // Button and Text index

  void Start()
  {
    StartCoroutine(BlinkText()); // Blinking START text in game
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      selection++;
      if (selection > 1)
        selection = 1;
      StartCoroutine(BlinkText());
    }

    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      selection--;
      if (selection < 0)
        selection = 0;
      StartCoroutine(BlinkText());
    }

    if (Input.GetKeyDown(KeyCode.Return))
    {
      if (buttons[selection].name == "Play Again Button") // Changing the scene
        FindObjectOfType<GameSession>().PlayAgain();
      if (buttons[selection].name == "Quit Button") // Quitting application
        FindObjectOfType<SceneLoader>().QuitGame();
    }
  }

  // Blink text
  public IEnumerator BlinkText()
  {
    while (true)
    {
      if (texts[selection].name == "Play Again Text")
      {
        texts[selection].GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(.5f);
        texts[selection].GetComponent<TextMeshProUGUI>().text = "PLAY AGAIN";
        yield return new WaitForSeconds(.5f);
      }

      if (texts[selection].name == "Quit Text")
      {
        texts[selection].GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(.5f);
        texts[selection].GetComponent<TextMeshProUGUI>().text = "QUIT";
        yield return new WaitForSeconds(.5f);
      }
    }
  }
}
