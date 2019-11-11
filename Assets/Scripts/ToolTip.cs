using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    public Text tooltipText;
    public GameObject viewPort;

    public void ShowToolTip(Government gov) {

        tooltipText.text = gov.thisName;
        viewPort.SetActive(true);
    }

    public void HideTooltip() {

        viewPort.SetActive(false);

    }
}
