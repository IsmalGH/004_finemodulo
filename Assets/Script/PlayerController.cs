using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float Speed;


    PlayerAction actions;
    Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    private void Awake()
    {
        actions = new PlayerAction();
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = actions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        actions.Player.Enable();
    }

    private void OnDisable()
    {
        actions.Player.Disable();
    }
}
