using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColor : MonoBehaviour
{
    public static int CarType;
    public GameObject TrackWindow;

    public void YellowCar()
    {
        CarType = 1;
        TrackWindow.SetActive(true);
    }
    public void BlueCar()
    {
        CarType = 2;
        TrackWindow.SetActive(true);
    }
    public void RedCar()
    {
        CarType = 3;
        TrackWindow.SetActive(true);
    }
    public void PurpleCar()
    {
        CarType = 4;
        TrackWindow.SetActive(true);
    }
    public void GrayCar()
    {
        CarType = 5;
        TrackWindow.SetActive(true);
    }

}
