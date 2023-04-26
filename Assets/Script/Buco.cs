using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buco : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisioEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sedia"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("AAAAAA");
            collision.gameObject.transform.localPosition = new Vector2(transform.position.x, collision.gameObject.transform.position.y);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sedia"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("AAAAAA");
            collision.gameObject.transform.localPosition = new Vector2(transform.position.x, collision.gameObject.transform.position.y);

        }
    }
}
