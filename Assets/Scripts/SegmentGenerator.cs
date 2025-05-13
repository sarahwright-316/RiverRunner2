using UnityEngine;
using System.Collections.Generic;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    public Transform player;

    private float zPos = 300f;
    private float nextTriggerZ = 0f;
    private float segmentLength = 50f;

    private List<GameObject> activeSegments = new List<GameObject>(); // track spawned segments

    void Update()
    {
        // Spawn new segment if player has reached next trigger point
        while (player.position.z >= nextTriggerZ)
        {
            SpawnSegment();
            nextTriggerZ += segmentLength;
            zPos += segmentLength;
        }

        CleanupSegments();
    }

    void SpawnSegment()
    {
        int segmentNum = Random.Range(0, segment.Length);
        Vector3 spawnPos = new Vector3(0, 0, zPos);
        GameObject newSegment = Instantiate(segment[segmentNum], spawnPos, Quaternion.identity);
        activeSegments.Add(newSegment);

        //Debug.Log($"Spawned segment {segmentNum} at z = {spawnPos.z}");
    }

    void CleanupSegments()
    {
        // Only check the first segment in the list (oldest one)
        if (activeSegments.Count == 0) return;

        GameObject oldest = activeSegments[0];

        // If player is more than one segment past this segment
        if (player.position.z > oldest.transform.position.z + segmentLength)
        {
            Destroy(oldest);
            activeSegments.RemoveAt(0);
        }
    }
}



