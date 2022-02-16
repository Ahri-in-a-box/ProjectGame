using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyID : MonoBehaviour{
    [SerializeField]
    private int m_Code = -1;

    public int getCode() => m_Code;
}
