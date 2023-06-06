using UnityEngine;

public class Sedia : MonoBehaviour
{

    [SerializeField] Transform Su, Giù, Destra, Sinistra;
    [SerializeField] GameObject ActSu, ActGiù, ActDestra, ActSinistra;
    [SerializeField] LayerMask Mura;

    GameObject Player;
    Rigidbody2D rb;
    bool isMoving,Range,Unmovable;
    Vector2 direction, Push,thisPush;


    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        Unmovable = false;
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



        Unmovable = (Physics2D.OverlapBox(Su.position, new Vector2(0.5f, 0.1f), 0, Mura) || Physics2D.OverlapBox(Giù.position, new Vector2(0.5f, 0.1f), 0, Mura)) && (Physics2D.OverlapBox(Destra.position, new Vector2(0.5f, 0.1f), 0, Mura) || Physics2D.OverlapBox(Sinistra.position, new Vector2(0.5f, 0.1f), 0, Mura));


        if (Range)
        {
            if (Push == Vector2.left)
                ActDestra.SetActive(true);
            else
                ActDestra.SetActive(false);
            if (Push == Vector2.up)
                ActGiù.SetActive(true);
            else
                ActGiù.SetActive(false);
            if (Push == Vector2.right)
                ActSinistra.SetActive(true);
            else
                ActSinistra.SetActive(false);
            if (Push == Vector2.down)
                ActSu.SetActive(true);
            else
                ActSu.SetActive(false);
        }
        else
        {
            ActDestra.SetActive(false);
            ActGiù.SetActive(false);
            ActSu.SetActive(false);
            ActSinistra.SetActive(false);
        }

        if (!isMoving)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Physics2D.IgnoreLayerCollision(3, 6, false);
        }
        else
        {
             if(thisPush == Vector2.down || thisPush == Vector2.up)
            {
                rb.constraints = (RigidbodyConstraints2D)5;

            }
                 
             if (thisPush == Vector2.left || thisPush == Vector2.right)
            {
                rb.constraints = (RigidbodyConstraints2D)6;
            }
                 
            Physics2D.IgnoreLayerCollision(3, 6);
        }
            
        if (rb.velocity == Vector2.zero)
            isMoving = false;
    }

    void OnInteraction()
    {
        if (Range)
        {
            thisPush = Push;
            isMoving = true;
            Move(Push);

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Su.position, new Vector2(0.5f, 0.1f));
        Gizmos.DrawWireCube(Giù.position, new Vector2(0.5f, 0.1f));
        Gizmos.DrawWireCube(Destra.position, new Vector2(0.1f, 0.5f));
        Gizmos.DrawWireCube(Sinistra.position, new Vector2(0.1f, 0.5f));
    }

    public void Move(Vector2 A)
    {
        Debug.Log("MUOVI");
        if (Unmovable || (Physics2D.OverlapBox(Su.position, new Vector2(0.5f, 0.1f), 0, Mura) && thisPush == Vector2.up) || (Physics2D.OverlapBox(Giù.position, new Vector2(0.5f, 0.1f), 0, Mura) && thisPush == Vector2.down) || (Physics2D.OverlapBox(Destra.position, new Vector2(0.5f, 0.1f), 0, Mura) && thisPush == Vector2.right) || (Physics2D.OverlapBox(Sinistra.position, new Vector2(0.5f, 0.1f), 0, Mura) && thisPush == Vector2.left))
            rb.AddForce(A * -10, ForceMode2D.Impulse);
        else
            rb.AddForce(A * 10, ForceMode2D.Impulse);
    }

}
