using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordUIManager : MonoBehaviour
{
    private string filePath => Application.persistentDataPath + "/score.json";

    public static RecordUIManager Instance;

    public float currentScore;
    public float highScore;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 게임 시작 시 최고 점수 불러오기
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        } else {
            Destroy(gameObject);
        }
    }

    // 추가점수 정렬후 저장 기능
    public void SaveScore()
    {
        ScoreRecord newRecord = new ScoreRecord();
        if (PlayerPrefs.HasKey("Record"))// Record 있음
        {
            string savedInfo = PlayerPrefs.GetString("Record");
            string[] infoParts = savedInfo.Split(',');

            float.TryParse(infoParts[0], out float Recordscore);
            int.TryParse(infoParts[1], out int combo);
            float.TryParse(infoParts[2], out float time);
            newRecord.SetData(Recordscore, combo, time);
        }

        ScoreList list = LoadScores(); // 기존 점수 불러오기
        list.scores.Add(newRecord);
        list.scores.Sort((a, b) => b.score.CompareTo(a.score)); // 내림차순 정렬

        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(filePath, json);
    }

    // 점수 불러오기
    public ScoreList LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ScoreList>(json);
        }

        return new ScoreList(); // 처음엔 빈 리스트
    }


    public void HighScore(float currentScore)
    {
        if (currentScore > highScore) {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
