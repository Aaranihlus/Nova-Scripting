using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public static ItemManager instance;
    public Item ItemPrefab;
    public Sprite PlaceholderSprite;
    public SpriteData[] ItemSprites;

    void Awake() {
        instance = this;
    }

    public Item CreateItem ( ItemData Data, Transform AddTo ) {
        Item instance = Instantiate(ItemPrefab, AddTo);
        instance.unique_id = Data.unique_id;
        instance.item_id = Data.item_id;
        instance.name = Data.name;
        instance.price = Data.price;
        instance.type = Data.type;
        instance.image.sprite = GetSprite(instance.name);
        return instance;
    }

    public Sprite GetSprite ( string key ) {
        foreach (SpriteData sprite in ItemSprites) {
            if (sprite.item_id == key) return sprite.image;
        }
        return PlaceholderSprite;
    }

}

[System.Serializable]
public class SpriteData {
    public string item_id;
    public Sprite image;
}
