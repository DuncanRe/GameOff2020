using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
  public GameOver go;
  public string[] neededItems;

  void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player") {
      /*If any items exist exit function.*/
      foreach(string item in neededItems) {
        if(GameObject.FindGameObjectWithTag(item)) {
          return;
        }
      }

      /*If none of the items exist the player wins.*/
      go.Display();
    }
  }
}
