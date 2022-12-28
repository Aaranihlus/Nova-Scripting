using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
    public string name;
    public string accepts;

    public bool ItemMatchesType (string type) {
        if (accepts == "") return true;
        if (type != accepts) return false;
        return true;
    }

}

