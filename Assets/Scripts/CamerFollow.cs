using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
/*    public GameObject objetoPadre;*/
    public Movimiento objetoHijo;
    public Vector3 targetPos;

    public float haciaAdelante;
    public float suavisadoCamara;
    public float offsetCamera;


    private void Start()
    {
        objetoHijo = transform.parent.GetComponent<Movimiento>();
    }
    // Update is called once per frame
    void Update()
    {
        SeguimientoPosicion();
        
    }

    private void SeguimientoPosicion()
    {
        var movimiento = objetoHijo;
        targetPos = new Vector3(movimiento.transform.position.x, movimiento.transform.position.y, transform.position.z);

        if (movimiento.direccion.x == 1)
        {
            targetPos = new Vector3(targetPos.x + haciaAdelante, targetPos.y, transform.position.z);
        }
        else if (movimiento.direccion.x == -1)
        {
            targetPos = new Vector3(targetPos.x - haciaAdelante, targetPos.y, transform.position.z);
        }
        else if (movimiento.direccion.y == 1)
        {
            targetPos = new Vector3(targetPos.x, targetPos.y - haciaAdelante, transform.position.z);
        }
        else if (movimiento.direccion.y == -1)
        {
            targetPos = new Vector3(targetPos.x, targetPos.y + haciaAdelante, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, targetPos , suavisadoCamara * Time.deltaTime);
    } 
}
