using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
  public GameObject goPanel;

  public void Display() {
    goPanel.SetActive(true);
    Cursor.lockState = CursorLockMode.None;
  }

  public void Reset() {
    goPanel.SetActive(false);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void Quit() {
    Application.Quit();
  }
}
