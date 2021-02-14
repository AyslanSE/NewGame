using UnityEngine;
public class soldado_IA : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public GameObject Player;
    public float speed, limite;
    public LayerMask layersNaoIgnoradas;

    private float inicialPosition;
    private bool canMov, movD, inD, inE, playerDetected;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inicialPosition = transform.position.x;
    }
    private void FixedUpdate()
    {
        FoundPlayer();
        if(playerDetected == false)
        {
            Vector2 startPosition = (Vector2)transform.position + new Vector2(1f, -2f);
            RaycastHit2D chaoDetectado = Physics2D.Raycast(startPosition, -Vector2.up, 1, -layersNaoIgnoradas);
            if (chaoDetectado.collider == null)
            {
                if (movD == true)
                    movD = false;
                else
                    movD = true;
            }
            Round();
            Mov();
        }
    }
    public void Mov()
    {
        if (movD == true)
        {
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            anim.SetBool("andar", true);
            inD = false;
            Flip();
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetBool("andar", true);
            inD = true;
            Flip();
        }
    }
    void FoundPlayer()
    {
        float playerDistanceX = Player.transform.position.x - this.transform.position.x;
        float playerDistanceY = Player.transform.position.y - this.transform.position.y;

        if (playerDistanceX > -8 && playerDistanceX < 8 && playerDistanceY > -3 && playerDistanceY < 5)
        {
            if(playerDistanceX >= -2 && transform.localScale.x > 0 || playerDistanceX > 0 && playerDistanceX < 8)
            {
                playerDetected = true;
                movD = true;
                speed = 10;
                if (playerDistanceX > 3)
                    Mov();
            }
            else if(playerDistanceX <= 2 && transform.localScale.x < 0 || playerDistanceX < 0 && playerDistanceX > -8)
            {
                playerDetected = true;
                movD = false;
                speed = 10;
                if (playerDistanceX < -3)
                    Mov();
            }
            else
            {
                anim.SetBool("atirar", true);
            }
        }
        else
            playerDetected = false;
    }
    public void Round()
    {
        float position = this.transform.position.x;
        if (position <= inicialPosition)
            movD = true;
        else if (position >= limite)
            movD = false;
    }
    void Flip()
    {
        if((inD && !inE)||(!inD && inE))
        {
            inE = !inE;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}