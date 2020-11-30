using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
  public GameObject pausePanel;
  private bool paused;

  void Update() {
    if(Input.GetKeyDown("return")) {
      /*Reset pause and add or remove panel.*/
      paused = !paused;
      pausePanel.SetActive(paused);
      
      /*Stop or start time depending on pause state.*/
      if(paused) {
        Time.timeScale = 0;
      }
      else {
        Time.timeScale = 1;
      }
    }
  }
}
