using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovment : MonoBehaviour
{
    public Animator doorAnim;
    public CinemachineVirtualCamera cam;
    public bool won;
    public GameObject jumpTextPanel;
    public float x = 3;
    public float z;
    float gridSize = 1f;
    public Animator anim;
    public bool canPat;

    public bool canJump = false;

    public bool moveToPosition;

    public static PlayerMovment instance;

    Vector3 targetPos;

    public int speed = 1;

    public bool jump;
    public bool goingUp = true;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        won = false;
        anim.SetBool("Idle",true);
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            
            float y = transform.position.y;
            if (transform.position.y < 0.75f && goingUp)
            {
                y = 0.75f;
            }
            else if (transform.position.y > -0.43f)
            {
                doorAnim.SetBool("DoorOpen",true);
                cam.LookAt = transform;
                goingUp = false;
                y = -0.43f;
            }

            float step = speed * Time.deltaTime * 2;
            targetPos.y = y;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if (transform.position == targetPos && !goingUp)
            {
                jump = false;
                anim.SetBool("Jump", false);
                targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                moveToPosition = true;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Up();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Down();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(PatAnim());
        }

        if (transform.position.x == 3 && transform.position.z == 10 && !jump)
        {
            canJump = true;
            jumpTextPanel.SetActive(true);
        }
        else
        {
            canJump = false;
            jumpTextPanel.SetActive(false);
        }

        if (moveToPosition && !jump)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if (transform.position == targetPos)
            {
                moveToPosition = false;
                anim.SetBool("Run", false);
                anim.SetBool("Idle", true);

                
            }
        }
    }
    IEnumerator PatAnim()
    {
        if (canPat)
        {
            anim.SetBool("Pat", true);
            CatController.instance.anim.SetBool("HappyCat",true);
            yield return new WaitForSeconds(2.5f);
            CatController.instance.anim.SetBool("HappyCat", false);
            anim.SetBool("Pat", false);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "CanPat")
        //{
        //    canPat = true;
        //    transform.LookAt(new Vector3(CatController.instance.targetPos.x, transform.position.y, CatController.instance.targetPos.z));

        //}
        //if (other.tag == "Cat")
        //{
        //    CatController.instance.anim.SetBool("Attack", true);
        //}
    }

    Quaternion currentRotation;
    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "CanPat")
        //{
        //    canPat = false;

        //    HandAngleZero();
        //}
        //if (other.tag == "Cat")
        //{
        //    CatController.instance.anim.SetBool("Attack", false);
        //}
    }

    public void HandAngleZero()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        transform.rotation = rotation;
    }

    public void Up()
    {
        if ((z < 10))
        {

            if (Vector3.Distance(new Vector3(x, transform.position.y, z + gridSize), CatController.instance.transform.position) > 0.5f)
            {

                z = z + gridSize;
                targetPos = new Vector3(x, transform.position.y, z);
                moveToPosition = true;
            }
        }
        else if (canJump)
        {
            won = true;
            
            jump = true;
            canJump = false;
            anim.SetBool("Jump", true);
            z = z + gridSize + 2;
            targetPos = new Vector3(x, -0.43f, z);
            moveToPosition = true;
            StartCoroutine(GameOver());
        }
        
    }
    public void Down()
    {
        if ((z > 0))
        {
            
            if (Vector3.Distance(new Vector3(x, transform.position.y, z-gridSize), CatController.instance.transform.position)>0.5f)
            {
                z = z - gridSize;
                targetPos = new Vector3(x, transform.position.y, z);
                moveToPosition = true;
            }
        }
    }
    public void Right()
    {
        if ((x < 5))
        {

            if (Vector3.Distance(new Vector3(x + gridSize, transform.position.y, z), CatController.instance.transform.position) > 0.5f)
            {
                x = x + gridSize;
                targetPos = new Vector3(x, transform.position.y, z);
                moveToPosition = true;

            }
        }
    }
    public void Left()
    {
        if ((x > 1))
        {

            if (Vector3.Distance(new Vector3(x - gridSize, transform.position.y, z), CatController.instance.transform.position) > 0.5f)
            {
                x = x - gridSize;
                targetPos = new Vector3(x, transform.position.y, z);
                moveToPosition = true;
            }
        }
    }
    public void Pat()
    {
        //StartCoroutine(PatAnim());
    }

    private void OnParticleCollision(GameObject other)
    {
            
        GameManager.instance.IncAttachCount();
        Destroy(other.gameObject);
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.instance.GameOver();

    }

}
