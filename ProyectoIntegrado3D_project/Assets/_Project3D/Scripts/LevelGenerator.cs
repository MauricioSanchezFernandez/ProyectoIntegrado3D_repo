using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] chunkPrefabs;
    public Transform player;

    public int chunksOnScreen = 5;
    public float chunkLength = 30f;

    private float spawnZ = 0;

    private List<GameObject> activeChunks = new List<GameObject>();

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
        // Elegir chunk aleatorio
        int randomIndex = Random.Range(0, chunkPrefabs.Length);

        GameObject chunk = Instantiate(
            chunkPrefabs[randomIndex],
            new Vector3(0, 0, spawnZ),
            Quaternion.identity
        );

        activeChunks.Add(chunk);

        spawnZ += chunkLength;
    }

    void DeleteOldChunk()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }
}