using UnityEngine;
using System.Collections;

public class OffsetPursuit : MonoBehaviour {


    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float MaxSpeed = 3;
    [SerializeField]
    private float MaxSteer = 3;
    [SerializeField]
    private float Offset_radius = 3;
    //[SerializeField]
    //private float Offeset = 3;


    
    private Vector3 velocity_current;
    private Vector3 target_current;

    void Start () {
        velocity_current = Vector3.forward;
        target_current = target.transform.position;
	}

	// Update is called once per frame
    void Update()
    {

        Vector3 position = transform.position;
        Vector3 target_previuos = target_current;

        target_current = target.transform.position;
        Vector3 target_velocity = target_previuos - target_current;
        target_velocity = target_velocity.normalized * Offset_radius;
        Vector3 target_predict = target_current - target_velocity;

        //To construct the offset point:
        //localize the predicted target location (into our character’s local coordinate space) 
        //project the local target onto the character’s side-up plane, normalize that lateral offset, 
        //scale it by -R, add it to the local target point, and globalize that value.
        



        Debug.DrawLine(target.transform.position, target_predict, Color.blue);

        velocity_current = velocity_current.normalized * MaxSpeed;
        velocity_current = Vector3.RotateTowards(velocity_current, (target_predict - position), (MaxSteer * Time.deltaTime), 0);

        Debug.DrawLine(position, target_predict, Color.green);
        Debug.DrawLine(position, (position + velocity_current), Color.red);

        transform.position = (position + (velocity_current * Time.deltaTime));
    }

}     

