using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerVitals PlayerVital;
    public ObjectPooler Pooler;
    public float waveLength;
    private float waveEndTime;
    public Action OnWaveEnd;
    public Action OnWaveStart;

    private bool gameStopped = false;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(gameStopped) return;
        if (Time.time >= waveEndTime)
        {
            OnWaveEnd?.Invoke();
            gameStopped = true;
        }
    }
}
