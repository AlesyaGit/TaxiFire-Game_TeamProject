using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorSpawn : MonoBehaviour
{
    public GameObject[] Decors;
    int CarIndex;
    public float maxpos = 2.6f;
    public float minpos = 2.6f;
    public float delayTimer = 0.5f;
    float timerCar;
    public Vector3 spawnScale = new Vector3(0.3490687f, 0.2995069f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        timerCar = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timerCar -= Time.deltaTime;

        if (timerCar <= 0)
        {
            Vector2 carpos = new Vector2(Random.Range(minpos, maxpos), transform.position.y);
            CarIndex = Random.Range(0, 10);
            Decors[CarIndex].transform.localScale = spawnScale;
            Instantiate(Decors[CarIndex], carpos, transform.rotation);
            timerCar = delayTimer;
        }
    }
}
