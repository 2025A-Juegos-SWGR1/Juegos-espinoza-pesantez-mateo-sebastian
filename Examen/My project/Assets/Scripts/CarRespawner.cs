using UnityEngine;

public class CarRespawner : MonoBehaviour
{
    [Header("Ángulo máximo antes de respawn")]
    [Tooltip("Si el carrito se inclina más allá de este ángulo (en grados), se respawnea")]
    public float maxTiltAngle = 80f;

    [Header("Posición de respawn")]
    public Vector3 respawnPosition;  // si lo dejas en (0,0,0), lo tomará del Start

    private Quaternion uprightRotation;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Guardamos la posición y rotación iniciales
        respawnPosition = transform.position;
        uprightRotation = transform.rotation;
    }

    void Update()
    {
        // Calcula el ángulo de inclinación en Z
        float zAngle = transform.eulerAngles.z;
        // Convertir rango 0–360 a –180–180
        if (zAngle > 180f) zAngle -= 360f;

        if (Mathf.Abs(zAngle) > maxTiltAngle)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Parar cualquier movimiento
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Resetear posición y rotación
        transform.position = respawnPosition;
        transform.rotation = uprightRotation;
    }
}
