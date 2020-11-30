using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

  public CharacterController controller;

  public Transform groundCheck;
  public LayerMask groundMask;

  public Animator anim;

  public Vector3 velocity;

  public GameObject minimap;
  public GameObject compass;

  public float speed = 4f;
  public float stableSpeed = 7f;
  private float currentSpeed;
  public float gravity = -3.81f;
  public float groundDistance = 0.8f;
  public float jumpHeight = 3f;

  public float wakeUpTime = 7f;

  public bool isGrounded;
  public bool isMoving;
  
  public bool freeze;

  void Start() {
    controller = GetComponent<CharacterController>();
    anim = GetComponent<Animator>();

    freeze = true;

    currentSpeed = speed;

    StartCoroutine(Unfreeze(wakeUpTime));
  }

  void Update() {
    if(!freeze) {
      float x = Input.GetAxis("Horizontal");
      float z = Input.GetAxis("Vertical");

      /*Change movement based on where character is facing.*/
      Vector3 move = (transform.right * x) + (transform.forward * z);
      controller.Move(move * currentSpeed * Time.deltaTime);

      /*Check if player is on the ground. Reset velocity if he is to avoid it going down each update.*/
      isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask.value);
      if(isGrounded) {
        /*Check player jump.*/
        if(Input.GetButtonDown("Jump")) {
          velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }      
        else {
          if(velocity.y < 0) {
            velocity.y = -2f;
          }
        }
      }  

      /*Apply gravity and move player on Y axis.*/
      velocity.y += (gravity * Time.deltaTime);
      controller.Move(velocity * Time.deltaTime);
    }
  }

  public void Stabilize() {
    currentSpeed = stableSpeed;
  }

  private IEnumerator Unfreeze(float pause) {
    yield return new WaitForSeconds(pause);
    freeze = false;
    anim.enabled = false;
    // itemLocator.SetActive(true);
    minimap.SetActive(true);
    compass.SetActive(true);
    controller.enabled = true;
  }
}
