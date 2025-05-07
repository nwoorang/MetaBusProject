using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreRecord
{
    public string playerName;
    public float score;
    public int combo;
    public float time;
    public void SetData(float score=0,int combo=0,float time=0)
    {
                this.score = score;
        this.combo = combo;
        this.time  = time;
    }
}
