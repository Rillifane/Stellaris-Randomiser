using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EthosHolderScript : MonoBehaviour {

    public Ethos ethos;
    public Image image;

    public void SetImage()
    {

        image.sprite = ethos.icon;

    }
}
