using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTank : MonoBehaviour {
  public Image barImage;

  void OnDestroy() {
    barImage.fillAmount += 0.5f;
  }
}
