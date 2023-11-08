using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // contains a collection of waves
    public WaveData wavesAsset;
    [SerializeField] private int currentWave = 0;
    public int KillCounter = 0;


    private void Start()
    {
        //waves = GetComponent<WaveProvider>();
        Instantiate(wavesAsset, transform.position, transform.rotation, transform); // hints at what data is showing for debugging
        TrySpawn();
    }

    [ContextMenu("Spawn Current Wave")]
    public void TrySpawn()
    {
        SpawnWave(currentWave);
    }

    public void SpawnWave(int waveNum)
    {
        var spawns = wavesAsset.GetWave(waveNum);

        if (spawns != null)
        {
            foreach (var spawn in spawns)
            {
                var instance = spawn.Spawn(transform);
                KillCounter += 1;

                instance.OnKilled += OnKilled;
            }
        }
    }

    private void OnKilled(Object who)
    {
        KillCounter -= 1;

        if (KillCounter <= 0)
        {
            SpawnWave(++currentWave);
        }
    }
}
