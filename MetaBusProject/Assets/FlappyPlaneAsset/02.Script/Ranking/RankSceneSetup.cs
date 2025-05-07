using UnityEngine;

public class RankSceneSetup : MonoBehaviour
{
    public GameObject contentParent;
    public GameObject scoreItemPrefab;

    void Start()
    {
        RecordUIManager.Instance.InitScoreBoard(contentParent, scoreItemPrefab);
        RecordUIManager.Instance.CreateScoreBoard();
    }
}
