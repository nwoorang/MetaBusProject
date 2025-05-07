using UnityEngine;

[System.Serializable]
public class WeightedGameObject //가중치와 해당 오브젝트
{
    public GameObject prefab;
    public float weight = 1f;
}

[CreateAssetMenu(fileName = "NewWeightedTable", menuName = "Game/Weighted Table")]
public class WeightedTable : ScriptableObject
{
    public WeightedGameObject[] objects;

    public GameObject GetRandom()
    {
        float totalWeight = 0f;
        foreach (var obj in objects)//가중치의 총합을 계산,각 오브젝트들은 순서대로 가중치 자리를 가짐
        {
            totalWeight += obj.weight; 
        }

        float rand = Random.Range(0f, totalWeight);//총 가중치에서 랜덤값을 뽑음
        float current = 0f;

        foreach (var obj in objects)//순차적으로 오브젝트들의 가중치를 더해주면서 랜덤값보다 초과했을때 해당 오브젝트를 반환
        {
            current += obj.weight;
            if (rand < current)
            {
                Debug.Log(obj.prefab.tag);
                return obj.prefab;
            }
        }

        return null;
    }
}
