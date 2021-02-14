using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class coliisor : MonoBehaviour
{
    public float life;
    public GameObject npc;

    public bool isPlayer;
    public Slider bar;

    private void Start()
    {
        if (isPlayer)
        {
            bar.value = bar.maxValue;
            bar.maxValue = 100;
            bar.minValue = 0;
        }

        if (life == 0)
            life = 10;    
    }
    private void Update()
    {
        if (isPlayer)
        {
            bar.value = life;
        }
        if (life == 0)
        {
            if (npc.tag == "Player" && isPlayer == true)
                SceneManager.LoadScene("Morte");
            else
                Destroy(this.npc);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deadzone"))
            life = 0;
        if (collision.CompareTag("enemy"))
            life -= 10;
    }
}