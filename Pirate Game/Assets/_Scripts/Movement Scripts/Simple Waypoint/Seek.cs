using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
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

        //velocity_current = velocity_current.normalized * MaxSpeed;
        //Vector3 velocity_desired = (target - position).normalized * MaxSpeed;
        //Vector3 steering = velocity_desired - velocity_current;
        //steering = truncate(steering, MaxSteer) * Time.deltaTime;
        ////steering = steering / mass;
        //velocity_current = truncate((velocity_current + steering), MaxSpeed) * Time.deltaTime;
        //transform.position = (position + velocity_current);

        velocity_current = velocity_current.normalized * MaxSpeed;
        velocity_current = Vector3.RotateTowards(velocity_current,(target.transform.position-position), (MaxSteer * Time.deltaTime),0);
        transform.position = (position + (velocity_current * Time.deltaTime));

        Debug.DrawLine(position, (position + velocity_current), Color.blue);

    }

    //public static Vector3 truncate(Vector3 force, float max)
    //{
    //    if (force.magnitude > max)
    //    {
    //        force = force.normalized * max;
    //        return force;
    //    }
    //    else return force;
    //}
}