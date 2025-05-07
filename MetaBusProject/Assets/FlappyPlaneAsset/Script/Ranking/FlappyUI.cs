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

    public TextMeshProUGUI TireTxt;
    float sum = 0;

    public bool isGameOver; //Update() 구문 제어
    void Start()
    {
        isGameOver = false;
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
        if (isGameOver)
            return;

        sum += 0.01f + (dm.combo * dm.CurrentScoreRate) / 1000;
        RealTimescoreTxt.text = sum.ToString("N0");
    }

    public void Endgame()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
        RecordscoreTxt.text = sum.ToString("N0");
        comboTxt.text = dm.combo.ToString();
        timeTxt.text = dm.elapsedTime.ToString("N1");
        if (sum < 10) TireTxt.text = "F";
        else if (sum < 100) TireTxt.text = "E";
        else if (sum < 300) TireTxt.text = "D";
        else if (sum < 800) TireTxt.text = "C";
        else if (sum < 1300) TireTxt.text = "B";
        else if (sum < 2000) TireTxt.text = "A";
        else if (sum < 2500) TireTxt.text = "S";

        ScoreRecord scoreRecord= new ScoreRecord();
        scoreRecord.SetData(sum,dm.combo,dm.elapsedTime);
         RecordUIManager.Instance.HighScore(sum);
         RecordUIManager.Instance.SaveScore(scoreRecord);
        RecordUIManager.Instance.CreateScoreBoard();
    }


}
