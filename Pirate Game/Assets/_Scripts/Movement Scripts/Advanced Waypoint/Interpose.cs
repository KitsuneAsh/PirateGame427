using UnityEngine;
using System.Collections;

public class Interpose : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        velocity_current = Vector3.forward;
        target1_current = target1.transform.position;
        target2_current = target2.transform.position;
    }


    [SerializeField]
    private GameObject target1;
    [SerializeField]
    private float target1_distance = 3;


    [SerializeField]
    private GameObject target2;
    [SerializeField]
    private float target2_distance = 3;

    [SerializeField]
    private float MaxSpeed = 3;
    [SerializeField]
    private float MaxSteer = 3;

    private Vector3 velocity_current;
    private Vector3 target1_current;
    private Vector3 target2_current;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 target1_previuos = target1_current;

        target1_current = target1.transform.position;
        Vector3 target1_velocity = target1_previuos - target1_current;
        target1_velocity = target1_velocity.normalized * target1_distance;
        Vector3 target1_predict = target1_current - target1_velocity;

        Debug.DrawLine(target1.transform.position, target1_predict, Color.blue);

        velocity_current = velocity_current.normalized * MaxSpeed;
        velocity_current = Vector3.RotateTowards(velocity_current, (target1_predict - position), (MaxSteer), 0);

        Debug.DrawLine(position, target1_predict, Color.yellow);
        //Debug.DrawLine(position, (position + velocity_current), Color.red);

        Vector3 target2_previuos = target2_current;

        target2_current = target2.transform.position;
        Vector3 target2_velocity = target2_previuos - target1_current;
        target2_velocity = target2_velocity.normalized * target2_distance;
        Vector3 target2_predict = target2_current - target2_velocity;

        Debug.DrawLine(target2.transform.position, target2_predict, Color.cyan);

        velocity_current = velocity_current.normalized * MaxSpeed;
        velocity_current = Vector3.RotateTowards(velocity_current, (target2_predict - position), (MaxSteer), 0);

        Debug.DrawLine(position, target2_predict, Color.yellow);
        //Debug.DrawLine(position, (position + velocity_current), Color.red);

        //Vector3 midpoint = target1_predict - target2_predict;
        //Debug.DrawLine(position, midpoint, Color.red);
        //Debug.DrawLine(target1_predict, target2_predict, Color.red);

        // -----------------------Seek the Midpoint -----------------------

        //velocity_current = velocity_current.normalized * MaxSpeed;
        //velocity_current = Vector3.RotateTowards(velocity_current, (midpoint - position), (MaxSteer * Time.deltaTime), 0);

        transform.position = (position + (velocity_current * Time.deltaTime));

        //Debug.DrawLine(position, (position + velocity_current), Color.green);

        //transform.position = (position + (velocity_current * Time.deltaTime));
    }
}