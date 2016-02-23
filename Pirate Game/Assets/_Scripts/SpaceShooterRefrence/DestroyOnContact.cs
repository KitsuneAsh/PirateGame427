using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{

    [SerializeField]
    private GameObject DeathEffect;

    [SerializeField]
    private GameObject CollisionEffect;

    private GameController ScoreBoard;
    [SerializeField]
    private int ScoreValue;

    void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            ScoreBoard = GameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find the 'GameController' object");
        }
        
    }


    void OnTriggerEnter(Collider other)
    {
        // Ignore Collisions with Boundary
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        
        //Explode When Dead
        if (DeathEffect != null)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
        }
        

        //Player Explodes When hit as well (I dont like doing it with tags, this code could use an array or library or something to match effects with object types/withComponents)
        // Or just Give the Player their own Death Because But Whatever.
        if (other.tag == "Player")
        {
            Instantiate(CollisionEffect, other.transform.position, other.transform.rotation);
            ScoreBoard.EndGame();
        }
        

        ScoreBoard.AddScore(ScoreValue);

        // Destoy Both Objects on the Next Frame
        Destroy(other.gameObject);
        Destroy(gameObject);

    }

}
