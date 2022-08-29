using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool dead = false;
    public bool play = true;
    public Text TimeText;
    public Text AttackCountText;

    public int PatCount =0;
    public int AttackCount=0;

    public GameObject GameOverPanel;

    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        AttackCountText.text = "Attack Count = " + AttackCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void IncPatCount()
    //{
    //    PatCount++;
    //    PatCountText.text = "Pat Count = " + PatCount;
    //}

    public void IncAttachCount()
    {
        if (AttackCount < 2)
        {
            AttackCount++;
            AttackCountText.text = "Attack Count = " + AttackCount;
        }
        else
        {
            AttackCount++;
            AttackCountText.text = "Attack Count = " + AttackCount;
            dead = true;
            GameOver();
        }
    }

    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        play = false;

    }
}
