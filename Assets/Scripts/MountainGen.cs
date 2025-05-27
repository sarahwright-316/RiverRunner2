using UnityEngine;
using System.Collections.Generic;

public class MountainGenerator : MonoBehaviour
{
    public GameObject[] mountainPrefabs;   // Mountain prefabs to randomly spawn
    public Transform player;               // Reference to the player

    private float mountainLength = 250f;   // 5x regular segment length (assuming 50 units each)
    private float zPos;                    // Z-position to spawn next mountain
    private float nextTriggerZ;            // When to trigger next mountain spawn

    private List<GameObject> activeMountains = new List<GameObject>();

    void Start()
    {
        // Start spawning mountains 300 units ahead of player's start position
        zPos = player.position.z + 300f;
        nextTriggerZ = player.position.z + 100f;
    }

    void Update()
    {
        // Spawn mountains when player crosses next trigger point
        while (player.position.z >= nextTriggerZ)
        {
            SpawnMountain();
            nextTriggerZ += mountainLength;
            zPos += mountainLength;
        }

        CleanupMountains();
    }

    void SpawnMountain()
    {
        int index = Random.Range(0, mountainPrefabs.Length);
        Vector3 spawnPos = new Vector3(0, 0, zPos); // Adjust x if mountains should be off-road
        GameObject mountain = Instantiate(mountainPrefabs[index], spawnPos, Quaternion.identity);
        activeMountains.Add(mountain);
    }

    void CleanupMountains()
    {
        if (activeMountains.Count == 0) return;

        GameObject oldest = activeMountains[0];
        if (player.position.z > oldest.transform.position.z + mountainLength)
        {
            Destroy(oldest);
            activeMountains.RemoveAt(0);
        }
    }
}
