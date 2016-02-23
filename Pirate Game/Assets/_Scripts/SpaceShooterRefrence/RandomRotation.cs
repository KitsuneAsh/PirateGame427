using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

    [SerializeField]
    private float tumble;

    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * tumble;

    }

}
