using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour{
    [SerializeField]
    private ExitDoorManager m_ExitDoorManager = null;

    // Start is called before the first frame update
    void Start(){
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnTaskClick);
    }

    void OnTaskClick(){
        m_ExitDoorManager?.keyPressed(this.GetComponentInChildren<UnityEngine.UI.Text>().text[0]);
    }
}
