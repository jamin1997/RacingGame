using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarChoice : MonoBehaviour
{
    public Shader YellowBody;
    public GameObject BlueBody;
    public GameObject RedBody;
    public GameObject PurpleBody;
    public GameObject GrayBody;
    public int CarImport;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        CarImport = CarColor.CarType;
        if(CarImport == 1)
        {
            rend.material.shader = Shader.Find("AFRC_Mat_Col1");
        }
        if(CarImport == 2)
        {
            BlueBody.SetActive(true); 
        }
        if(CarImport == 3)
        {
            RedBody.SetActive(true);
        }
        if(CarImport == 4)
        {
            PurpleBody.SetActive(true);
        }
        if(CarImport== 5)
        {
            GrayBody.SetActive(true);
        }
    }

}
