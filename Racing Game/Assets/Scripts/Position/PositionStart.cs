using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PositionStart : MonoBehaviour
{

    [SerializeField] private Position pos;
    public int start;

    public void Start()
    {
        SetPosition(start);
    }

    void SetPosition(int start)
    {
        pos.CarPosition = start;
    }

}
