using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;

    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform ShotSpawn;
    [SerializeField]
    private float FireRate;
    [SerializeField]
    private float ShotDelay;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        // InvokeRepeating will invoke a the method in x seconds and then repeat every y seconds
        InvokeRepeating("Fire", ShotDelay, FireRate);
	}
	
	void Fire ()
    {
        Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
        audioSource.Play();
	}
}
