using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hook : MonoBehaviour
{

    LineRenderer line;
    [SerializeField] Transform origin;
    [SerializeField] LayerMask GrappableMask;
    [SerializeField] float maxDistance= 10f;
    [SerializeField] float grappleSpeed= 10f;
    [SerializeField] float shootSpeed= 10f;
    Vector2 target,mouse;
    GameObject GrapplePoint;
    public bool isGrappling, isRetracting, HookUnlock;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = ((Vector2)Camera.main.ScreenToWorldPoint(mouse) - (Vector2)transform.position).normalized;

        Debug.Log(Vector2.left);



        if (isRetracting)
        {
            if (GrapplePoint.CompareTag("GrappablePoint"))
            {
               // if(GrapplePoint.GetComponentInChildren<GrappableBlock>()!=null)
                    GrapplePoint.GetComponentInChildren<GrappableBlock>().Hit();
                line.SetPosition(1, origin.position);
                isRetracting = false;
                isGrappling = false;
                line.enabled = false;
            }
            else
            {
                Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);
                transform.position = grapplePos;
                line.SetPosition(0, origin.position);
                if (Vector2.Distance(transform.position, target) < 0.5f)
                {
                    isRetracting = false;
                    isGrappling = false;
                    line.enabled = false;
                }
            }

        }
    }

    void OnFire()
    {
        if(!isGrappling && HookUnlock)
        {
            StartGrapple();
        }
    }

    void StartGrapple()
    {
        Vector2 direction = ((Vector2)Camera.main.ScreenToWorldPoint(mouse) - (Vector2)transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(origin.position, direction, maxDistance,GrappableMask);
        

        if (hit.collider != null)
        {
            GrapplePoint = hit.transform.gameObject;
            isGrappling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());
        }

    }

    IEnumerator Grapple()
    {
        float time = 10;

        line.SetPosition(0, origin.position);
        line.SetPosition(1, origin.position);

        Vector2 newPos;

        for (float t = 0; t < time; t += shootSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(origin.position, target, t / time); 
            line.SetPosition(0, origin.position);
            line.SetPosition(1, newPos);
            yield return null;
        }
        
        line.SetPosition(1, target);
        isRetracting = true;
    }

    void OnLook(InputValue Value)
    {
        mouse = Value.Get<Vector2>();
    }

}
