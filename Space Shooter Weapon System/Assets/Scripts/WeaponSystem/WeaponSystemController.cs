using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystemController : MonoBehaviour
{
    [SerializeField] List<WeaponBarrel> weaponBarrels; //List of all the weapon Barrels that the System owns

    public void Shoot() //Go to all the Barrels and shoot
    {
        foreach (WeaponBarrel weaponBarrel in weaponBarrels)
            weaponBarrel.Shoot();
    }
}
