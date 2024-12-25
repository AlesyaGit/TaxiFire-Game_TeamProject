using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public GameObject[] cars;
    int CarIndex;
    public float maxpos = 1.6f;
    public float minpos = -1.6f;
    public float delayTimer = 1f;
    float timerCar;
    public Vector3 spawnScale = new Vector3(0.46f, 0.46f, 0f);
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
            CarIndex = Random.Range(0,4);
            cars[CarIndex].transform.localScale = spawnScale;
            Instantiate(cars[CarIndex], carpos, transform.rotation);
            timerCar = delayTimer;
        }
    }
}
