using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public string Difficultty; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hard()
    {
        Difficultty = "Hard";
        PlayerPrefs.SetString("Difficultty", Difficultty);
    }

    public void Medium()
    {
        Difficultty = "Medium";
        PlayerPrefs.SetString("Difficultty", Difficultty);
    }

    public void Easy()
    {
        Difficultty = "Easy";
        PlayerPrefs.SetString("Difficultty", Difficultty);
    }

}
