using UnityEngine;

public class shot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed, timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += 1;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if(timer > 6)
        {
            Destroy(this.gameObject);
        }
    }
}