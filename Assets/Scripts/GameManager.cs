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
    public Action OnEnemyKilled;
    private bool gameStopped = false;

    void Awake()
    {
        Instance = this;
        waveEndTime = Time.time + waveLength;
    }

    void OnEnable()
    {
        OnWaveStart += OnWaveStarted;
    }

    void Update()
    {
        if (gameStopped) return;
        if (Time.time >= waveEndTime)
        {
            OnWaveEnd?.Invoke();
            gameStopped = true;
        }
    }

    private void OnWaveStarted()
    {
        waveEndTime = Time.time + waveLength;
    }

    public void StartWave()
    {
        OnWaveStart?.Invoke();
        gameStopped = false;
    }
}
