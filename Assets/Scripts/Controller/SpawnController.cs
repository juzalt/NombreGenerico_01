//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public class SpawnController : MonoBehaviour
//{
//    public GameObject playerPrefab; // Reference to the player prefab
//    public Transform[] spawnPoints; // Array of spawn points for each player
//                                    //public CinemachineFreeLook cinemachineFreeLook; // Reference to the CinemachineFreeLook component

//    private void SpawnPlayers(int numPlayers)
//    {
//        for (int i = 0; i < numPlayers; i++)
//        {
//            string layerName = $"Player{i + 1}";
//            int layer = LayerMask.NameToLayer(layerName);

//            GameObject player = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);
//            player.layer = layer;

//            // Customize player properties if needed
//            // (e.g., assign different control schemes, colors, etc.)
//            GameObject cameraObject = new GameObject("PlayerCamera");
//            Camera playerCamera = cameraObject.AddComponent<Camera>();
//            playerCamera.transform.SetParent(player.transform); // Set the player object as the parent

//            // Adjust the position and rotation of the camera relative to the player object
//            cameraObject.transform.localPosition = new Vector3(0f, 2f, -5f); // Example position
//            cameraObject.transform.localRotation = Quaternion.identity; // Example rotation

//            // Assign the camera to the player object
//            CharacterMovement CharacterMovement = player.GetComponent<CharacterMovement>();
//            if (CharacterMovement != null)
//            {
//                playerCamera = GetComponent<Camera>();
//            }

//            // Get the Transform component of the player character
//            Transform playerTransform = player.transform;


//            // Assign the player's transform to the CinemachineFreeLook component
//            cinemachineFreeLook.GetRig(i).LookAt = playerTransform;
//            cinemachineFreeLook.GetRig(i).Follow = playerTransform;
//        }
//    }


//    // Start is called before the first frame update
//    void Start()
//    {
//        SpawnPlayers(2);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
