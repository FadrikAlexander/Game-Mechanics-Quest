using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBarrel : MonoBehaviour
{
    [SerializeField] GameObject Bullet; //The bullet that is going to be shot from the barrel
    public void Shoot()
    {
        Instantiate(Bullet, this.transform.position, this.transform.rotation);

        //You should replace the Instantiate with a MasterPool to make the game run faster
        //for the sake of this simple tutorial I'll skip that
    }
}
