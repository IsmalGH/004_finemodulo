using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]GameObject BulletPre;
    [SerializeField]Transform FirePoint;
    [SerializeField] float danno;



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
        Bullet Damage = Bullet.GetComponent<Bullet>();
        Damage.Damage = danno;
        BulletRB.AddForce(FirePoint.right * 20, ForceMode2D.Impulse);
    }

}
