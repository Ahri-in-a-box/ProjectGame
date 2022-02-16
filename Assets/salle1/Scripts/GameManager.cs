using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    [SerializeField]
    private Canvas m_GameOverCanvas = null;
    [SerializeField]
    private UnityEngine.UI.Text m_FinishText = null;
    [SerializeField]
    private GameObject m_Roof = null;

    void Awake(){
        Timer.OnGameOver += GameOver;
        ExitDoorManager.OnGameWin += GameWin;

        if (m_Roof && !m_Roof.activeSelf)
            m_Roof.SetActive(true);

        if (!m_GameOverCanvas)
            throw new System.Exception("No Game Over Canvas set");
    }

    private void GameOver(){
        if(m_FinishText)
            m_FinishText.text = "Blocked";
        m_GameOverCanvas.gameObject.SetActive(true);
    }

    private void GameWin(){
        if(m_FinishText)
            m_FinishText.text = "Escaped";
        m_GameOverCanvas.gameObject.SetActive(true);
    }

    public void mainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    private void OnDestroy(){
        Timer.OnGameOver -= GameOver;
        ExitDoorManager.OnGameWin -= GameWin;
    }
}
