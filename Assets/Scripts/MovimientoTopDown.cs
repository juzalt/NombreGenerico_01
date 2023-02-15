using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2D; // ToDo: cambiar nombre variable.
    private SpriteRenderer spi;
    IAsyncResult desacelerar;
    System.Timers.Timer timer = new(interval: 500);

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Dash()
    {
        velocidadMovimiento = 10;

        // https://josipmisko.com/posts/c-sharp-timer
        timer.Elapsed += (sender, e) => DesacelerarJugador(3);
        timer.Start();
    }

    private void DesacelerarJugador(int velocidadDeseada)
    {
        velocidadMovimiento = velocidadDeseada;
        timer.Dispose();
        timer = new(interval: 500);
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
        if (direccion[0] < 0)
        {
            spi.flipX = true;
        }
        else if (direccion[0] > 0)
        {
            spi.flipX = false;
        }
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey) && vKey == KeyCode.H)
            {
                Dash();
            }
        }
    }
}
