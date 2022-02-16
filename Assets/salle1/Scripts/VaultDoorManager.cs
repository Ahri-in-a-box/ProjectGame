using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultDoorManager : MonoBehaviour{
    public void OpenDoor(){
        float angle = this.transform.eulerAngles.y;

        if(angle <= 0.1 && angle >= -0.1)
            this.transform.Rotate(this.transform.up, 90);
    }

}
