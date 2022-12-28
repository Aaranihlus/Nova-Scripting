using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public static Shop instance;
    public MenuController Menu;
    public ShopItem ShopItemPrefab;
    public Transform ItemContainer;
    public string SelectedItem;
    public Transform ItemInfo;
    public TMP_Text ItemPrice;
    public Button BuyButton;
    public GameObject Screen;
    public List<ShopItem> AvailableItems = new();

     void Awake() {
        instance = this;
    }

    private void Start() {
        BuyButton.onClick.AddListener(() => {
            List<RequestParameter> Params = new();
            Params.Add(new RequestParameter("_token", Menu.csrf_token));
            Params.Add(new RequestParameter("user_id", Menu.player.data.id));
            Params.Add(new RequestParameter("item_id", SelectedItem));
            StartCoroutine(RequestHandler.instance.Send("http://novaplayerdataserver.test/buy", Params));
        });
    }

    public void SelectItem (string id) {
        SelectedItem = id;
        ItemInfo.gameObject.SetActive(true);
        ItemPrice.gameObject.SetActive(true);
        BuyButton.gameObject.SetActive(true);

        switch ( SelectedItem ) {

            case "1":
                iTween.MoveTo(Menu.cam.gameObject, new Vector3(-0.893f, 1.627f, 11.998f), 0.8f);
                iTween.RotateTo(Menu.cam.gameObject, iTween.Hash("rotation", new Vector3(0f, 270f, 0f), "time", 0.7f));
            break;

            case "2":
                iTween.MoveTo(Menu.cam.gameObject, new Vector3(-0.893f, 2.33f, 11.998f), 0.8f);
                iTween.RotateTo(Menu.cam.gameObject, iTween.Hash("rotation", new Vector3(0f, 270f, 0f), "time", 0.7f));
            break;

        }

    }

    public void SetupShop ( ShopItemData[] Items ) {
        foreach (ShopItemData Data in Items ) {
            ShopItem instance = Instantiate(ShopItemPrefab, ItemContainer);
            instance.id = Data.id;
            instance.name = Data.name;
            instance.type = Data.type;
            instance.price = Data.price;
            instance.image.sprite = ItemManager.instance.GetSprite(instance.name);
            AvailableItems.Add(instance);
        }
    }

    public void PurchaseSuccessful (Response Response) {
        Menu.CreditsText.text = "Credits: " + Response.credits.ToString();
        Menu.player.data.credits = Response.credits;
        Item instance = ItemManager.instance.CreateItem(Response.item, Loadout.instance.StorageContainer);
        Loadout.instance.Storage.Add(instance);
    }

}
