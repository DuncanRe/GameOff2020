using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {
  public GameObject[] items;
  public Text[] itemsText;
  public GameObject pointer;

  // public GameObject ship;
  // public Text shipText;

  public int currentItemIndex;

  private Color selected;
  private Color unselected;

  private bool sensors = false;

  void Awake() {
    selected = new Color(0.2f, 0.4f, 1.0f, 0.75f);
    unselected = new Color(1.0f, 1.0f, 1.0f, 0.75f);

    SetItemPanelColor(0);

    sensors = false;
  }

  void Update() {
    if(sensors) {
      /*Change selected item on page up and page down button click.*/
      if(Input.GetKeyDown(KeyCode.PageUp)) {
        PrevItem();
      }
      else if(Input.GetKeyDown(KeyCode.PageDown)) {
        NextItem();
      }

      /*Point arrow towards currently selected item.*/
      if(items[currentItemIndex] != null) {
        pointer.transform.LookAt(new Vector3(items[currentItemIndex].transform.position.x, pointer.transform.position.y, items[currentItemIndex].transform.position.z));
      }    
    }
  }

  /*Check that the item collected was the one the tool is currently looking at. Move to next item if it is.*/
  public void NextItemOnCollect(string tag) {
    if(items[currentItemIndex].gameObject.tag == tag) {
      NextItem();
    }
  }

  public void NextItem() {
    /*Place holder for previous item. If it makes it back here all items have been collected.*/
    int startIndex = currentItemIndex;
    /*Increment item searching for valid item. Stop if back to start index.*/
    while(++currentItemIndex != startIndex) {
      /*If the index is too large reset.*/
      if(currentItemIndex >= items.Length) {
        currentItemIndex = 0;
      }

      /*If there is an item at the current index we can exit the function.*/
      if(items[currentItemIndex] != null) {
        SetItemPanelColor(startIndex);
        return;
      }
    }

    /*If the function makes it to this point no items were found so remove the arrow pointer.*/
    if(items[currentItemIndex] == null) {
      pointer.SetActive(false);
    }
  }

  public void PrevItem() {
    /*Place holder for previous item. If it makes it back here all items have been collected.*/
    int startIndex = currentItemIndex;
    /*Decrement item searching for valid item. Stop if back to start index.*/
    while(--currentItemIndex != startIndex) {
      /*If the index is hits 0 reset to top of list.*/
      if(currentItemIndex < 0) {
        currentItemIndex = (items.Length - 1);
      }

      /*If there is an item at the current index we can exit the function.*/
      if(items[currentItemIndex] != null) {
        SetItemPanelColor(startIndex);
        return;
      }
    }

    /*If the function makes it to this point no items were found so remove the arrow pointer.*/
    if(items[currentItemIndex] == null) {
      pointer.SetActive(false);
    }
  }

  /*Sets the current item index to a given value.*/
  public void SetItemByIndex(int index) {
    currentItemIndex = index;
  }

  /*Search for an item with a specific tag.*/
  public void SetItemByTag(string tag) {
    for(int itemIndex = 0; itemIndex < items.Length; ++itemIndex) {
      /*If tag is found set the current index and exit.*/
      if(items[itemIndex].gameObject.tag == tag) {
        currentItemIndex = itemIndex; 
        break;
      }
    }
  }

  // /*Adds the ship to the inventory list so it can be searched.*/
  // public void AddShipToInventory() {
  //   items[items.Length - 1] = ship;
  //   itemsText[itemsText.Length - 1] = shipText;
  //   shipText.gameObject.SetActive(true);
  // }

  /*Sets the flag for showing where items are along with activating the pointer.*/
  public void ActivateSensor() {
    pointer.SetActive(true);
    sensors = true;
  }

  public void SetItemPanelColor(int lastIndex) {
    itemsText[lastIndex].color = new Color(unselected.r, unselected.g, unselected.b, unselected.a);
    itemsText[currentItemIndex].color = new Color(selected.r, selected.g, selected.b, selected.a);
  }
}
