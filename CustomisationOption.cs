using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomisationOption : MonoBehaviour {

    public string id;
    public string name;
    public int level;
    public string type;
    public Image image;

    public void Equip() {
        Customisation.instance.Equip(id);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        MenuController.instance.ShowPopup(name);
    }

    public void OnPointerExit(PointerEventData eventData) {
        MenuController.instance.Popup.SetActive(false);
    }

}
