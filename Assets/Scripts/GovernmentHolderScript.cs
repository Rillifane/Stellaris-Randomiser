using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GovernmentHolderScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Government gov;
    public Image image1;

    public ToolTip toolTip;

    public void Start()
    {
        if (gov != null) {
            SetImage();
        }
        if (toolTip == null) {

            toolTip = GameObject.Find("ToolTipHolder").GetComponentInChildren<ToolTip>();
            Debug.Log("Tooltipholder found");
            if (toolTip == null) {
                Debug.Log("still null");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.ShowToolTip(gov);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.HideTooltip();
    }

    public void SetImage()
    {

        image1.sprite = gov.icon;
        
    }
}
