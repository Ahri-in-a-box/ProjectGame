using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagicCubeManager : MonoBehaviour{
    public void OnOjectPlaced(SelectEnterEventArgs args){
        string val = "Unknown error";

        ToyID toy = args.interactableObject.transform.GetComponent<ToyID>();

        if (toy)
            if (toy.getCode() >= 0 && toy.getCode() <= 9)
                val = toy.getCode().ToString();
            else
                val = "Unknown Object";

        this.GetComponent<UnityEngine.UI.Text>().text = val;
    }

    public void OnOjectRemoved(SelectExitEventArgs args){
        this.GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
