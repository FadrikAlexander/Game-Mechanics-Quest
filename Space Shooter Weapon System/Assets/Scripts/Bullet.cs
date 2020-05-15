using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Class that represent the Bullet
//Because the bullet is independent from the system all the properties must conatin here
//Speed to type of bullet to maybe what kind of damage it should Give
public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;
    //[SerializeField] float Damage; //The Ability to Add Damage
    //[SerializeField] BulletType; //Maybe Armour Piercing or EMP

    void Awake() //Change to OnEnable when Adding a MasterPool
    {
        Invoke("DestroyBullet", 10); //Destroy the Bullet after 10sec
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false); //Change to this When Adding a MasterPool
    }

    void Update() //Bullet Movement Script
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") //When it find an enemy Destroy it
        {
            Destroy(other.gameObject);
            DestroyBullet();
        }
    }
}
