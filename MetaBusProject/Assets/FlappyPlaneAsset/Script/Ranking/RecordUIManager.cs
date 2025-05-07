using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro; // TextMeshPro 쓸 경우

public class RecordUIManager : MonoBehaviour
{
    private string filePath => Application.persistentDataPath + "/score.json";

    public static RecordUIManager Instance;

    public float currentScore;
    public float highScore;

        public GameObject contentParent; // ScrollView의 Content 오브젝트
    public GameObject scoreItemPrefab; // ScoreItem 프리팹

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 게임 시작 시 최고 점수 불러오기
            highScore = PlayerPrefs.GetInt("HighScore");
        } else {
            Destroy(gameObject);
        }
    }

    // 추가점수 정렬후 저장 기능
    public void SaveScore(ScoreRecord newRecord )
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


    public void HighScore(float currentScore)
    {
        if (currentScore > highScore) {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

   public void CreateScoreBoard()
{
    // 기존에 있던 ScoreItem 오브젝트 전부 제거
    foreach (Transform child in contentParent.transform)
    {
        Destroy(child.gameObject);
    }

    var scores = LoadScores().scores;

    for (int i = 0; i < scores.Count; i++)
    {
        var record = scores[i];
        GameObject item = Instantiate(scoreItemPrefab, contentParent.transform);

        TextMeshProUGUI[] texts = item.GetComponentsInChildren<TextMeshProUGUI>();

        // 1. 순위 표시
        texts[0].text = (i + 1).ToString(); // ← 여기서 랭크 표시

        // 2. 점수, 콤보, 시간 표시
        texts[1].text = record.score.ToString("N0");
        texts[2].text = record.combo.ToString();
        texts[3].text = record.time.ToString("F1");
    }
}

    // 씬 넘어갈 때 content, prefab 재연결용
    public void InitScoreBoard(GameObject newContentParent, GameObject newItemPrefab)
    {
        contentParent = newContentParent;
        scoreItemPrefab = newItemPrefab;
    }

}
