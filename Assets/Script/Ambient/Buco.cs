using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Buco : MonoBehaviour
{
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnColliionEnter2D(Collider2D collision)
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
            collision.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            sprite.color = new Color(0.9528302f, 0.6427109f, 0.8188012f);
           // collision.gameObject.transform.localPosition = new Vector3(transform.position.x, collision.gameObject.transform.position.y,-1);

        }
    }
}
