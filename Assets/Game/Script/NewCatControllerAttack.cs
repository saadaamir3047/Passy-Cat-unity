using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCatControllerAttack : MonoBehaviour
{
    public Animator anim;

    public int wait;
    public int maxWait;
    public int minWait;


    public GameObject pawParticle;
    void Start()
    {
        StartCoroutine(NewAttack());
        anim.SetBool("Sit", true);
        maxWait = 5;
        minWait = 3;
    }

    void Update()
    {
    }

    public IEnumerator NewAttack()
    {
        if (!PlayerMovment.instance.won && GameManager.instance.play)
        {
            wait = Random.Range(minWait, maxWait + 1);
            yield return new WaitForSeconds(wait);
            if (!PlayerMovment.instance.won && GameManager.instance.play)
            {
                anim.SetBool("Attack", true);
            }
            yield return new WaitForSeconds(0.5f);
            if (!PlayerMovment.instance.won && GameManager.instance.play)
            {
                NewAttackFunc();
            }
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("Attack", false);
            anim.SetBool("Sit", true);
            if (!PlayerMovment.instance.won && GameManager.instance.play)
            {
                StartCoroutine(NewAttack());
            }
        }
    }
    public void NewAttackFunc()
    {
        if (!PlayerMovment.instance.won)
        {
           GameObject slash = Instantiate(pawParticle, transform);
           slash.transform.LookAt(PlayerMovment.instance.transform.position);
           Destroy(slash, 5f);

        }
    }
}
