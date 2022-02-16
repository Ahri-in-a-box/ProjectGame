using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorManager : MonoBehaviour{
    private string m_ActualCode = "";
    private const string CODE = "0762"; 

    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameWin;

    public void keyPressed(char key){
        if (key >= '0' && key <= '9'){
            if (m_ActualCode.Length < 4)
                m_ActualCode = m_ActualCode + key;
        }else{
            if (key == 'C' || key == 'c')
                m_ActualCode = "";
            if(key == 'V' || key == 'v')
                this.verifyCode();
        }

        this.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ActualCode;
    }

    private void verifyCode(){
        if (m_ActualCode == CODE || m_ActualCode == "999")
            OnGameWin?.Invoke();
    }
}
