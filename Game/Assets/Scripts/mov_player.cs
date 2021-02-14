using UnityEngine;
using UnityEngine.Events;
public class mov_player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    CapsuleCollider2D capsulecollid;

    public UnityEvent Atirar;
    [SerializeField]private LayerMask layersNaoIgnoradas;
    [SerializeField]private float speed, jumpForce, timerToJump, jumps;
    [SerializeField]private bool inD, inE, canDubleJump, chao;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsulecollid = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chao"))
            chao = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("chao"))
            chao = false;
    }
    void FixedUpdate()
    {
        Vector2 position2 = (Vector2)transform.position + new Vector2(0.1f, 0.5f);
        RaycastHit2D teto = Physics2D.Raycast(position2, Vector2.up, 1, -layersNaoIgnoradas);

        if (Input.GetKey(KeyCode.Space) && teto.collider != null || (Input.GetKey(KeyCode.LeftControl)))
            capsulecollid.isTrigger = true;
        else
            capsulecollid.isTrigger = false;

        if (chao == true)
        {
            timerToJump += 1;
            if(timerToJump >= 5)
            {
                timerToJump = 0;
                Jump();
                timerToJump = 0;
                jumps = 0;
            }
        }
        else if (canDubleJump == true)
        {
            timerToJump++;
            if (timerToJump > 2 && jumps <= 1)
            {
                Jump();
                timerToJump = 0;
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            anim.SetBool("mirar", true);
            Atirar.Invoke();
            speed = 0;
            if (Input.GetKey(KeyCode.D))
            {
                inD = false;
                Flip();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                inD = true;
                Flip();
            }
        }
        else
        {
            anim.SetBool("mirar", false);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("andar", true);
                speed = 10;
                inD = false;
                Flip();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("andar", true);
                speed = -10;
                inD = true;
                Flip();
            }
            else
            {
                anim.SetBool("andar", false);
                speed = 0;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = speed * 2;
            }
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumps += 1;
        }
    }
    void Flip()
    {
        if ((inD && !inE) || (!inD && inE))
        {
            inE = !inE;
            Vector3 thescale = transform.localScale;
            thescale.x *= -1;
            transform.localScale = thescale;
        }
    }
}