using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

   // [SerializeField] WeaponSwitch switcher;

    public float speed; //movement speed
    private bool isGrounded; //is grounded check
    public float jumpheight; //jump height
    private Rigidbody2D rb; //reference to rigid body compoment
    public float fallMultiplier = 2.5f; //decides the fall speed after reaching the jump apex
    public float lowjumpMultiplier = 2f; //low jump 
    private bool canDoubleJump = true;
    Vector3 characterScale;
    float characterScaleX;
    [SerializeField] HealthController healthcontroller;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //gets the reference to rigid body component
    }
     void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;

        if(healthcontroller.playerHealth <= 0)
        {
            Die();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpheight;
                isGrounded = false;
                canDoubleJump = true;
                Debug.Log("Player Jumped Once");
                FindObjectOfType<AudioManager>().Play("Jump");
            }
            else
            {
                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    rb.velocity = Vector2.up * jumpheight;
                    Debug.Log("Player Double Jumped");
                    FindObjectOfType<AudioManager>().Play("Jump");
                }
            }
            
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpMultiplier - 1) * Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            isGrounded = true;
            Debug.Log("Collision with ground detected");
        }
        else if(collision.gameObject.tag == "DeathBarrier")
        {
            Debug.Log("Player reached a death barrier!");

        }

    }
    void Die()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDie");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
