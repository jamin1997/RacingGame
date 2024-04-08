using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateFinish : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0.25f, 0);
    }
}
