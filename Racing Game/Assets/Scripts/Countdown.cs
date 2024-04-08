using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class Countdown : MonoBehaviour
{

    public TextMeshProUGUI CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public AudioSource Music;

    void Start()
    {
        StartCoroutine(CountStart());
    }
 

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<TextMeshProUGUI>().text = "3";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        CountDown.GetComponent<TextMeshProUGUI>().text = "2";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        CountDown.GetComponent<TextMeshProUGUI>().text = "1";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        GoAudio.Play();
        Music.Play();
        LapTimer.SetActive(true);

    }


}

