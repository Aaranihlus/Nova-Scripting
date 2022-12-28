using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public string unique_id;
    public string item_id;
    public string name;
    public string price;
    public string type;
    public Image image;
    public Transform DraggingFrom;

    public void OnPointerEnter(PointerEventData eventData) {
        MenuController.instance.ShowPopup(name);
    }

    public void OnPointerExit(PointerEventData eventData) {
        MenuController.instance.Popup.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        DraggingFrom = transform.parent.transform;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Slot target = eventData.pointerEnter.GetComponent<Slot>();

        if ( target.name == DraggingFrom.GetComponent<Slot>().name || target == null || !target.GetComponent<Slot>().ItemMatchesType(type)) {
            MoveItem(DraggingFrom.gameObject);
            return;
        }

        MoveItem(target.gameObject);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        DraggingFrom = null;
    }

    public void MoveItem ( GameObject target ) {

        switch ( target.name ) {
            case "PrimaryWeapon": MenuController.instance.player.data.primary_weapon = this; break;
            case "SecondaryWeapon": MenuController.instance.player.data.secondary_weapon = this; break;
            case "Chestrig": MenuController.instance.player.data.chest_rig = this; break;
            case "Backpack": MenuController.instance.player.data.backpack = this; break;
            case "Inventory": MenuController.instance.player.data.inventory.Add(this); break;
        }

        transform.SetParent(target.transform);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        if (target.transform.name == "Storage") LayoutRebuilder.ForceRebuildLayoutImmediate(Loadout.instance.StorageContainer);

    }

}
