using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    Animator ani;
    [SerializeField] GameObject PlayerCheck;
    [SerializeField] Transform attackCheck;
    [SerializeField] LayerMask Playerlayer;
    public int maxHealth = 100;
    public int currentHealth;
    bool isfacingright;

    void Start()
    {
        ani = GetComponent<Animator>();
        currentHealth= maxHealth;
    }
    void Update()
    {
        if (playercheck())
        {
            if (currentHealth >= 0.1)
            {
                ani.SetTrigger("isAttacking1");
                ani.SetTrigger("isAttacking2");
            }
            else
            {
                Destroy(gameObject, 1f);
            }
        }
    }

    void attack()
    {
        Collider2D[] Player = Physics2D.OverlapCircleAll(attackCheck.transform.position, 0.5f, Playerlayer);
        foreach (Collider2D Players in Player)
        {
            Players.GetComponent<Player_Movement>().Damage(20);
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    bool playercheck()
    {
        if (Physics2D.Raycast(PlayerCheck.transform.position, Vector2.left, 2f, Playerlayer))
        {
            if (!isfacingright)
            {
                transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                isfacingright = true;
            }
            return true;
        }
        else if(Physics2D.Raycast(PlayerCheck.transform.position, Vector2.right, 2f, Playerlayer))
        {
            if (isfacingright)
            {
                transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
                isfacingright = false;
            }
            
            return true;
        }
        else
        {
            
            return false;

        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attackCheck.transform.position, 0.5f);
        Gizmos.DrawRay(PlayerCheck.transform.position, Vector2.left * 2f); 
    }
}
