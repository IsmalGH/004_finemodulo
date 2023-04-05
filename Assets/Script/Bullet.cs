using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 startingPosition;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Damageable Hit = collision.gameObject.GetComponent<Damageable>();
            if (Hit != null)
            {
                Hit.Hurt(Damage);
            }

        }

        Destroy(gameObject);
    }

}
