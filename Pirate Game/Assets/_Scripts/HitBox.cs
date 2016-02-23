using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

    private Rigidbody rb;

    [SerializePrivateVariables]
    int DamageValue;
    

	// Use this for initialization
	void Start () {
	    rb = gameObject.GetComponent<Rigidbody>(); 
	}
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollision( GameObject other) {
        Debug.Log(gameObject.name + " has hit " + other.name);
        if (other.GetComponent<Health>())
        {
            Health TargetHealth = other.GetComponent<Health>();
            TargetHealth.Damage(DamageValue);
        }
    }

}
