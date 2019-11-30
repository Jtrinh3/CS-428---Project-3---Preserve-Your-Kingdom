using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundScript : MonoBehaviour
{
    public GameObject Tank, FlyingTank, Missle, UFO, GunUFO;    //list of enemies
    public GameObject baddies, alienBullet;
    private GameObject roundNumberText, roundCountText, castle, ground, 
                        baloon, castleRockets, rocketFire;
    private Vector3 castleRocketInitPos;
    public int roundNumber;
    public int roundCount = 5;
    public int enemyNumber, enemiesCreated;
    public int enemiesLeft = 100;
    public bool sky, space, roundchange = false;
    private int counter = 0;
    private bool gameOver = false;
    public Material skybox, spacebox;


    //changes what round the castle flies at
    private int FLYINGCASTLE = 2;
    private int SPACECASTLE = 3;


    public void startMatch()
    {
        StartCoroutine(roundChange());
    }

    //spawns enemy for ground rounds
    private void spawnGroundEnemy(GameObject Enemy)
    {
        float x = Random.Range(40f, 70f);
        float z = Random.Range(40f, 70f);
        float nx = Random.Range(-40f, -70f);
        float nz = Random.Range(-40f, -70f);

        switch ((int)Random.Range(1f, 4f))
        {
            case 1:
                Object.Instantiate(Enemy, new Vector3(x, 3, z), Quaternion.identity, baddies.transform);
                break;

            case 2:
                Object.Instantiate(Enemy, new Vector3(nx, 3, z), Quaternion.identity, baddies.transform);
                break;

            case 3:
                Object.Instantiate(Enemy, new Vector3(x, 3, nz), Quaternion.identity, baddies.transform);
                break;

            case 4:
                Object.Instantiate(Enemy, new Vector3(nx, 3, nz), Quaternion.identity, baddies.transform);
                break;

        }


        enemiesCreated++;
    }

    //spawns enemy around castle
    private void spawnFlyingEnemy(GameObject Enemy)
    {
        float x = Random.Range(40f, 70f);
        float z = Random.Range(40f, 70f);
        float y = Random.Range(3f, 50f);
        float nx = Random.Range(-40f, -70f);
        float nz = Random.Range(-40f, -70f);

        switch ((int)Random.Range(1f, 4f))
        {
            case 1:
                Object.Instantiate(Enemy, new Vector3(x, y, z), Quaternion.identity, baddies.transform);
                break;

            case 2:
                Object.Instantiate(Enemy, new Vector3(nx, y, z), Quaternion.identity, baddies.transform);
                break;

            case 3:
                Object.Instantiate(Enemy, new Vector3(x, y, nz), Quaternion.identity, baddies.transform);
                break;

            case 4:
                Object.Instantiate(Enemy, new Vector3(nx, y, nz), Quaternion.identity, baddies.transform);
                break;


        }


        enemiesCreated++;
    }

    //spawns enemy around castle, above, and below
    private void spawnSurroundEnemy(GameObject Enemy)
    {
        float x = Random.Range(40f, 70f);
        float z = Random.Range(40f, 70f);
        float y = Random.Range(3f, 50f);
        float nx = Random.Range(-40f, -70f);
        float nz = Random.Range(-40f, -70f);

        switch ((int)Random.Range(1f, 4f))
        {
            case 1:
                Object.Instantiate(Enemy, new Vector3(x, y, z), Quaternion.identity, baddies.transform);
                break;

            case 2:
                Object.Instantiate(Enemy, new Vector3(nx, y, z), Quaternion.identity, baddies.transform);
                break;

            case 3:
                Object.Instantiate(Enemy, new Vector3(x, y, nz), Quaternion.identity, baddies.transform);
                break;

            case 4:
                Object.Instantiate(Enemy, new Vector3(nx, y, nz), Quaternion.identity, baddies.transform);
                break;


        }


        enemiesCreated++;
    }

    //transition from one round to next
    IEnumerator roundChange()
    {
        roundCountText.SetActive(true);
        while (roundCount >= 0)
        {
            if (roundCount == 0)
            {
                castle.GetComponent<CastleScript>().heal(20);
                roundCountText.SetActive(false);
                StopCoroutine("roundChange");
                roundNumber++;
                roundNumberText.GetComponent<TextMesh>().text = "Round " + roundNumber.ToString();
                roundStart();
            }
            else roundCountText.SetActive(true);

            if (roundNumber == FLYINGCASTLE - 1 && !sky && roundCount == 5)
            {
                sky = true;
                CastleFly();
            }
            else if (roundNumber == SPACECASTLE - 1 && !space && roundCount == 5)
            {
                roundCount = 15;
                space = true;
                SpaceCastle();
            }

            roundCountText.GetComponent<TextMesh>().text = roundCount.ToString();
            roundCount--;
            yield return new WaitForSeconds(1f);


        }
    }

    //starts the round officially
    //creates enemy spawners
    private void roundStart()
    {
        roundchange = false;
        enemiesCreated = 0;
        enemyNumber = 1 + roundNumber * 2; // change number of enemies that appear in a round
        enemiesLeft = enemyNumber;

        //more routines more enimies spawn at once (total number spawned uneffected)
        //new routine added every 2nd round
        Coroutine[] spawners = new Coroutine[(int)(roundNumber / 2) + 1];
        for (int i = 0; i < (int)(roundNumber / 2) + 1; i++)
        {
            spawners[i] = StartCoroutine(enemySpawner());
        }



    }

    //spawns enemies
    //TODO make it so it can spawn more than one kind of enemy
    private IEnumerator enemySpawner()
    {
        while (enemiesCreated < enemyNumber)
        {

            yield return new WaitForSeconds(Random.Range(2f, 7f));

            if (enemiesCreated < enemyNumber)
            {

                //add enemies to first for gound enemies
                //second for space enemies
                //third for flying enemies
                if (roundNumber == FLYINGCASTLE - 1)
                {
                    spawnGroundEnemy(Tank);
                }
                else if (roundNumber >= SPACECASTLE)
                {
                    switch(((int)Random.Range(0,100) % 4)+1)
                    {
                        case 1:
                            spawnFlyingEnemy(UFO);
                            break;

                        case 2:
                            spawnFlyingEnemy(Missle);
                            break;

                        case 3:
                            spawnFlyingEnemy(GunUFO);
                            break;
                        case 4:
                            break;
                    }

                }
                else if (roundNumber >= FLYINGCASTLE)
                {
                    switch (((int)Random.Range(0, 100) % 3) + 1)
                    {
                        case 1:
                            spawnFlyingEnemy(FlyingTank);
                            break;

                        case 2:
                            spawnFlyingEnemy(Missle);
                            break;

                        case 3:
                            break;
                    }
                }
            }
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

            castle.GetComponent<CastleScript>().wipeDamageRoutine();
            StartCoroutine(roundChange());
            return roundchange = true;


        }
        return false;
    }

    //starts castle flying routine
    private void CastleFly()
    {
        StartCoroutine(inflateBaloon());
        growPlayer();
        InvokeRepeating("floating", .2f, .053f);
    }

    //makes balloon appear/grow
    private IEnumerator inflateBaloon()
    {
        baloon.SetActive(true);
        baloon.transform.GetChild(0).GetComponent<AudioSource>().Play();
        while (baloon.GetComponent<Transform>().localScale.z <= .000015)
        {
            baloon.GetComponent<Transform>().localScale += new Vector3(0f, 0f, .0000002f);
            yield return new WaitForSeconds(.01f);
        }
        StopCoroutine("inflateBaloon");

    }

    //makes castle float
    //activate with InvokeRepeating("floating", TIMEBEFORESTART, INTERVALTIME)
    private void floating()
    {
        if (counter == 30)
        {
            counter = 0;
            CancelInvoke();
            InvokeRepeating("groundDrop", .2f, .05f);

        }
        counter++;

        GameObject castle = GameObject.Find("Castle");
        castle.transform.localPosition += new Vector3(0.0f, 0.0f, 0.0033333f);

    }

    //drops ground until space round
    //activate with InvokeRepeating("groundDrop", TIMEBEFORESTART, INTERVALTIME)
    private void groundDrop()
    {
        if (counter == 1000)
        {
            counter = 0;
            CancelInvoke();
        }
        counter++;
        ground.transform.position += new Vector3(0f, -.2f, 0f);
    }

    private void growPlayer()
    {
        GameObject.Find("TrackedAlias").transform.localScale = new Vector3(15f, 15f, 15f);

    }

    //starts space castle routine
    private void SpaceCastle()
    {
        castleRockets.SetActive(true);

        StartCoroutine(moveRockets());

    }

    //rockets appear from bottom of castle
    private IEnumerator moveRockets()
    {
        castleRockets.GetComponent<AudioSource>().Play();
        while(castleRockets.GetComponent<Transform>().localPosition != castleRocketInitPos)
        {

            castleRockets.GetComponent<Transform>().localPosition -= new Vector3(0f, 0f, .001f);
            yield return new WaitForSeconds(.1f);

        }
        castleRockets.GetComponent<AudioSource>().Stop();
        StartCoroutine(deflateBaloon());
    }

    //shinks/vanishes balloon
    private IEnumerator deflateBaloon()
    {
        baloon.GetComponent<AudioSource>().Play();
        while (baloon.GetComponent<Transform>().localScale.z > .000001f)
        {
            baloon.GetComponent<Transform>().localScale -= new Vector3(0f, 0f, .00000004f);
            yield return new WaitForSeconds(.01f);
        }
        baloon.SetActive(false);
        StartCoroutine(startRockets());
    }

    //makes rockets fire
    private IEnumerator startRockets()
    {
        rocketFire.SetActive(true);
        GameObject.Find("FireHolder").GetComponent<AudioSource>().Play();
        for (int i = 0; i < 5; i++)
        {
            if (i == 1)
            {
                CancelInvoke("groundDrop");
            }
            if (i == 2)
            {
                ground.SetActive(false);
            }
            if(i == 3)
            {
                roundCountText.GetComponent<TextMesh>().color = new Color(1, 1, 1, 1);
                roundNumberText.GetComponent<TextMesh>().color = new Color(1, 1, 1, 1);
                RenderSettings.skybox = spacebox;
                RenderSettings.fog = false;

            }
            if(i == 4)
            {
                GameObject.Find("FireHolder").GetComponent<AudioSource>().Stop();
            }
            yield return new WaitForSeconds(1f);
        }
    }



    //game over routine
    public void EndGame()
    {
        roundCountText.SetActive(true);
        roundCountText.transform.localPosition -= new Vector3(0,0,-2);
        roundCountText.GetComponent<TextMesh>().fontSize -= 8;
        roundCountText.GetComponent<TextMesh>().text = "Game Over";
        gameOver = true;
    }

    //starts before first frame
    void Start()
    {
        enemiesLeft = 100;
        roundNumberText = GameObject.Find("Round Number");
        roundNumberText.SetActive(false);
        roundNumber = 0;
        roundCountText = GameObject.Find("RoundCount");
        roundCountText.SetActive(false);
        roundCount = 5;

        castle = GameObject.Find("Castle");
        ground = GameObject.Find("Ground");

        baloon = GameObject.Find("Hot Air Baloon");
        baloon.SetActive(false);

        rocketFire = GameObject.Find("FireHolder");
        rocketFire.SetActive(false);

        castleRockets = GameObject.Find("Castle Rockets");
        castleRocketInitPos = castleRockets.GetComponent<Transform>().localPosition;
        castleRockets.GetComponent<Transform>().localPosition = new Vector3(0, .07f, .032f);
        castleRockets.SetActive(false);

        //uncomment to seed random
        //Random.InitState(2);

    }



    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
            checkEndRound();
    }
}
