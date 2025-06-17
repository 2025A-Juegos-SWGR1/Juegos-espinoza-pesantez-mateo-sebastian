using UnityEngine;

public class FruitPickup : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        // Encuentra el GameManager en la escena
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
            Debug.LogError("No se encontró GameManager en la escena.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba que lo que chocó sea el carrito
        if (other.CompareTag("Player"))
        {
            // Notifica la recolección
            gm.CollectFruit();
            // Destruye esta fruta
            Destroy(gameObject);
        }
    }
}
