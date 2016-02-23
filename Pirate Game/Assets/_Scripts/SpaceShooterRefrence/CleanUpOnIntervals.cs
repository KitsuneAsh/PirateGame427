using UnityEngine;
using System.Collections;

public class CleanUpOnIntervals : MonoBehaviour
{

    [SerializeField]
    private float Lifetime;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

}
