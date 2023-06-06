using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappableBlock : MonoBehaviour
{

    [SerializeField] Vector2 direction;
    Sedia Parent;

    // Start is called before the first frame update
    void Start()
    {
        Parent = GetComponentInParent<Sedia>();
    }

    public void Hit()
    {
        Parent.Move(direction);
    }
}
