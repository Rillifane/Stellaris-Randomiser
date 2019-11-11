using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitHolderScript : MonoBehaviour {

    public Traits firstTrait;
    public Traits secondTrait;
    public Image image1;
    public Image image2;

    public void SetImage()
    {

        image1.sprite = firstTrait.icon;
        image2.sprite = secondTrait.icon;

    }
}
