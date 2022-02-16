using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour{
    public void MovePainting(){
        this.transform.Translate(new Vector3(.0f, .0f, .5f));
    }
}
