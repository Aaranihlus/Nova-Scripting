using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestHandler : MonoBehaviour {

    public static RequestHandler instance;

    public void Awake() {
        instance = this;
    }

    public IEnumerator Send(string URL, List<RequestParameter> Params) {
        WWWForm Data = new();

        foreach (RequestParameter Param in Params) {
            Data.AddField(Param.Key, Param.Value);
        }

        Data.AddField("_token", MenuController.instance.csrf_token);

        UnityWebRequest Request = UnityWebRequest.Post(URL, Data);
        yield return Request.SendWebRequest();

        if (Request.result == UnityWebRequest.Result.ConnectionError) {
            MenuController.instance.RequestResponseText.text = "Error While Sending: " + Request.error;
            yield break;
        }

        Response Response = JsonUtility.FromJson<Response>(Request.downloadHandler.text);
        MenuController.instance.RequestResponseText.text = "Code: " + Response.code + " - Message: " + Response.message;

        switch ( Response.code ) {
            case 4: Authentication.instance.Login(Response.user); break;
            case 9: Authentication.instance.Initialise(Response.storage, Response.shop, Response.customisation); break;
            case 13: Shop.instance.PurchaseSuccessful(Response); break;
        }

        yield break;
    }

}
