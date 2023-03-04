using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject playerPrefab;
    public GameObject[] randomsPoints;
    public GameObject puntoleEgido;
    private void Awake()
    {
        instance = this;
        Respawn();
    }
    private void Update()
    {
        
    }
    public void Respawn()
    {
        StopAllCoroutines();
        StartCoroutine(Count());
        Instantiate(playerPrefab, puntoleEgido.transform.position, Quaternion.identity);
        

    }

    IEnumerator Count()
    {
        for (int i = 0; i < randomsPoints.Length; i++)
        {
            var objNumber = Random.Range(0, randomsPoints.Length - 1);
            puntoleEgido = randomsPoints[objNumber];
            Debug.Log("POSICION PUNTO ELEGIDO: "+puntoleEgido.transform.position);
        }
        yield return new WaitForSeconds(2);
    }
}
