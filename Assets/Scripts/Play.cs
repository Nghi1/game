using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    public float Jump;
    private bool levelStart;
    public GameObject Controller;
    public GameObject gt;
    private int score;
    public Text scoreText;
    
    public GameObject gameOver;
    private void Awake()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        Rigidbody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        gt.GetComponent<SpriteRenderer>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Lam cho chim bay len
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
          Sound.instance.PlaySound("wing" ,0.7f);
            if(levelStart == false)
            {
              levelStart = true;
              Rigidbody.gravityScale = 8;
              Controller.GetComponent<Controller>().enableGenratePipe = true;
              gt.GetComponent<SpriteRenderer>().enabled =false;
            }
          birdMoreup();
        }
    }
    private void birdMoreup()// chim bay lên 1 khoang
    {
       Rigidbody.velocity = Vector2.up * Jump;
    }
    
   private void OnCollisionEnter2D(Collision2D collision)
   {
    ReloadScene();
    score = 0;
    scoreText.text = score.ToString();
    Sound.instance.PlaySound("hit", 1f);
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
    Sound.instance.PlaySound("point" ,0.8f);
     score += 1;
     scoreText.text = score.ToString();
     
   }
   void GameOver()
   {
    gameOver.SetActive(true);
    Time.timeScale =0;
   }
   public void ReloadScene()
   {
     SceneManager.LoadScene("PlayGame");
   }
}

