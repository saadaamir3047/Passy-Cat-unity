using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text PatCountText;
    public Text AttackCountText;

    public int PatCount =0;
    public int AttackCount=0;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PatCountText.text = "Pat Count = " + PatCount;
        AttackCountText.text = "Attack Count = " + AttackCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncPatCount()
    {
        PatCount++;
        PatCountText.text = "Pat Count = " + PatCount;
    }

    public void IncAttachCount()
    {
        AttackCount++;
        AttackCountText.text = "Attack Count = " + AttackCount;
    }
}
