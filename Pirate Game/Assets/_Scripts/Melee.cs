using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

    [SerializeField]
    float SwingSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.down * SwingSpeed * Time.deltaTime);
	}
}
