using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefabObj;
    public float Radius = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnPlayerRandom();
    }

    void SpawnPlayerRandom()
    {
        Vector2 randomPos = Random.insideUnitCircle * Radius;
        Vector2 randomthis = this.transform.position;
        Instantiate(prefabObj, randomthis+randomPos, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
