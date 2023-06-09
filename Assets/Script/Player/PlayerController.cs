using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float Speed;
    [SerializeField] float PlayerHealth = 100;


    Rigidbody2D rb;
    Vector2 movement, mouse,RollD;
    float angle,timerRoll,TimerRollC;
    bool isRolling;
    int rollCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = ((Vector2)Camera.main.ScreenToWorldPoint(mouse) - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(rollCount!=0)
        {
            if (TimerRollC <= 0.3f)
                TimerRollC += Time.deltaTime;
            else
            {
                rollCount = 0;
                TimerRollC = 0;
            }

        }

        if (PlayerHealth <= 0)
            gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(!isRolling)
            rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
        else if (timerRoll <= 0.15f)
        {
            timerRoll += Time.fixedDeltaTime;
        }
        else
        {
            timerRoll = 0;
            isRolling = false;
        }
        rb.rotation = angle;
    }

    void OnMove(InputValue Value)
    {
        movement = Value.Get<Vector2>();
        if (movement != Vector2.zero)
        {
            RollD = movement;
        }
    }


    void OnLook(InputValue Value)
    {
        mouse = Value.Get<Vector2>();
    }

    void OnRoll()
    {
        if (rollCount==0)
        {   
            rb.velocity = Vector2.zero;
            rb.AddForce(RollD * 20, ForceMode2D.Impulse);
            isRolling = true;
            rollCount++;
        }
        

    }

}
