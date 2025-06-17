using UnityEngine;

// Destruye este GameObject tras lifeTime segundos
public class AutoDestroy : MonoBehaviour
{
    [Tooltip("Segundos antes de destruir este objeto")]
    public float lifeTime = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
