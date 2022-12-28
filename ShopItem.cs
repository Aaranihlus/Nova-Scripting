using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public string id;
    public string name;
    public string price;
    public string type;
    public Image image;

    public void Select() {
        Shop.instance.SelectItem(id);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        MenuController.instance.ShowPopup(name);
    }

    public void OnPointerExit(PointerEventData eventData) {
        MenuController.instance.Popup.SetActive(false);
    }

}
