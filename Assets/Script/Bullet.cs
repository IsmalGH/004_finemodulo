using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 startingPosition;
    Rigidbody2D rb;
    public float Damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(startingPosition, transform.position) >= 30f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable Hit = collision.gameObject.GetComponent<Damageable>();
        if (Hit!=null)
                Hit.Hurt(Damage);

        rb = collision.collider.GetComponent<Rigidbody2D>();
        if(!(rb.bodyType == RigidbodyType2D.Static))
            rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }

}
