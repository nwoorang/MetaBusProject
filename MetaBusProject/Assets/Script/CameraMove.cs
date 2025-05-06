using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
public Transform target; //따라갈 대상
public Vector3 offset; //대상과의 거리
public float smoothTime = 0.3f; //지연시간
private Vector3 velocity = Vector3.zero;

    public Vector2 minBounds;     // 카메라가 도달할 수 있는 최소 위치
    public Vector2 maxBounds;     // 카메라가 도달할 수 있는 최대 위치

void LateUpdate()
{
        // 목표 위치 = 캐릭터 위치 + 오프셋
        Vector3 desiredPosition = target.position + offset;

        // 위치 제한 적용
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // 현재 카메라 위치에서 목표 위치로 서서히 이동 (선형 보간)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothTime);

        // 카메라 위치를 부드럽게 이동한 위치로 설정
        transform.position = smoothedPosition;
}
}
