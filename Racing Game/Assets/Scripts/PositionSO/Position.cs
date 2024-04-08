using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Position : ScriptableObject
{
    [SerializeField] public int position;

    public int CarPosition
    {
        get { return position; }
        set { position = value; }
    }
}
