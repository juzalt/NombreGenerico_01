using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2D; // ToDo: cambiar nombre variable.

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
