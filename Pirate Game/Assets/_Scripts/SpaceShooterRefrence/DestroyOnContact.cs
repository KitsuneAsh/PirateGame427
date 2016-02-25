using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{

    [SerializeField]
    private GameObject DeathEffect;


    void Start()
    {
        
    }


    void OnCollisionEnter(Collision other)
    {
        
        //Explode When Dead
        if (DeathEffect != null)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
        }   

        // Destoy Both Objects on the Next Frame
        //Destroy(other.gameObject);
        Destroy(gameObject);

    }

}
