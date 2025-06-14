using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator myAnim;

    Vector2 movement;
    float horizontal;
    int maxHealth = 100;
    int currentHealth;
    bool isEnd;

    [Header("Player Movements")]
    [SerializeField] float speed;
    [SerializeField] float jumpforce;

    [Header("Player Health UI")]
    [SerializeField]Player_Health player_Health;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject nextUI;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform attackCheck;
    [SerializeField] LayerMask Enemylayer;

    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        currentHealth = maxHealth;
        player_Health.SetmaxHealth(currentHealth);

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal * speed, _rb.velocity.y);

        if (currentHealth >= 0)
        {
            if (!isEnd)
            {
                Movement();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGroundedRaycast())
            {
                jump();
            }
        }

        myAnim.SetBool("isGround", isGroundedRaycast());

        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetTrigger("isAttacking");
        }

        if(transform.position.y < -10)
        {
            Debug.Log("dead");
            isEnd= true;
            _rb.bodyType = RigidbodyType2D.Static;
            UI.SetActive(true);
            Cursor.lockState =  CursorLockMode.None;
            Cursor.visible = true; 
        }
    }
   
    void Movement()
    {
        _rb.velocity = movement;

        if (horizontal > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        if (Mathf.Abs(_rb.velocity.x) > 0)
        {
            myAnim.SetBool("isRunning", true);
        }
        else if (Mathf.Abs(_rb.velocity.x) <= 0)
        {
            myAnim.SetBool("isRunning", false);
        }
    }

    void jump()
    {
        if (!isEnd)
        {
            Debug.Log("jumping");
            _rb.velocity = new Vector2(_rb.velocity.x, jumpforce);
        }  
    }

    void attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackCheck.transform.position, 0.5f, Enemylayer);
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy_Movement>().takeDamage(25);
            if (enemy.GetComponent<Enemy_Movement>().currentHealth > 0)
            {
                enemy.GetComponent<Animator>().SetTrigger("isHit");
            }
            else
            {
                enemy.GetComponent<Animator>().SetTrigger("isDead");
            }
        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        player_Health.SetHealth(currentHealth);
        
        if (currentHealth == 0)
        {
            Debug.Log("Attack");
            myAnim.SetTrigger("isDead");
        }
    }

    void afterDead()
    {
        UI.SetActive(true);  
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    bool isGroundedRaycast()
    {
        if (Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, 1 << LayerMask.NameToLayer("Ground")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(groundCheck.position,Vector2.down * 0.2f);

        Gizmos.DrawWireSphere(attackCheck.transform.position, 0.5f);
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Health_Collectable"))
        {
            if(currentHealth< 100)
            {
            currentHealth = 100;
            player_Health.SetmaxHealth(currentHealth);
            Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("End"))
        {
                isEnd = true;
                _rb.velocity = Vector3.right * 5;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            isEnd = true;
            _rb.velocity = Vector3.zero;

            nextUI.SetActive(true); 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}