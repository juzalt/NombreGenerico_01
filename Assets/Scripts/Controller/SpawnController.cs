using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnController : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to the player prefab
    public Transform[] spawnPoints; // Array of spawn points for each player
    public CinemachineFreeLook cinemachineFreeLook; // Reference to the CinemachineFreeLook component

    private void SpawnPlayers(int numPlayers)
    {
        for (int i = 0; i < numPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);

            // Customize player properties if needed
            // (e.g., assign different control schemes, colors, etc.)

            // Get the Transform component of the player character
            Transform playerTransform = player.transform;

            // Assign the player's transform to the CinemachineFreeLook component
            cinemachineFreeLook.GetRig(i).LookAt = playerTransform;
            cinemachineFreeLook.GetRig(i).Follow = playerTransform;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayers(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
