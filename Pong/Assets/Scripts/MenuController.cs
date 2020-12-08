using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
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
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      selection++;
      if (selection > 1)
        selection = 1;
      StartCoroutine(BlinkText());
    }

    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      selection--;
      if (selection < 0)
        selection = 0;
      StartCoroutine(BlinkText());
    }

    if (Input.GetKeyDown(KeyCode.Return))
    {
      if (buttons[selection].name == "Start Game Button") // Changing the scene
        FindObjectOfType<SceneLoader>().LoadNextScene();
      if (buttons[selection].name == "Exit Game Button") // Quitting application
        FindObjectOfType<SceneLoader>().QuitGame();
    }
  }

  // Blink text
  public IEnumerator BlinkText()
  {
    while (true)
    {
      if (texts[selection].name == "Start Game Text")
      {
        texts[selection].GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(.5f);
        texts[selection].GetComponent<TextMeshProUGUI>().text = "START";
        yield return new WaitForSeconds(.5f);
      }

      if (texts[selection].name == "Exit Game Text")
      {
        texts[selection].GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(.5f);
        texts[selection].GetComponent<TextMeshProUGUI>().text = "EXIT";
        yield return new WaitForSeconds(.5f);
      }
    }
  }
}
