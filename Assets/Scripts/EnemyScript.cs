using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2;
    public int Health = 50;
    public int damage = 10;
    private bool facingLeft = true;
    public float chaseDistance = 5;
    public float AttackDistance = 2;
    [SerializeField] private HealthController controller;
    private Rigidbody2D playerrb;
    public float knockback;
    public float bullet_knockback;
    private Rigidbody2D enemyrb;
    [SerializeField] private Transform Pos1;
    [SerializeField] private Transform Pos2;
    private Transform currentTarget;
    public Transform playerTarget;


    private void Start()
    {
        currentTarget = Pos1;
        playerrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        if (playerrb != null) Debug.Log("Found Player RB");
        enemyrb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(playerTarget.position.x - transform.position.x < 0) //player is on the left
        {
            if((playerTarget.position.x - transform.position.x)*-1 < chaseDistance && Mathf.Abs(playerTarget.position.y - transform.position.y) < 5 )
            {
                ChasingPlayer(1);
               // Debug.Log("I'm chasing twats on the left");
            }
            else
            {
                Patrolling();
            }
        }
        else
        {
            if(playerTarget.position.x - transform.position.x < chaseDistance && Mathf.Abs(playerTarget.position.y - transform.position.y) < 5)
            {
                ChasingPlayer(-1);
                //Debug.Log("I'm chasing twats on the right");
            }
            else
            {
                Patrolling();
            }
        }
        if (Health <= 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            controller.playerHealth -= damage;
            controller.UpdateHealth();


            if(transform.position.x - playerrb.position.x > 0)
            {
                playerrb.velocity = Vector2.left * knockback;
                
                Debug.Log("Adding knockback to the left");
            }
            else
            {
                playerrb.velocity = Vector2.right * knockback;

                Debug.Log("Adding knockback to the right");
            }

        }
        if(collision.CompareTag("Bullet"))
        {
            if(collision.transform.position.x - transform.position.x > 0)
            {
                enemyrb.velocity = Vector2.left * bullet_knockback; //left
            }
            if (collision.transform.position.x - transform.position.x < 0)
            {
                enemyrb.velocity = Vector2.right * bullet_knockback; //right
            }

        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
    private void Rotate(int rotateTo)
    {
        if(rotateTo == 1)
        {
            Vector3 enemyScale = transform.localScale;
            if(enemyScale.x < 0)
            {
                enemyScale.x *= -1; //multiply the enemy scale 
                transform.localScale = enemyScale; //set the local scale to be enemy scale
            }
        }
        else if (rotateTo == -1)
        {
            Vector3 enemyScale = transform.localScale;
            if(enemyScale.x > 0)
            {
                enemyScale.x *= -1;
                transform.localScale = enemyScale; //set the local scale to be enemy scale
            }
        }

    }
    private void ChasingPlayer(float direction)
    {
        if(direction == 1) //go left
        {
            Rotate(1);
            Vector3 movement = new Vector3(-direction, 0f,0f);
            transform.position += movement * Time.deltaTime * speed;
        }
        if (direction == -1) //go right
        {
            Rotate(-1);
            Vector3 movement = new Vector3(-direction, 0f, 0f);
            transform.position += movement * Time.deltaTime * speed;
        }
    }
    private void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed*Time.deltaTime);

        if(transform.position.x == currentTarget.position.x)
        {
            if(currentTarget == Pos1)
            {
                Rotate(-1);
                currentTarget = Pos2;
            }
            else if(currentTarget == Pos2)
            {
                Rotate(1);
                currentTarget = Pos1;
            }
        }
    }
}
