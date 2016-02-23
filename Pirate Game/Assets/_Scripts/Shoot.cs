using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private float RateOfFire = 0.5f;
    private float NextFire = 0.0f;
    [SerializeField]
    private Transform ProjectileSpawn;


    [SerializeField]
    private GameObject Ammo;

	// Use this for initialization
	void Start () {
        // InvokeRepeating will invoke a the method in x seconds and then repeat every y seconds
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + RateOfFire;
            //GameObject clone = Instantiate(Projectile, ProjectileSpawn.position, ProjectileSpawn.rotation) as GameObject; //Use This code if you need a reference to the shot you fired?
            Instantiate(Ammo, transform.position, Quaternion.Euler(0, 0, 0));
        }
	}

    public void FireProjectile()
    {
        Instantiate(Ammo,gameObject.transform.position, gameObject.transform.rotation);
    }


}