using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RaceFinish : MonoBehaviour
{
    public GameObject myCar;
    public GameObject FinishCam;
    public GameObject ViewModes;
    public AudioSource FinishMusic;
    public GameObject CompleteTrig;
    public AudioSource levelMusic;
    public TextMeshProUGUI FinalPosition;
    [SerializeField] private Position pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarPos")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            myCar.SetActive(false);
            CarController.motorForce = 0.0f;
            CompleteTrig.SetActive(false);
            myCar.SetActive(true);
            FinishCam.SetActive(true);
            levelMusic.Stop();
            ViewModes.SetActive(false);
            FinishMusic.Play();
            Time.timeScale = 0;
            if (pos.CarPosition == 1)
            {
                FinalPosition.GetComponent<TextMeshProUGUI>().text = "Winner!";
                FinalPosition.gameObject.SetActive(true);
            }
            else
            {
                FinalPosition.GetComponent<TextMeshProUGUI>().text = "" + pos.CarPosition;
                FinalPosition.gameObject.SetActive(true);
            }
        }
    }
}
