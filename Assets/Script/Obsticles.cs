using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticles : MonoBehaviour
{
    public GameObject[] obstickles;
    int obsticklIndex;
    public float maxpos = 1.6f;
    public float minpos = -1.6f;
    public float delayTimer2 = 2f, del = 10f, delMin;
    float timerObsticles, Timer2;
    public string Diff;
    void Start()
    {
        Diff = PlayerPrefs.GetString("Difficultty");
        timerObsticles = delayTimer2;
        if (Diff == "Hard") { del = 10f; delMin = 0.5f; }
        if (Diff == "Medium") { del = 10f; delMin = 0.3f; }
        if (Diff == "Easy") { del = 15f; delMin = 0.3f; }
            Timer2 = del;
    }

    // Update is called once per frame
    void Update()
    {

        timerObsticles -= Time.deltaTime;
        Timer2 -= Time.deltaTime;


        if (timerObsticles <= 0)
        {
            Vector2 carpos = new Vector2(Random.Range(minpos, maxpos), transform.position.y);
            obsticklIndex = Random.Range(0, 9);
            Instantiate(obstickles[obsticklIndex], carpos, transform.rotation);
            timerObsticles = delayTimer2;
        }

        if (Timer2 <= 0 && delayTimer2 >=1)
        {
            delayTimer2 -= delMin;
        }
    }
}


