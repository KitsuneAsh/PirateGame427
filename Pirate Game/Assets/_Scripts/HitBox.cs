using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

    private Rigidbody rb;

    [SerializeField]
    float DamageValue;
    

	// Use this for initialization
	void Start () {
	    rb = gameObject.GetComponent<Rigidbody>(); 
	}
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionEnter( Collision other) {
        //Debug.Log(gameObject.name + " has hit " + other.gameObject.name);
        if (other.gameObject.GetComponent<Health>())
        {
            Health TargetHealth = other.gameObject.GetComponent<Health>();
            TargetHealth.Damage(DamageValue);
        }
    }

}
