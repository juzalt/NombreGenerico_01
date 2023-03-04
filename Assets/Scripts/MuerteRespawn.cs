using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteRespawn : MonoBehaviour
{
    public int contador;
    public int respawn;
    public float tiempoEsperaParaMorir;
    bool flag;
    private GameObject IntanceObject;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        Debug.Log(flag);

    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTRO");
        if (other.gameObject.CompareTag("Player"))
        {
            flag = true;
            IntanceObject = other.gameObject;
            StopAllCoroutines();
            StartCoroutine(Espera());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("SALIO");
        flag = false;
    }
    public IEnumerator Espera()
    {
        if (flag == true)
        {
            yield return new WaitForSeconds(tiempoEsperaParaMorir);
            if (flag == true)
            {
                Destroy(IntanceObject);
                Debug.Log("MURIO");
                contador++;
                flag = false;
                LevelManager.instance.Respawn();

            }
        }
    }
    void FinDelJuego()
    {
        if (contador >= 3)
        {

        }
    }
}
