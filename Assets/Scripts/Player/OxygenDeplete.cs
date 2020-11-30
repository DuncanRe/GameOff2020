using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenDeplete : MonoBehaviour {
  public Transform bar;
  private Image barImage;

  public GameOver go;

  public float speed;
  public bool playing;

  public bool warning;
  public bool critical;

  void Start() {
    barImage = bar.GetComponent<Image>();
  }

  void Update() {

    if(playing) {
      barImage.fillAmount -= (speed * Time.deltaTime / 100);
    }

    // barImage.color = new Color((1 - barImage.fillAmount), barImage.fillAmount, 0f, barImage.color.a);

    /*Trigger game end.*/
    if(barImage.fillAmount <= 0) {
      go.Display();
    }
    else if(!warning && !critical && barImage.fillAmount < 0.5) {
      barImage.color = new Color(0.8f, 0.9f, 0.1f, 1f);
      warning = true;
    }
    else if(!critical && warning && barImage.fillAmount < 0.25) {
      barImage.color = new Color(1f, 0.3f, 0.3f, 1f);
      critical = true;
    }
  }
}
