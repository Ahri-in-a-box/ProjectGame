using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour{

    private System.Diagnostics.Stopwatch m_Stopwatch = null;
    private bool m_Started = false;
    private bool m_GameIsOver = false;

    // Start is called before the first frame update
    void Start(){
        m_Stopwatch = new System.Diagnostics.Stopwatch();
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
            //Emite game over event
            m_Stopwatch.Stop();
            m_GameIsOver = true;
        }
    }
}
