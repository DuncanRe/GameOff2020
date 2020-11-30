using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSensor : MonoBehaviour {
  ItemManager im;

  void Start() {
    im = FindObjectOfType<ItemManager>();
  }

  void OnDestroy() {
    im.ActivateSensor(); 
  }
}
