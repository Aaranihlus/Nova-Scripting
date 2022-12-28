using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserData {
    public string id;
    public string username;
    public int credits;
    public int experience;
    public Item chest_rig;
    public Item backpack;
    public Item primary_weapon;
    public Item secondary_weapon;
    public List<Item> inventory = new();
    public string char_skin;
    public string char_shirt;
    public string char_pants;
    public string char_boots;
    public string char_head;
}
