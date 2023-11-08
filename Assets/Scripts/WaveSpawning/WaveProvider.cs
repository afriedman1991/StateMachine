using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProvider : MonoBehaviour /*IWaveProvider*/
{
    public SpawnPoint[] GetWave(int waveNum)
    {
        if (waveNum >= transform.childCount)
        {
            return null;
        }

        var childWave = transform.GetChild(waveNum);

        return childWave.GetComponentsInChildren<SpawnPoint>();
    }
}
