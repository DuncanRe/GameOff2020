using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {
  public Transform playerBody;

  public float mouseSensitivity = 100f;

  public float xRotation = 0f;

  public float wakeUpTime = 7f;

  public bool freeze;

  void Start() {
    /*Hide cursor.*/
    Cursor.lockState = CursorLockMode.Locked;
    freeze = true;

    StartCoroutine(Unfreeze(wakeUpTime));
  }

  void Update() {
    if(!freeze) {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
      
      xRotation -= mouseY;
      /*Do not rotate behind player.*/
      xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      /*Rotate the player object since camera is attached.*/
      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
      playerBody.Rotate(Vector3.up * mouseX);
    }
  }

  private IEnumerator Unfreeze(float pause) {
    yield return new WaitForSeconds(pause);
    freeze = false;
  }  
}
