using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {
  public Text infoText;

  public float displayTime = 20f;

  void Start() {
    /*Set colour to transparent so no text is shown on start.*/
    infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 0f);
    DisplayMessage();
  }

  public void DisplayMessage() {
    StartCoroutine(ShowText());
  }

  private IEnumerator ShowText() {
    infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 1f);

    yield return new WaitForSeconds(displayTime);

    infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 0f);

    gameObject.SetActive(false);
  } 
}
