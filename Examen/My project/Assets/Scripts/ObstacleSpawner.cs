using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2.5f;

    [Header("Rango viewport horizontal")]
    [Range(0f,1f)] public float spawnVXMin = 0.1f;
    [Range(0f,1f)] public float spawnVXMax = 0.9f;

    [Header("Rango viewport vertical")]
    [Range(0f,1f)] public float spawnVYMin = 0.1f;
    [Range(0f,1f)] public float spawnVYMax = 0.5f;

    private bool spawning = true;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        Camera cam = Camera.main;
        float vX = Random.Range(spawnVXMin, spawnVXMax);
        float vY = Random.Range(spawnVYMin, spawnVYMax);
        Vector3 wp = cam.ViewportToWorldPoint(new Vector3(vX, vY, cam.nearClipPlane));
        wp.z = 0;

        int idx = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[idx], wp, Quaternion.identity);
    }

    public void StopSpawning() => spawning = false;
}
