using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadActual;
    [SerializeField] public Vector2 direccion;
    private Rigidbody2D rb2D;
    public float dashRate = 1.2f;
    public float nextDash = 0.0f;
    static float TIEMPO_REINICIO_TIMER = 50.0f;
    static float VELOCIDAD_MOVIMIENTO_DASH = 35.0f;
    private float VELOCIDAD_MOVIMIENTO_CONSTANTE = 5.0f;
    System.Timers.Timer timer = new(interval: TIEMPO_REINICIO_TIMER);

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (direccion[0] < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (direccion[0] > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey) && vKey == KeyCode.H && Time.time > nextDash)
            {
                nextDash = Time.time + dashRate;
                Dash();
            }
        }
    }

    private void Dash()
    {
        velocidadActual = VELOCIDAD_MOVIMIENTO_DASH;

        // https://josipmisko.com/posts/c-sharp-timer
        timer.Elapsed += (sender, e) => SetearVelocidadJugador(VELOCIDAD_MOVIMIENTO_CONSTANTE);
        timer.Start();
    }

    private void SetearVelocidadJugador(float velocidadDeseada)
    {
        velocidadActual = velocidadDeseada;
        timer.Dispose(); // para evitar memory leaks/overflows
        timer = new(interval: TIEMPO_REINICIO_TIMER);
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadActual * Time.fixedDeltaTime);
    }
}
