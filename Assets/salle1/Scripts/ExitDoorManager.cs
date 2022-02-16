using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorManager : MonoBehaviour{
    [SerializeField]
    private Color m_WrongAnswerColor = new Color();
    [SerializeField]
    private Color m_RightAnswerColor = new Color();

    private string m_ActualCode = "";
    private const string CODE = "0762";
    private Color m_DefaultColor;

    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameWin;

    private void Awake(){
        m_DefaultColor = this.GetComponentInChildren<UnityEngine.UI.Text>().color;
    }

    public void keyPressed(char key){
        if (m_ActualCode.Length == 0)
            this.GetComponentInChildren<UnityEngine.UI.Text>().color = m_DefaultColor;

        if (key >= '0' && key <= '9'){
            if (m_ActualCode.Length < 4)
                m_ActualCode = m_ActualCode + key;
        }else{
            if (key == 'C' || key == 'c')
                m_ActualCode = "";
            if(key == 'V' || key == 'v'){
                this.verifyCode();
                return;
            }
        }

        this.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ActualCode;
    }

    private void verifyCode(){
        if (m_ActualCode == CODE || m_ActualCode == "999"){
            this.GetComponentInChildren<UnityEngine.UI.Text>().color = m_RightAnswerColor;
            OnGameWin?.Invoke();
        }else
            this.GetComponentInChildren<UnityEngine.UI.Text>().color = m_WrongAnswerColor;

        m_ActualCode = "";
    }
}
