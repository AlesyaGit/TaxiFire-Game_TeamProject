using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float maxPosX = 1.4f, minPosX = -1.4f, minPosY = -4.3f, maxPosY = 4.1f, moveSpeed = 2;
    bool Shielded = false;
    Vector3 position;
    public Text Efect;
    public Rigidbody2D rb;
    public Image ib;
  //  public SpriteRenderer spriteRenderer;
    public Sprite[] spriteCollection;
    float timerCar;
    public float delayTimer = 3f;
    public string Diff;
    public Button b1, b2, b3, b4;
 

    void Start()
    {
        Diff = PlayerPrefs.GetString("Difficultty");
        rb = GetComponent<Rigidbody2D>();
        timerCar = delayTimer;
        Efect.enabled = (false);
        int receivedIntValue = PlayerPrefs.GetInt("currentSpriteIndex");
        ib.sprite = spriteCollection[receivedIntValue];
 //       spriteRenderer.sprite = ib.sprite;
        
        //  im.sprite = ib.sprite;
        position = transform.position;
        if (Diff == "Hard") { moveSpeed = 4; b1.gameObject.SetActive(true);  b2.gameObject.SetActive(true); b3.gameObject.SetActive(true); b4.gameObject.SetActive(true);  }
        if (Diff == "Medium"){ moveSpeed = 2; b1.gameObject.SetActive(false); b2.gameObject.SetActive(false); b3.gameObject.SetActive(false); b4.gameObject.SetActive(false); }
        if (Diff == "Easy") { moveSpeed = 4; b1.gameObject.SetActive(false); b2.gameObject.SetActive(false); b3.gameObject.SetActive(false); b4.gameObject.SetActive(false); }


    }

    // Update is called once per frame
    void Update()
    {
     
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Проверяем движение мыши
        if (Input.GetMouseButton(0) && Diff != "Hard")
        {
            // Получаем горизонтальное положение мыши
            horizontalInput = Input.GetAxis("Mouse X");
            verticalInput = Input.GetAxis("Mouse Y");
        }


        // Создаем вектор направления для движения влево или вправо
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // Перемещаем объект в заданном направлении
       
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minPosX, maxPosX);
        float clampedY = Mathf.Clamp(transform.position.y, minPosY, maxPosY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (Shielded == true)
        {
            timerCar -= Time.deltaTime;
            if (timerCar <= 0)
            {
                Shielded = false;
                rb.isKinematic = false;
                timerCar = delayTimer;
                Efect.enabled = (false);
            }
        }
    }

    public void Left(){ rb.velocity = new Vector2(-moveSpeed, 0); }
    public void Right() { rb.velocity = new Vector2(moveSpeed, 0); }
    public void Up() { rb.velocity = new Vector2(0, moveSpeed); }
    public void Down() { rb.velocity = new Vector2(0, -moveSpeed); }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Present")
        {
            Destroy(collision.gameObject);
            Shielded = true;
            rb.isKinematic = true;

            Efect.enabled = (true);


        }
        else if (Shielded == false)
        {
            SceneManager.LoadScene("GameOver");
        }
           
    }
}
