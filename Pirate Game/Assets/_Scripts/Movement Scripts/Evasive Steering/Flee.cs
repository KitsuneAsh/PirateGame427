using UnityEngine;
using System.Collections;

public class Flee : MonoBehaviour
{

    // Use this for initialization

    void Start()
    {
        velocity_current = Vector3.forward;
    }

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float MaxSpeed = 3;
    [SerializeField]
    private float MaxSteer = 3;

    private Vector3 velocity_current;


    // Update is called once per frame
    void Update()
    {


        Vector3 position = transform.position;

        velocity_current = velocity_current.normalized * MaxSpeed;
        velocity_current = Vector3.RotateTowards(velocity_current,(target.transform.position-position), (MaxSteer * Time.deltaTime),0);
        transform.position = (position - (velocity_current * Time.deltaTime));

    }

 
}
