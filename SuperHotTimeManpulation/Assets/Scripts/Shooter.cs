using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MovePlayer();
        RotatePlayer(MousePos);

        if (Input.GetMouseButtonDown(0))
            Shoot();

    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
    }

    void MovePlayer()
    {
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * 10 * Time.fixedDeltaTime);
    }

    void RotatePlayer(Vector2 MousePos)
    {
        Vector2 LookDir = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
        transform.up = LookDir;
    }
}
