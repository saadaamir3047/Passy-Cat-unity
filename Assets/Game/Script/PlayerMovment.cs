using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float x;
    public float z;
    float gridSize = 1f;
    public Animator anim;
    public bool canPat;

    public static PlayerMovment instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !anim.GetBool("Pat"))
        {
            Right();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !anim.GetBool("Pat"))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !anim.GetBool("Pat"))
        {
            Up();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !anim.GetBool("Pat"))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PatAnim());
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
        if (other.tag == "CanPat")
        {
            canPat = true;
            transform.LookAt(new Vector3(CatController.instance.targetPos.x, transform.position.y, CatController.instance.targetPos.z));

        }
        if (other.tag == "Cat")
        {
            CatController.instance.anim.SetBool("Attack", true);
        }
    }

    Quaternion currentRotation;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CanPat")
        {
            canPat = false;

            HandAngleZero();
        }
        if (other.tag == "Cat")
        {
            CatController.instance.anim.SetBool("Attack", false);
        }
    }

    public void HandAngleZero()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        transform.rotation = rotation;
    }

    public void Up()
    {
        if ((z < 10)&&(!anim.GetBool("Pat")))
        {

            if (Vector3.Distance(new Vector3(x, transform.position.y, z + gridSize), CatController.instance.transform.position) > 0.5f)
            {
                z = z + gridSize;
                transform.position = new Vector3(x, transform.position.y, z);
            }
        }
    }
    public void Down()
    {
        if ((z > 0) && (!anim.GetBool("Pat")))
        {
            
            if (Vector3.Distance(new Vector3(x, transform.position.y, z-gridSize), CatController.instance.transform.position)>0.5f)
            {
                z = z - gridSize;
                transform.position = new Vector3(x, transform.position.y, z);

            }
        }
    }
    public void Right()
    {
        if ((x < 5) && (!anim.GetBool("Pat")))
        {

            if (Vector3.Distance(new Vector3(x + gridSize, transform.position.y, z), CatController.instance.transform.position) > 0.5f)
            {
                x = x + gridSize;
                transform.position = new Vector3(x, transform.position.y, z);
            }
        }
    }
    public void Left()
    {
        if ((x > 0) && (!anim.GetBool("Pat")))
        {

            if (Vector3.Distance(new Vector3(x - gridSize, transform.position.y, z), CatController.instance.transform.position) > 0.5f)
            {
                x = x - gridSize;
                transform.position = new Vector3(x, transform.position.y, z);
            }
        }
    }
    public void Pat()
    {
        StartCoroutine(PatAnim());
    }
}
