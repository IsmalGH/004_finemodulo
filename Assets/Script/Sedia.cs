using UnityEngine;

public class Sedia : MonoBehaviour
{

    [SerializeField] Transform Su, Giù, Destra, Sinistra;

    GameObject Player;
    Rigidbody2D rb;
    bool isMoving,Range;
    Vector2 direction, Push;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        direction = ((Vector2)Player.transform.position - (Vector2)transform.position).normalized;


        if (direction.x > direction.y && direction.x > -direction.y)
            Push = Vector2.left;

        if (-direction.x > -direction.y && -direction.x > direction.y)
            Push = Vector2.right;

        if (direction.y > direction.x && direction.y > -direction.x)
            Push = Vector2.down;

        if (-direction.y > -direction.x && -direction.y > direction.x)
            Push = Vector2.up;


        Physics2D.OverlapBox(Su.position, new Vector2(0.5f, 0.1f),0);

        if (!isMoving)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Physics2D.IgnoreLayerCollision(3, 6, false);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Physics2D.IgnoreLayerCollision(3, 6);
        }
            
        if (rb.velocity == Vector2.zero)
            isMoving = false;
    }

    void OnInteraction()
    {
        if (Range)
        {
            isMoving = true;
            rb.AddForce(Push * 10, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Range = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Range = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Su.position, new Vector2(0.5f, 0.1f));
        Gizmos.DrawWireCube(Giù.position, new Vector2(0.5f, 0.1f));
        Gizmos.DrawWireCube(Destra.position, new Vector2(0.1f, 0.5f));
    }
}
