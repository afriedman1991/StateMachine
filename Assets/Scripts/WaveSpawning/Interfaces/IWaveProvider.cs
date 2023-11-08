using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveProvider
{
    // Exposes this method to get the current wave
    public SpawnPoint[] GetWave(int waveNum);
}
