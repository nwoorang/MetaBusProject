using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordUIManager : MonoBehaviour
{
   private const string PlayerNameKey = "LastPlayerName";
    private string filePath => Application.persistentDataPath + "/score.json";

    // 이름 저장
    public void SavePlayerName(string name)
    {
        PlayerPrefs.SetString(PlayerNameKey, name);
        PlayerPrefs.Save();
    }

    // 이름 불러오기
    public string LoadPlayerName()
    {
        return PlayerPrefs.GetString(PlayerNameKey, "");
    }

    // 점수 저장
    public void SaveScore(ScoreRecord newRecord)
    {
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
}
