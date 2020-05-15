using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    //A list to all the weapon Systems that the ship has
    [SerializeField] List<WeaponSystemController> weaponSystemControllers;

    [SerializeField] int weaponLevel = 0; //The current weapon system level used

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            weaponSystemControllers[weaponLevel].Shoot();


        if (Input.GetKeyDown(KeyCode.Alpha1))
            LevelUp();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            LevelDown();
    }

    void LevelUp() //Go to the next weapon system
    {
        weaponLevel++;
        if (weaponLevel == weaponSystemControllers.Count)
            weaponLevel = weaponSystemControllers.Count - 1;
    }
    void LevelDown() //Go to the previous weapon System
    {
        weaponLevel--;
        if (weaponLevel < 0)
            weaponLevel = 0;
    }

}
