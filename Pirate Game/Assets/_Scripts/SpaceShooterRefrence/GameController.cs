using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] hazards;
    [SerializeField]
    private int HazardCount;
    [SerializeField]
    private Vector3 SpawnValues;
    
    [SerializeField]
    private float InitialWait;
    [SerializeField]
    private float WaitBetweenSpawns;

    [SerializeField]
    private float WaitBetweenWaves;


    //UI Stuff
    [SerializeField]
    private GUIText ScoreText;
    private int Score;
    [SerializeField]
    private GUIText RestartText;
    private bool Restart = false;
    [SerializeField]
    private GUIText GameOverText;
    private bool GameOver = false;


    // Use this for initialization
    void Start ()
    {
        GameOver = false;
        Restart = false;
        GameOverText.text = "";
        RestartText.text = "";
        Score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());

        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Restart == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            
        }
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(InitialWait);
        while(true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(hazard, SpawnPosition, SpawnRotation);
                yield return new WaitForSeconds(WaitBetweenSpawns);
            }
            yield return new WaitForSeconds(WaitBetweenWaves);

            if (GameOver == true)
            {
                RestartText.text = "Press R to Restart";
                Restart = true;
                break;
            }
        }
    }

    public void AddScore(int AddToScore)
    {
        Score += AddToScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;

    }

    public void EndGame()
    {
        GameOverText.text = "GAME OVER";
        GameOver = true;
    }

}
