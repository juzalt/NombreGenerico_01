using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomListObj : MonoBehaviour
{
    public GameObject[] randomsPoints;
    public GameObject objetoElegido;

    void Start()
    {
        StopAllCoroutines();
        StartCoroutine(Count());
    }
    IEnumerator Count()
    {
        for (int i = 0; i < randomsPoints.Length; i++)
        {
            var objNumber = Random.Range(0, randomsPoints.Length - 1);
            objetoElegido = randomsPoints[objNumber];
            Debug.Log(objetoElegido);
        }
        yield return new WaitForSeconds(2);
    }
}
