using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;//플레이어 좌표
    [SerializeField] private Obstacle[] Obstacles;
    [SerializeField] private float firstpos_x;//처음 지점
    [SerializeField] private float Firstdistance_x;//처음 양옆 간격 지정

    int num = 0;

    DifficultyManager dm; //DifficultyManager 캐싱
    void Start() //처음 자리 배치
    {
        dm = DifficultyManager.Instance;
        Obstacles[0].transform.position = new Vector3(firstpos_x, 0, 0);
        Obstacles[0].SetPosObstacle();
        for(int i=0;i<Obstacles.Length-1;i++)
        {

             Obstacles[i+1].transform.position = Obstacles[i].transform.position + new Vector3(Firstdistance_x, 0f, 0f); //본체 옮기기
             Obstacles[i+1].SetPosObstacle();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
        //플레이어 시야 밖으로 나가면 실행
        if (PlayerPos.position.x > Obstacles[num].transform.position.x +10)
        {
            if(num==0){ //첫번째 장애물일때만 마지막 장애물의 다음 위치로 이동
            Obstacles[num].transform.position= Obstacles[Obstacles.Length-1].transform.position + new Vector3(dm.CurrentSpawnInterval, 0f, 0f);
            Obstacles[num].SetPosObstacle();
            num++; 
            return;
            }
            //나머지 장애물은 공통되게 이동
            Obstacles[num].transform.position = Obstacles[num-1].transform.position + new Vector3(dm.CurrentSpawnInterval, 0f, 0f);
            Obstacles[num].SetPosObstacle();
            num++;
            if(num>6)num=0;//배열 한사이클을 다 돌면 초기화
        }
    }


}
