using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{


    public float speed = 0;
    
    public TextMeshProUGUI countText;
    public TextMeshProUGUI LivesText;
    public GameObject DiedText;
    public GameObject winTextObject;
    
    

    private Rigidbody rb;
    private int count;
    private int lives = 3;
    
    private float movementX;
    private float movementY;
    private GameObject player;
    private Vector3 spawn = new Vector3 (0.0f,1f,0f);

    
    
    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);
        DiedText.SetActive(false);
        
        SetCountText();
        SetLivesText();
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 17)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            DiedText.SetActive(true);
            // diedpanel.SetActive(true);
            Time.timeScale = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
        
    }

     void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
        
        var playerPos = player.transform.position;
        if (playerPos.y < -10)
        {
            lives = lives - 1;
            player.transform.position = spawn;
            SetLivesText();
        }

        // movingPlatform.transform.position = new Vector3(movingPlatform.transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), movingPlatform.transform.position.z);
    }

        
    
    



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;

            SetCountText();
        }
        if(other.gameObject.CompareTag("checkpoint"))
        {
            spawn = other.gameObject.transform.position;
            // other.gameObject.transform.position = new Vector3(transform.position.x, -0.35f, transform.position.z);
            
        }
        
    }
}
