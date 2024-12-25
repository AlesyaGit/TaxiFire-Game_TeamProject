using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Image image;
    public Sprite spr1, spr2;
    public string SceneName;
    public AudioSource audioSource;
    int MusicOn, bescore;
    public Text BestScore; 
    // Start is called before the first frame update
    void Start()
    {
        bescore = PlayerPrefs.GetInt("bestscore");
        BestScore.text = "" + bescore;
        MusicOn = PlayerPrefs.GetInt("MusicOn");
        if (MusicOn == 0)
        {
            SoundON();
        }else if (MusicOn == 1) { SoundOf(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SceneChange()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Click()
    {
        if (MusicOn == 0)
        {
            SoundOf();
        }
        else if (MusicOn == 1) { SoundON(); }
    }
    public void SoundOf()
    {
        MusicOn = 1;
        PlayerPrefs.SetInt("MusicOn", MusicOn);
        PlayerPrefs.Save();
        image.sprite = spr2;
        audioSource.Stop();
    }
    public void SoundON()
    {
        MusicOn = 0;
        PlayerPrefs.SetInt("MusicOn", MusicOn);
        PlayerPrefs.Save();
        image.sprite = spr1;
        audioSource.Play();
    }

}
