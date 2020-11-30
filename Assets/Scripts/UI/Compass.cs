using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {
  public Transform player;

  void Update() {
    /*The player's Y rotation modifies the inverted Z rotation.*/
    Vector3 zRotate = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -player.transform.eulerAngles.y);
    transform.rotation = Quaternion.Euler(zRotate);
  }
}
