using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;

    [Header("Stats")]
    public int HP = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}