using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator anim;

    float xCoordinate;
    float zCoordinate;
    Vector3 targetPos;
    float speed = 1.5f;

    bool move = true;
    // Start is called before the first frame update
    
    public IEnumerator NewLocation()
    {
        yield return new WaitForSeconds(5f);
        NewLocationFunc();
    }
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            anim.SetBool("IsSit", false);
            anim.SetBool("Run",true);

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.LookAt(new Vector3(targetPos.x, transform.position.y, targetPos.z));
            float distance = Vector3.Distance(targetPos, transform.position);
            if (distance<0.5f)
            {
                anim.SetBool("Run", false);
                anim.SetBool("IsSit", true);


                StartCoroutine(NewLocation());
                move = false;
            }
        }
        
        //transform.up = targetPos - transform.position;
    }

    public void NewLocationFunc()
    {
        xCoordinate = Random.Range(0,6);
        zCoordinate = Random.Range(0, 11);
        targetPos = new Vector3(xCoordinate, 0.1f, zCoordinate);
        move = true;
    }
}
