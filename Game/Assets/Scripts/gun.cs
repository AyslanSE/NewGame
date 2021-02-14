using UnityEngine;
public class gun : MonoBehaviour
{
    public GameObject balaD,balaE, player;
    public float time, timer, shots;
    bool lookD;
    public void Shot()
    {
        if (player.transform.localScale.x > 0)
            lookD = true;
        else
            lookD = false;

        timer += 1;
        if (timer >= time)
        {
            timer = 0;
            if(lookD == false)
                Instantiate(balaE, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            else
                Instantiate(balaD, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}