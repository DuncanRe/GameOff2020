using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityStabilizer : MonoBehaviour {
  Movement move;

  void Start() {
    move = FindObjectOfType<Movement>();
  }

  void OnDestroy() {
    move.Stabilize(); 
  }
}
