using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour{
    private System.Diagnostics.Stopwatch m_Stopwatch = null;
    private bool m_Started = false;
    private bool m_GameIsOver = false;

    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;

    // Start is called before the first frame update
    void Start(){
        m_Stopwatch = new System.Diagnostics.Stopwatch();
        ExitDoorManager.OnGameWin += () => { m_GameIsOver = true; m_Stopwatch.Stop(); };
    }

    // Update is called once per frame
    void Update(){
        if(m_GameIsOver)
            return;

        if(!m_Started)
            m_Stopwatch.Start();

        long secondsPassed = m_Stopwatch.ElapsedMilliseconds / 1000;
        int mins = 5 - (int)(secondsPassed / 60);
        int secs = 60 - (int)(secondsPassed % 60);

        if (secs == 60)
            secs = 0;
        else
            mins--;

        this.GetComponent<UnityEngine.UI.Text>().text = $"{mins}:{secs}";

        if(mins <= 0 && secs <= 0){
            m_Stopwatch.Stop();
            m_GameIsOver = true;
            OnGameOver?.Invoke();
        }
    }
}
