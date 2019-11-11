using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CivicHolderScript : MonoBehaviour {

    public Civic civic;
    public Image image;

    public void SetImage() {

        image.sprite = civic.icon;

    }
}
