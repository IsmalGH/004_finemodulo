using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]GameObject BulletPre;
    [SerializeField]Transform FirePoint;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnFire()
    {
        Shoot();
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPre, FirePoint.position, FirePoint.rotation);
        Rigidbody2D BulletRB = Bullet.GetComponent<Rigidbody2D>();
        BulletRB.AddForce(FirePoint.right * 10, ForceMode2D.Impulse);
    }

}
