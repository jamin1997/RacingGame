using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PosUp : MonoBehaviour
{
    public TextMeshProUGUI PositionDisplay;
    [SerializeField] private Position pos;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "CarPos")
        {
            if(pos.CarPosition > 1)
            {
                pos.CarPosition -= 2;
            }
            print(pos.CarPosition);
            PositionDisplay.GetComponent<TextMeshProUGUI>().text = "Position: " + pos.CarPosition.ToString();
        }
    }

}
