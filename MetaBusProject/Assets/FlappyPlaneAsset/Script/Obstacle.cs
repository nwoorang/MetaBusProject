using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
        [SerializeField] private Transform PlayerPos;//플레이어 좌표
        [SerializeField] private GameObject UpObstacle;
        [SerializeField] private GameObject DownObstacle;
        [Range(8.8f, 12f)][SerializeField] private float Distance_y; //양쪽 장애물 사이 거리 난이도 최소,최대


        public void SetPosObstacle()
        {
                Vector3 pos = UpObstacle.transform.position; //윗장애물 위치 선정
                pos.y = Random.Range(7f,2f);
                UpObstacle.transform.position = pos;

                Vector3 pos2 = DownObstacle.transform.position; //밑장애물 위치 선정
                pos2.y = pos.y - DifficultyManager.Instance.CurrentGapSize;
                DownObstacle.transform.position = pos2;
        }
}
