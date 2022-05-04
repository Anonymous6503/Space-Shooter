using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSo> WaveConfigs;
    [SerializeField] private WaveConfigSo currentWave;

    [SerializeField] private float timeBetweenWaves = 0f;

    [SerializeField] private bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSo wave in WaveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position,
                        Quaternion.Euler(0,0,180),
                        transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
        
    }
    
    public WaveConfigSo GetCurrentWave()
    {
        return currentWave;
    }
}
