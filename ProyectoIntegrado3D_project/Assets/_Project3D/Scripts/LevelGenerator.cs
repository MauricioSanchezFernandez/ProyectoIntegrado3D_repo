using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Normal Chunks")]
    public GameObject[] chunkPrefabs;

    [Header("Starting Chunks")]
    public GameObject[] startingChunks;

    public Transform player;

    public int chunksOnScreen = 5;
    public float chunkLength = 30f;

    private float spawnZ = 0;

    private List<GameObject> activeChunks = new List<GameObject>();

    private int chunksSpawned = 0;

    void Start()
    {
        for (int i = 0; i < chunksOnScreen; i++)
        {
            SpawnChunk();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - (chunksOnScreen * chunkLength))
        {
            SpawnChunk();
        }

        if (activeChunks.Count > 0)
        {
            GameObject firstChunk = activeChunks[0];

            if (player.position.z > firstChunk.transform.position.z + chunkLength)
            {
                DeleteOldChunk();
            }
        }
    }

    void SpawnChunk()
    {
        GameObject chunkToSpawn;

        // Primeros chunks fijos
        if (chunksSpawned < startingChunks.Length)
        {
            chunkToSpawn = startingChunks[chunksSpawned];
        }
        else
        {
            // Luego chunks aleatorios
            int randomIndex = Random.Range(0, chunkPrefabs.Length);

            chunkToSpawn = chunkPrefabs[randomIndex];
        }

        GameObject chunk = Instantiate(
            chunkToSpawn,
            new Vector3(0, 0, spawnZ),
            Quaternion.identity
        );

        activeChunks.Add(chunk);

        spawnZ += chunkLength;

        chunksSpawned++;
    }

    void DeleteOldChunk()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }
}