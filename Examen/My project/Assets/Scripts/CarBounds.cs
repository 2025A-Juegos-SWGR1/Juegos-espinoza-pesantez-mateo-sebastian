using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CarBounds : MonoBehaviour
{
    [Tooltip("Margen en unidades antes de los bordes de la cámara")]
    public float horizontalMargin = 0.5f;

    float minX, maxX;

    void Start()
    {
        Camera cam = Camera.main;
        // Altura y ancho a mitad de pantalla en unidades de mundo
        float halfHeight = cam.orthographicSize;
        float halfWidth  = halfHeight * cam.aspect;

        // Calcula los límites X según posición de la cámara
        float camX = cam.transform.position.x;
        minX = camX - halfWidth + horizontalMargin;
        maxX = camX + halfWidth - horizontalMargin;
    }

    void LateUpdate()
    {
        var p = transform.position;
        // Limitamos X entre minX y maxX
        p.x = Mathf.Clamp(p.x, minX, maxX);
        transform.position = p;
    }
}
