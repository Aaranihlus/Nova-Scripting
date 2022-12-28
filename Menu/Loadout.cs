using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour {

    public static Loadout instance;
    public RectTransform StorageContainer;
    public GameObject Screen;
    public List<Item> Storage = new();
    public Item ItemPrefab;

    public void Awake() {
        instance = this;
    }

    public void SetupStorage(ItemData[] PlayerStorage) {
        Debug.Log(PlayerStorage);
        if (PlayerStorage.Length == 0) return;
        foreach (ItemData Data in PlayerStorage) {
            Item instance = ItemManager.instance.CreateItem(Data, StorageContainer);
            Storage.Add(instance);
        }
    }

}
