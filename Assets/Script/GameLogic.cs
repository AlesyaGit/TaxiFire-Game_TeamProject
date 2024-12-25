using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadScroll : MonoBehaviour
{
    public Renderer mshRenderer;
    public float speed = 0.05f;
    public Text scoretext;
    int score, bestscore;

    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bestscore = PlayerPrefs.GetInt("bestscore");
        InvokeRepeating("ScoreUpdate", 1.0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + score;
        if (bestscore < score)
        {
            bestscore = score;
            PlayerPrefs.SetInt("bestscore", bestscore);
            PlayerPrefs.Save();
        }
        mshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
       
    }

  
    void ScoreUpdate()
    {
        score += 1;
    }

    public void Pause()
    {
        if(Time.timeScale == 1){ Time.timeScale = 0;}
        else{Time.timeScale = 1;}
    }
}
