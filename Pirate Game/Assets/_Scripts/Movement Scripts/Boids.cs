using UnityEngine;
using System.Collections;

public class Boids : MonoBehaviour
{
    [SerializeField]
    private float spread = 10;
    [SerializeField]
    private float speed = 2;

    private Vector3 velocity;
    Boids[] b_array;

    // Use this for initialization
    void Start()
    {
        velocity = Vector3.zero;
    }
    
    // Update is called once per frame
    void Update()
    {
            b_array = FindObjectsOfType<Boids>();
            velocity = Vector3.zero;

            Vector3 v1 = Vector3.zero;
            Vector3 v2 = Vector3.zero;
            Vector3 v3 = Vector3.zero;

                v1 = rule1(this);
                v2 = rule2(this);
                v3 = rule3(this);


                Debug.DrawLine(transform.position, transform.position + v1, Color.blue);
                Debug.DrawLine(transform.position, transform.position - v2, Color.red);
                //Debug.DrawLine(transform.position, transform.position + v2, Color.yellow);


                velocity = velocity + v1;
                //Debug.DrawLine(b.transform.position, b.transform.position + b.velocity, Color.green);
                velocity = velocity + v2;
                //Debug.DrawLine(b.transform.position, b.transform.position + b.velocity, Color.green);
                velocity = velocity + v3;
                //Debug.DrawLine(b.transform.position, b.transform.position + b.velocity, Color.green);

                transform.position += (velocity * Time.deltaTime);
   

       }

    //==========================================
    private Vector3 rule1(Boids b)
    {
        Vector3 v = Vector3.zero;
        foreach (Boids b2 in b_array)
        {
            if (b2 != b)
            {
                v = v + b2.transform.position;
            }
        }
        v = v / (b_array.Length - 1);
        return ((v - b.transform.position) / speed);
    }
    //==========================================
    private Vector3 rule2(Boids b)
    {
        Vector3 v = Vector3.zero;
        foreach (Boids b2 in b_array)
        {
            if (b2 != b)
            {
                if ((b2.transform.position - b.transform.position).magnitude < spread)
                {
                    v = v - (b2.transform.position - b.transform.position);
                }
            }
        }
        return v;
    }
    //==========================================
    private Vector3 rule3(Boids b)
    {
        Vector3 v = Vector3.zero;
        foreach (Boids b2 in b_array)
        {
            if (b2 != b)
            {
                v = v + b2.velocity;
            }
        }
        v = (v - b.transform.position) / (b_array.Length - 1);
        return ((v - b.velocity) / b_array.Length);
    }
}