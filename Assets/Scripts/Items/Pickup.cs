using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {
  public Text inventoryText;

  private ItemManager im;

  public string itemName;
  public string collectMessage;

  private InfoText it;

  void Start() {
    it = FindObjectOfType<InfoText>();
    im = FindObjectOfType<ItemManager>();
  }

  /*Display a message when item can be collected.*/
  void  OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player") { 
      it.DisplayMessage("Found " + itemName + "\n(p) to pick up.");
    }
  }

  /*If inside collider check if user picks up object.*/
  void OnTriggerStay(Collider other) {
    if(other.gameObject.tag == "Player") {
      if(Input.GetKeyDown(KeyCode.P) == true) {
        /*Move locator to next item if necessary.*/
        im.NextItemOnCollect(gameObject.tag);

        /*Add to inventory.*/
        inventoryText.color = new Color(0.5f, inventoryText.color.g, 0f, inventoryText.color.a);

        /*Add effect if the item has one.*/

        /*Destroy object.*/
        Destroy(gameObject);

        /*Display message if there is one.*/
        if(collectMessage != null && (collectMessage.Length > 0)) {
          it.DisplayMessage(collectMessage);
        }
      }
    }
  }
}
