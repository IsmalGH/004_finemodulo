using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Damageable
{
    [SerializeField] [Range(0,10)] float Distance, SafeDistance, AttackSpeed;
    [SerializeField] LayerMask PlayerMask;
    [SerializeField] Transform Forward;
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] bool aggro = false;
    [SerializeField] GameObject BulletPre;

    Vector2 Direction, oldPosition;
    Rigidbody2D rb;
    GameObject Player;
    float angle, timerAttack, timerAggro;
    RaycastHit2D Hit;

    [SerializeField] public float Health;




    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Direction = (Player.transform.position - transform.position).normalized;
        angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        if (Vector2.Distance(transform.position, Player.transform.position) < Distance)
        {
            Vector2 trueF = Forward.TransformDirection(Vector2.right);
            if (Vector2.Dot(trueF, Direction) > 0)
            {
                Hit = Physics2D.Raycast(Forward.position, Direction);
                if (Hit.transform.CompareTag("Player"))
                {
                    aggro = true;
                    Attack();
                }

            }
        }

      /*  if (aggro && !Hit.transform.CompareTag("Player"))
        {
            if (timerAggro < 2f)
            {
                timerAggro += Time.deltaTime;
            }
            else
            {
                timerAggro = 0;
                aggro = false;
            }
        } */

        if (Health <= 0)
            Destroy(gameObject);

    }

    private void FixedUpdate()
    {

            if (aggro)
            {
                rb.rotation = angle;
                if (Vector2.Distance(transform.position, Player.transform.position) > SafeDistance)
                {
                    rb.position = Vector2.MoveTowards(transform.position, Player.transform.position, 0.05f);
                }

            }
           /* else if ((Vector2)transform.position != oldPosition)
            {
                rb.position = Vector2.MoveTowards(transform.position, oldPosition, 0.05f);
            } */
    }


    void Attack()
    {
        if (timerAttack < AttackSpeed)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            GameObject Bullet = Instantiate(BulletPre, Forward.position, Forward.rotation);
            Rigidbody2D BulletRB = Bullet.GetComponent<Rigidbody2D>();
            BulletRB.AddForce(Forward.right * 15, ForceMode2D.Impulse);
            timerAttack = 0;
        }

    }
    public void Hurt(float Damage)
    {

        Health -= Damage;
        aggro = true;
    }

}
