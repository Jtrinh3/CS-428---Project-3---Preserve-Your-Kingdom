using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundScript : MonoBehaviour
{
    private GameObject roundNumberText, roundCountText, baloon;
    public GameObject Tank, FlyingTank;
    public GameObject baddies;
    public int roundNumber;
    public int roundCount = 5;
    private int enemyNumber, enemiesCreated;
    public int enemiesLeft = 100;
    public bool roundchange = false;
    private int counter = 0;

    //changes what round the castle flies at
    private int FLYINGCASTLE = 2;



    public void startMatch()
    {
        StartCoroutine(roundChange());
    }

    //spawns tank
    private void spawnTank()
    {
        float x = Random.Range(40f, 70f);
        float z = Random.Range(40f, 70f);
        float nx = Random.Range(-40f, -70f);
        float nz = Random.Range(-40f, -70f);

        switch ((int)Random.Range(1f, 4f))
        {
            case 1:
                Object.Instantiate(Tank, new Vector3(x, 3, z), Quaternion.identity, baddies.transform);
                break;

            case 2:
                Object.Instantiate(Tank, new Vector3(nx, 3, z), Quaternion.identity, baddies.transform);
                break;

            case 3:
                Object.Instantiate(Tank, new Vector3(x, 3, nz), Quaternion.identity, baddies.transform);
                break;

            case 4:
                Object.Instantiate(Tank, new Vector3(nx, 3, nz), Quaternion.identity, baddies.transform);
                break;

        }


        enemiesCreated++;
    }

    //spawns tank
    private void spawnFlyingTank()
    {
        float x = Random.Range(40f, 70f);
        float z = Random.Range(40f, 70f);
        float y = Random.Range(3f, 50f);
        float nx = Random.Range(-40f, -70f);
        float nz = Random.Range(-40f, -70f);

        switch ((int)Random.Range(1f, 4f))
        {
            case 1:
                Object.Instantiate(FlyingTank, new Vector3(x, y, z), Quaternion.identity, baddies.transform);
                break;

            case 2:
                Object.Instantiate(FlyingTank, new Vector3(nx, y, z), Quaternion.identity, baddies.transform);
                break;

            case 3:
                Object.Instantiate(FlyingTank, new Vector3(x, y, nz), Quaternion.identity, baddies.transform);
                break;

            case 4:
                Object.Instantiate(FlyingTank, new Vector3(nx, y, nz), Quaternion.identity, baddies.transform);
                break;


        }


        enemiesCreated++;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = 100;
        roundNumberText = GameObject.Find("Round Number");
        roundNumberText.SetActive(false);
        roundNumber = 0;
        roundCountText = GameObject.Find("RoundCount");
        roundCountText.SetActive(false);
        roundCount = 5;

        baloon = GameObject.Find("Hot Air Baloon");
        baloon.SetActive(false);


        Random.InitState(2);

    }

    //changes round
    IEnumerator roundChange()
    {
        roundCountText.SetActive(true);
        while (roundCount >= 0)
        {
            if (roundCount == 0)
            {
                roundCountText.SetActive(false);
                StopCoroutine("roundChange");
                roundNumber++;
                roundNumberText.GetComponent<TextMesh>().text = "Round " + roundNumber.ToString();
                roundStart();
            }
            else roundCountText.SetActive(true);

            if (roundNumber == FLYINGCASTLE-1 && roundCount == 5)
            {
                CastleFly();
            }

            roundCountText.GetComponent<TextMesh>().text = roundCount.ToString();
            roundCount--;
            yield return new WaitForSeconds(1f);


        }
    }

    //spawns enemies
    //TODO make it so it can spawn more than one kind of enemy
    private IEnumerator enemySpawner()
    {
        while (enemiesCreated < enemyNumber)
        {
            //uncomment when new enemies are made and the castle flies 
            //(new enimies will be needed at that point and the tank wouldn't 
            //make sense flying so it only needs to be until the casle flies)
            if (roundNumber == FLYINGCASTLE-1)
            {
                spawnTank();
            }
            else if (roundNumber >= FLYINGCASTLE)
                spawnFlyingTank();
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    private void roundStart()
    {
        enemiesCreated = 0;
        enemyNumber = 1 + roundNumber * 3; // change number of enemies that appear in a round
        enemiesLeft = enemyNumber;

        //more routines more enimies spawn at once (total number spawned uneffected)
        Coroutine[] spawners = new Coroutine[roundNumber];
        for (int i = 0; i < roundNumber; i++)
        {
            spawners[i] = StartCoroutine(enemySpawner());
        }

    }

    //checks for end of round and goes to next round if true
    private bool checkEndRound()
    {
        if (enemiesLeft <= 0)
        {
            roundCount = 5;
            roundCountText.SetActive(true);
            roundCountText.GetComponent<TextMesh>().text = roundCount.ToString();
            enemiesLeft = 1000;
            StartCoroutine(roundChange());
            return roundchange = true;


        }
        return false;
    }


    private void CastleFly()
    {
        baloon.SetActive(true);
        growPlayer();
        InvokeRepeating("floating", .2f, .3f);
    }

    private void floating()
    {
        if (counter == 4)
        {
            counter = 0;
            CancelInvoke();
            InvokeRepeating("groundDrop", .2f, .05f);

        }
        counter++;

        GameObject castle = GameObject.Find("Castle");
        castle.transform.localPosition += new Vector3(0.0f, 0.0f, 0.02f);

    }

    private void groundDrop()
    {
        if (counter == 1000)
        {
            counter = 0;
            CancelInvoke();
        }
        counter++;
        GameObject.Find("Ground").transform.position += new Vector3(0f, -.2f, 0f);
    }

    private void growPlayer()
    {
        GameObject.Find("TrackedAlias").transform.localScale = new Vector3(15f, 15f, 15f);
   
    }



    // Update is called once per frame
    void Update()
    {
        checkEndRound();
    }
}
