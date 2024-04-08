using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PosDown : MonoBehaviour
{
    public TextMeshProUGUI PositionDisplay;
    [SerializeField] public Position pos;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CarPos")
        {
            pos.CarPosition++;
            PositionDisplay.GetComponent<TextMeshProUGUI>().text = "Position: " + pos.CarPosition.ToString();
        }
    }

}