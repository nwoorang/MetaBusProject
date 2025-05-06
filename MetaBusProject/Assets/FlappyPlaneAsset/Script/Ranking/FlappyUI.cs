using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // ← 씬 관리용 using 문

public class FlappyUI : MonoBehaviour
{
    public TextMeshProUGUI RealTimescoreTxt; //실시간 점수
    public TextMeshProUGUI RecordscoreTxt; //기록창 점수

    public TextMeshProUGUI comboTxt;
    public TextMeshProUGUI timeTxt;

    public GameObject gameOverUI;
    DifficultyManager dm; //DifficultyManager 캐싱

    float sum=0;

    void Start()
    {
       gameOverUI.SetActive(false);
        dm = DifficultyManager.Instance;
    }
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");  // 씬 이름으로 이동
    }

    public void LoadFlappyScene()
    {
        SceneManager.LoadScene("FlappyScene");  // 씬 이름으로 이동
    }

    void Update()
    {
        sum += 0.01f + (dm.combo * dm.CurrentScoreRate) / 1000;
        RealTimescoreTxt.text = sum.ToString("N0");
    }

    public void Endgame()
    {
        gameOverUI.SetActive(true);
        RecordscoreTxt.text = sum.ToString("N0");
        comboTxt.text = dm.combo.ToString();
        timeTxt.text = dm.elapsedTime.ToString("N1");

    }

    
}
