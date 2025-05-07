using UnityEngine;

[CreateAssetMenu(fileName = "NewDifficulty", menuName = "Game/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    public AnimationCurve playerSpeedCurve;
    public AnimationCurve obstacleSpawnCurve;
    public AnimationCurve gapSizeCurve;
    public AnimationCurve scoreRateCurve;


    public float maxDifficultyTime = 60f;

    public float minPlayerSpeed = 3f;
    public float maxPlayerSpeed = 10f;

    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;

    public float minGapSize = 8.8f;
    public float maxGapSize = 12f;

    public float minScoreRate = 1f;
    public float maxScoreRate = 5f;

}
