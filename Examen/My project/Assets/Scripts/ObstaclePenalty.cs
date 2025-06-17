using UnityEngine;

public class ObstaclePenalty : MonoBehaviour
{
    public float penaltySeconds = 2f;
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            gm.PenalizeTime(penaltySeconds);
        }
    }
}
