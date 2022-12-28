using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class MenuController : MonoBehaviour {

    public string csrf_token;

    public static MenuController instance;

    public Player player;

    public GameObject Sun;

    public TMP_Text ExperienceText;
    public TMP_Text LevelText;
    public TMP_Text PlayerNameText;
    public TMP_Text CreditsText;

    public Button PlayButton;
    public Button ShopButton;
    public Button CustomisationButton;
    public Button LoadoutButton;

    public GameObject Popup;
    public TMP_Text PopupText;

    public GameObject Navigation;

    public Camera cam;

    public Authentication Authentication;
    public Shop Shop;
    public Customisation Customisation;
    public Loadout Loadout;
    public Play Play;

    public TMP_Text RequestResponseText;

    public void Start() {

        if ( csrf_token == "" ) StartCoroutine(GetToken());

        iTween.MoveTo(cam.gameObject, new Vector3(1.69f, 1.834f, 19.528f), 0.8f);
        iTween.RotateTo(cam.gameObject, iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 0.7f));

        HideAll();

        Sun.SetActive(true);

        Navigation.SetActive(false);
        Authentication.Screen.SetActive(true);

        PlayButton.onClick.AddListener(() => {
            HideAll();
            iTween.MoveTo(cam.gameObject, new Vector3(1.69f, 1.834f, 10.27f), 0.8f);
            iTween.RotateTo(cam.gameObject, iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 0.7f));
            Play.Screen.SetActive(true);
        });

        ShopButton.onClick.AddListener(() => {
            HideAll();
            iTween.MoveTo(cam.gameObject, new Vector3(0.891f, 1.834f, 12.793f), 0.8f);
            iTween.RotateTo(cam.gameObject, iTween.Hash("rotation", new Vector3(37f, 270f, 0f), "time", 0.7f));
            Shop.Screen.SetActive(true);
        });

        CustomisationButton.onClick.AddListener(() => {
            HideAll();
            iTween.MoveTo(cam.gameObject, new Vector3(0.881f, 1.834f, 13.252f), 0.8f);
            iTween.RotateTo(cam.gameObject, iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 0.7f));
            Customisation.Screen.SetActive(true);
        });

        LoadoutButton.onClick.AddListener(() => {
            HideAll();
            iTween.MoveTo(cam.gameObject, new Vector3(0.881f, 1.834f, 13.252f), 0.8f);
            iTween.RotateTo(cam.gameObject, iTween.Hash("rotation", new Vector3(0f, 0f, 0f), "time", 0.7f));
            Loadout.Screen.SetActive(true);
        });

    }

    public void Awake () {
        instance = this;
    }

    public void ShowPopup (string text) {
        //Popup.transform.position = Input.mousePosition;
        //Popup.SetActive(true);
        //PopupText.text = text;
    }

    public void HideAll() {
        Authentication.Screen.SetActive(false);
        Shop.Screen.SetActive(false);
        Customisation.Screen.SetActive(false);
        Loadout.Screen.SetActive(false);
        Play.Screen.SetActive(false);
        //Navigation.SetActive(false);
    }

    IEnumerator GetToken() {
        UnityWebRequest TokenRequest = UnityWebRequest.Get("http://novaplayerdataserver.test/get_token");
        yield return TokenRequest.SendWebRequest();

        if ( TokenRequest.result == UnityWebRequest.Result.ConnectionError || TokenRequest.result == UnityWebRequest.Result.ProtocolError ) {
            RequestResponseText.text = TokenRequest.error;
            yield break;
        }

        csrf_token = TokenRequest.downloadHandler.text;
        yield break;
    }

}
