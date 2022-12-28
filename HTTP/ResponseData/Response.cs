using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Response {
    public int code;
    public string message;
    public UserData user;
    public ItemData[] storage;
    public ShopItemData[] shop;
    public CustomisationOptionData[] customisation;
    public int credits;
    public ItemData item;
}
