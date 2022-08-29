using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public static CatController instance;

    public Animator anim;

    float xCoordinate;
    float zCoordinate;
    public Vector3 targetPos;
    float speed = 1.5f;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;


    bool move = true;

    public GameObject cat;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        xCoordinate = Random.Range(0, 6);
        zCoordinate = Random.Range(0, 11);
        targetPos = new Vector3(xCoordinate, 0.1f, zCoordinate);

    }
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
            PlayerMovment.instance.HandAngleZero();
            /////////////////////////
            box1.SetActive(false);
            box2.SetActive(false);
            box3.SetActive(false);
            box4.SetActive(false);
            /////////////////////////
            anim.SetBool("HappyCat", false);
            PlayerMovment.instance.anim.SetBool("Pat",false);


            if (!anim.GetBool("Attack"))
            {
                anim.SetBool("IsSit", false);
                anim.SetBool("Run", true);

                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                transform.LookAt(new Vector3(targetPos.x, transform.position.y, targetPos.z));
                float distance = Vector3.Distance(targetPos, transform.position);
                if (distance < 0.01f)
                {
                    anim.SetBool("Run", false);
                    anim.SetBool("IsSit", true);
                    /////////////////////////
                    //box1.SetActive(true);
                    //box2.SetActive(true);
                    //box3.SetActive(true);
                    //box4.SetActive(true);
                    /////////////////////////
                    StartCoroutine(NewLocation());
                    move = false;
                }
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
