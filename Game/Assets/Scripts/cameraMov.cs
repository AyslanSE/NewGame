using UnityEngine;

public class cameraMov : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float playerdistX = player.transform.position.x - transform.position.x;

        if (player.transform.position.x > transform.position.x + - 2 || player.transform.position.x < transform.position.x - + 2)
            rb.velocity = new Vector2(playerdistX * 5, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        float playerdistY = player.transform.position.y - transform.position.y;

        if (player.transform.position.y > transform.position.y + 4 || player.transform.position.y < transform.position.y - 3)
            rb.velocity = new Vector2(rb.velocity.x, playerdistY * 5);
        else
            rb.velocity = new Vector2(rb.velocity.x, 0);
    }
}