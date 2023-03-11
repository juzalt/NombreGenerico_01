using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public int contador;
    public float tiempoEsperaParaMorir;
    bool jugadorDentroDeArea;
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugadorDentroDeArea = false;
        Debug.Log(jugadorDentroDeArea);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTRO");
        if (other.gameObject.CompareTag("Player") && (other.GetType() == typeof(CapsuleCollider2D)))
        {
            Debug.Log("ENTROOOOOOOO");
            jugadorDentroDeArea = true;
            jugador = other.gameObject;
            StopAllCoroutines();
            StartCoroutine(Espera());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("SALIO");
        jugadorDentroDeArea = false;
    }

    public IEnumerator Espera()
    {
        if (jugadorDentroDeArea == true)
        {
            yield return new WaitForSeconds(tiempoEsperaParaMorir);
            if (jugadorDentroDeArea == true)
            {
                Destroy(jugador);
                Debug.Log("MURIO");
                contador++;
                jugadorDentroDeArea = false;
                LevelManager.instance.Spawn();

            }
        }
    }
}
