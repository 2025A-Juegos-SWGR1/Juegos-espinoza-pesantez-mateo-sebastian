using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject fruitPrefab;
    public float spawnInterval = 1.5f;

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
            SpawnFruit();
        }
    }

    void SpawnFruit()
    {
        Camera cam = Camera.main;
        // Escogemos aleatorio dentro del rectángulo de viewport
        float vX = Random.Range(spawnVXMin, spawnVXMax);
        float vY = Random.Range(spawnVYMin, spawnVYMax);
        // Convertimos a mundo (z = cámara near plane)
        Vector3 wp = cam.ViewportToWorldPoint(new Vector3(vX, vY, cam.nearClipPlane));
        wp.z = 0;
        Instantiate(fruitPrefab, wp, Quaternion.identity);
    }

    public void StopSpawning() => spawning = false;
}
