using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceFinish : MonoBehaviour
{
    public GameObject myCar;
    public GameObject FinishCam;
    public GameObject ViewModes;
    public AudioSource FinishMusic;
    public GameObject CompleteTrig;
    public AudioSource levelMusic;

    private void OnTriggerEnter()
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
    }
}
