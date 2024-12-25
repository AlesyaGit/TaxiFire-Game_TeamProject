using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dekor : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Right") { transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime); }
        else { transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime); }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { Destroy(gameObject); }
    }
}
