using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;   
    public int attackDamage = 10;   

    Animator anim;                        
    GameObject player;
    public int currentHealth;
    public int startHealth = 40;
    private bool hold = true;
    private bool enemyIn;
    PlayerHealth playerHealth;                 
    bool playerInRange;                 
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        currentHealth = startHealth;
        enemyIn = true;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (playerInRange && currentHealth > 0)
        {
            if (GameControl.instance.isAtt() > 160)
            {
                if(timer >= timeBetweenAttacks)
                {
                    anim.SetTrigger("Attack");
                    Attack();
                }
            }
            else if (GameControl.instance.isAtt() > 40)
            {
                if (hold)
                {
                    anim.SetTrigger("TakeDamage");
                    hold = false;
                    currentHealth -= playerHealth.attack();
                }
            }
            else
                hold = true;
        }
        else if (currentHealth <= 0 && enemyIn)
        {
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}