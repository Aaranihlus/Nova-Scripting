using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Authentication : MonoBehaviour {

    public MenuController Menu;
    public static Authentication instance;
    public Button LoginButton;
    public Button RegisterButton;
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public GameObject Screen;

    private void Awake() {
        instance = this;
    }

    void Start() {
        LoginButton.onClick.AddListener(() => {
            List<RequestParameter> Params = new();
            Params.Add(new RequestParameter("Username", UsernameInput.text));
            Params.Add(new RequestParameter("Password", PasswordInput.text));
            StartCoroutine(RequestHandler.instance.Send("http://novaplayerdataserver.test/user/get", Params));
        });

        RegisterButton.onClick.AddListener(() => {
            List<RequestParameter> Params = new();
            Params.Add(new RequestParameter("Username", UsernameInput.text));
            Params.Add(new RequestParameter("Password", PasswordInput.text));
            StartCoroutine(RequestHandler.instance.Send("http://novaplayerdataserver.test/user/create", Params));
        });
    }

    public void Login(UserData Data) {
        Menu.player.data = Data;
        Menu.PlayerNameText.text = Data.username;
        Menu.CreditsText.text = "Credits: " + Data.credits.ToString();
        Menu.ExperienceText.text = "Experience: " + Data.experience.ToString();
        Menu.LevelText.text = "Level: 1";
        //Customisation.instance.UpdateCharacterModel();
        List<RequestParameter> Params = new();
        Params.Add(new RequestParameter("user_id", Menu.player.data.id));
        StartCoroutine(RequestHandler.instance.Send("http://novaplayerdataserver.test/startup", Params));
    }

    public void Initialise(ItemData[] storage, ShopItemData[] shop, CustomisationOptionData[] customisation) {
        Menu.Loadout.SetupStorage(storage);
        Menu.Shop.SetupShop(shop);
        Menu.Customisation.SetupCustomisation(customisation);
        Menu.Navigation.SetActive(true);
        Menu.Play.Screen.SetActive(true);
        Menu.Sun.SetActive(false);
        Menu.cam.transform.SetPositionAndRotation(new Vector3(1.69f, 1.834f, 10.27f), new Quaternion(0f, 0f, 0f, 0f));
        Screen.SetActive(false);
    }

}
