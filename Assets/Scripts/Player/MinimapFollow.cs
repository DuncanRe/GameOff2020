using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour {
  public Transform player;
  public Vector3 offset;
  
  void Start() {
    offset = (transform.position - player.position);
  }

  void Update() {
    Vector3 moveTo = new Vector3(player.position.x, 0.0f, player.position.z);
    transform.position = Vector3.Lerp(transform.position, (moveTo + offset), 0.1f);

    Vector3 yRotate = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
    transform.rotation = Quaternion.Euler(yRotate);
  }
}
