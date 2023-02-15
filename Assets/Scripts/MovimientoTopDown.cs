using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float velocidadActual;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private int mana = 10; // labios compartidos
    static int TIEMPO_REINICIO_TIMER = 50;
    static int VELOCIDAD_MOVIMIENTO_DASH = 35;
    System.Timers.Timer timer = new(interval: TIEMPO_REINICIO_TIMER);

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(mana);
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Dash()
    {
        velocidadActual = VELOCIDAD_MOVIMIENTO_DASH;

        // https://josipmisko.com/posts/c-sharp-timer
        timer.Elapsed += (sender, e) => SetearVelocidadJugador(3);
        timer.Start();
    }

    private void SetearVelocidadJugador(int velocidadDeseada)
    {
        velocidadActual = velocidadDeseada;
        timer.Dispose(); // para evitar memory leaks/overflows
        timer = new(interval: TIEMPO_REINICIO_TIMER);
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadActual * Time.fixedDeltaTime);
        if (direccion[0] < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direccion[0] > 0)
        {
            spriteRenderer.flipX = false;
        }
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey) && vKey == KeyCode.H)
            {
                Debug.Log(mana);
                if (mana > 2)
                {
                    Debug.Log("bajo mana");
                    mana = mana - 10;
                    Dash();
                }
            }
        }

        if (mana < 10)
        {
            Debug.Log("subo mana");
            mana = mana + 1; 
        }
    }
}
