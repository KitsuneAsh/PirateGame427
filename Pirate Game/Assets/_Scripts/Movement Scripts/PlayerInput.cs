using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{



    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        position.z += speed * verticalMovement * Time.deltaTime;
        position.x += speed * horizontalMovement * Time.deltaTime;

        transform.position = position;
    }
}