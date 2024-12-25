using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChosinCar : MonoBehaviour
{
    public Image obj;
    public Sprite[] spriteCollection;
    public Text Own, Reach;
    public GameObject Select;
    public int currentSpriteIndex = 0;
    int bestcore;
    bool MusicOn = true, enoughPoints;
    // Start is called before the first frame update
    void Start()
    {
        Reach.enabled = (false);
        bestcore = PlayerPrefs.GetInt("bestscore");
        
    }

    void Compare(int Points)
    {
        if (bestcore < Points)
        {
            Own.enabled = (false);
            Reach.enabled = (true);
            Reach.text = "Reach score " + Points;
            Select.SetActive(false);
        }
        else
        {
            Select.SetActive(true); Own.enabled = (true); Reach.enabled = (false); PlayerPrefs.SetInt("currentSpriteIndex", currentSpriteIndex);
            PlayerPrefs.Save();
        }
    }
    public void OnButtonClick()
    {
        if (spriteCollection != null)
        {
            // Change the sprite of the Image component to the current sprite.


            // Increment the index for the next sprite.
            currentSpriteIndex = (currentSpriteIndex + 1) % spriteCollection.Length;
            obj.sprite = spriteCollection[currentSpriteIndex];
            switch (currentSpriteIndex)
            {
                case 1: Compare(20);break;
                case 2: Compare(50);break;
                case 3: Compare(70); break;
                case 4: Compare(100); break;
                default:
                    Select.SetActive(true); Own.enabled = (true); Reach.enabled = (false); PlayerPrefs.SetInt("currentSpriteIndex", currentSpriteIndex);
                    PlayerPrefs.Save();  break;
            }
          
            // Update is called once per frame
            void Update()
            {

            }
        }
    }
}