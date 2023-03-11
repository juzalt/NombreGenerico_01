using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject playerPrefab;
    public GameObject[] randomsPoints;
    public GameObject puntoElegido;
    private float TIEMPO_ESPERA_RESPAWN = 2.0f;
    private void Awake()
    {
        instance = this;
        Spawn();
    }

    public void Spawn()
    {
        StopAllCoroutines();
        StartCoroutine(ElegirPosicionSpawn());
        Instantiate(playerPrefab, puntoElegido.transform.position, Quaternion.identity);
    }

    IEnumerator ElegirPosicionSpawn()
    {
        for (int i = 0; i < randomsPoints.Length; i++)
        {
            var objNumber = Random.Range(0, randomsPoints.Length - 1);
            puntoElegido = randomsPoints[objNumber];
            Debug.Log("POSICION PUNTO ELEGIDO: "+puntoElegido.transform.position);
        }
        yield return new WaitForSeconds(TIEMPO_ESPERA_RESPAWN);
    }
}
