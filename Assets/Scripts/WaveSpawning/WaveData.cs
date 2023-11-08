using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData : MonoBehaviour, IWaveProvider
{
    //[SerializeField] private Transform[] WaveChildren;

    public SpawnPoint[] GetWave(int waveNum)
    {
        var wave = transform.GetChild(waveNum);
        return wave.GetComponentsInChildren<SpawnPoint>();
    }
}
