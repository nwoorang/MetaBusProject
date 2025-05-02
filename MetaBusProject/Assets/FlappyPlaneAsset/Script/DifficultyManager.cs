using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }

    public DifficultyData difficultyData; 

    public float CurrentPlayerSpeed { get; private set; }=3;//플레이어 속도
    public float CurrentSpawnInterval { get; private set; }=10;//양옆 장애물 간 간격
    public float CurrentGapSize { get; private set; }=12; //위 아래 사이 구멍 크기
    public float CurrentScoreRate { get; private set; }=1; //점수



    private float elapsedTime = 0f;

    void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        Debug.Log("CurrentPlayerSpeed-"+CurrentPlayerSpeed);
        Debug.Log("CurrentSpawnInterval-"+CurrentSpawnInterval);
        Debug.Log("CurrentGapSize-"+CurrentGapSize);
        Debug.Log("CurrentScoreRate-"+CurrentScoreRate);
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / difficultyData.maxDifficultyTime);//maxDifficultyTime 난이도에 따른 시간가속

        CurrentPlayerSpeed = Mathf.Lerp(
            difficultyData.minPlayerSpeed,
            difficultyData.maxPlayerSpeed,
            difficultyData.playerSpeedCurve.Evaluate(t));
        CurrentSpawnInterval = Mathf.Lerp(
            difficultyData.minSpawnInterval,
            difficultyData.maxSpawnInterval,
            difficultyData.obstacleSpawnCurve.Evaluate(t));

        CurrentGapSize = Mathf.Lerp(
            difficultyData.minGapSize,
            difficultyData.maxGapSize,
            difficultyData.gapSizeCurve.Evaluate(t));

        CurrentScoreRate = Mathf.Lerp(
            difficultyData.minScoreRate,
            difficultyData.maxScoreRate,
            difficultyData.scoreRateCurve.Evaluate(t));

    }
}
