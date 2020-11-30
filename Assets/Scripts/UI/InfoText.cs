using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {
  public Text infoText;
  public float fadeTime = 2f;
  public float waitTime = 3f;

  private Coroutine fadeInCo;
  private Coroutine fadeOutCo;

  void Start() {
    /*Set colour to transparent so no text is shown on start.*/
    infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 0f);
  }

  /*This method is called whenever a message should be displayed to the screen.*/
  public void DisplayMessage(string msg) {
    if(fadeInCo != null) {
      StopCoroutine(fadeInCo);
    }
    if(fadeOutCo != null) {
      StopCoroutine(fadeOutCo);
    }

    infoText.text = msg;
    fadeInCo = StartCoroutine(FadeInText());
  }

  /*Fade in the text then   call fade out function.*/
  private IEnumerator FadeInText(){
    /*Set the colour back to fully transparent.*/
    infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, 0f);

    /*Loop until text is fully visible.*/
    while(infoText.color.a < 1.0f) {
      infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, infoText.color.a + (Time.deltaTime / fadeTime));
      yield return null;
    }

    yield return waitTime;

    fadeOutCo = StartCoroutine(FadeOutText());
  }

  /*Fade out the text.*/
  private IEnumerator FadeOutText() {
    /*Loop until text is fully visible.*/
    while(infoText.color.a > 0f) {
      infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, infoText.color.a - (Time.deltaTime / fadeTime));
      yield return null;
    }
  }
}
