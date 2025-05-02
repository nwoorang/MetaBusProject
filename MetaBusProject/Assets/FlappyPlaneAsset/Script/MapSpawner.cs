using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;
    void Update()
    {
        if (PlayerPos.position.x >this.transform.position.x+24)
        this.transform.position+=new Vector3(48f,0,0);
    }
}
