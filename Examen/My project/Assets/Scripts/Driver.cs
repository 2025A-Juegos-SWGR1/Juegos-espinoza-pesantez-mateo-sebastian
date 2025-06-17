using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Driver : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;    // <--- referencia al sprite

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();  // <--- obtenemos el sprite
    }

    void Update()
    {
        // 1. Movimiento horizontal
        float h = Input.GetAxis("Horizontal"); // A/D o flechas
        rb.linearVelocity = new Vector2(h * speed, rb.linearVelocity.y);

        // 2. Girar el sprite según la dirección
        if (h > 0f)
            sr.flipX = false;    // mira a la derecha
        else if (h < 0f)
            sr.flipX = true;     // mira a la izquierda

        // 3. Salto
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
