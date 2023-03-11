using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour { 
    /*public Movimiento jugador;
    public Vector3 targetPos;

    public float haciaAdelante;
    public float suavizadoCamara;
    public float offsetCamera;


    private void Start()
    {
        jugador = transform.parent.GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        SeguimientoPosicion();
    }

    private void SeguimientoPosicion()
    {
        targetPos = new Vector3(jugador.transform.position.x, jugador.transform.position.y, transform.position.z);

        if (jugador.direccion.x == 1)
        {
            targetPos = new Vector3(targetPos.x + haciaAdelante, targetPos.y, transform.position.z);
        }
        else if (jugador.direccion.x == -1)
        {
            targetPos = new Vector3(targetPos.x - haciaAdelante, targetPos.y, transform.position.z);
        }
        else if (jugador.direccion.y == 1)
        {
            targetPos = new Vector3(targetPos.x, targetPos.y + haciaAdelante, transform.position.z);
        }
        else if (jugador.direccion.y == -1)
        {
            targetPos = new Vector3(targetPos.x, targetPos.y - haciaAdelante, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, targetPos , suavizadoCamara * Time.deltaTime);
    }*/
}
