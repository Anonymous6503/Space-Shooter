using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "new Wave Config")]
public class WaveConfigSo : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float timeBetweenEnemySpawns = 1f;
    [SerializeField] private float spawnTimeVariance = 0f;
    [SerializeField] private float minSpawnTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
            timeBetweenEnemySpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
