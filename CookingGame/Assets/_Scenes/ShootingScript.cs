using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] shooters;
    public GameObject enemy;
    public GameObject projectile;

    void Start()
    {
        shooters = new GameObject[8];
        CreateShooters();
        Invoke("Shoot", 0.25f);
    }

    void CreateShooters()
    {
        int space = 0;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(enemy, new Vector3(-7 + space, -4, 0), Quaternion.identity);
            space += 2;
        }
    }

    void Shoot()
    {
        float randomInterval = Random.Range(0.0f, 1.0f);  // can change this random time interval

        GameObject shootingEnemy = PickRandomShooter();
        Instantiate(projectile, shootingEnemy.transform.position, shootingEnemy.transform.rotation);

        Invoke("Shoot", randomInterval);
    }

    GameObject PickRandomShooter()
    {
        int randNumber = Random.Range(0, 8);
        return shooters[randNumber];
    }

    GameObject PickRandomProjectile()
    {
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
