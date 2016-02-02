using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Ground
{
    // width of 1 ground tile
    public static float DEFAULT_GROUND_SIZE = 10.24f;

    public Ground(string name, float width)
    {
        this.name = name;
        this.width = width;
    }
    
    string name;
    float width;

    public string getName()
    {
        return name;
    }

    public float getWidth()
    {
        return width;
    }

    public void reset()
    {
        BranchFall.thisBranchFall.reset();
    }

    // get GameObject from name
    public GameObject getGameObject()
    {
        return GameObject.Find(this.name);
    }

    // show GameObject at given position
    public void showAtPosition(float position)
    {
        
        GameObject groundObj = getGameObject();
        Vector3 pos = groundObj.transform.position;
        pos.y = 0;
        pos.x = position;
        groundObj.transform.position = pos;
    }
}

public class GameMain : MonoBehaviour {
    // names for Scenes (makes it easier)
    public static int START_MENU = 0;
    public static int LEVEL_1 = 1;
    public static int MENU_MINI_GAME1 = 2;
    public static int MINI_GAME1 = 3;
    public static int DEATH_SCREEN = 4;

    public static int currentLevel = 0;

    [SerializeField]
    public float witchAfterSeconds = 3.0f;

    private static Ground witchGround = new Ground("witch_ground", Ground.DEFAULT_GROUND_SIZE);

    // time the level started
    private float startTime;

    public static float screenWidth;
    public static float screenHeight;

    // all known ground tiles for the level generator
    private ArrayList grounds;

    // pool of currently NOT used tiles the level generator can use
    private ArrayList groundPool;

    // ground tiles currently in use
    private ArrayList groundInUse = new ArrayList();
    
    private float nextTilePos = 0;

    void Awake()
    {
        startTime = Time.realtimeSinceStartup;
        if (grounds == null)
        {
            grounds = new ArrayList();
            // get screen width/height for Check if we are OutOfView and 
            // when the level generator needs to create new Level Pieces
            GameMain.screenHeight = Camera.main.orthographicSize * 2;
            GameMain.screenWidth = screenHeight * Screen.width / Screen.height; // basically height * screen aspect ratio

            // add all available grounds to the pool
            grounds.Add(new Ground("ground1", Ground.DEFAULT_GROUND_SIZE));
            grounds.Add(new Ground("ground2", Ground.DEFAULT_GROUND_SIZE));
            grounds.Add(new Ground("ground3", Ground.DEFAULT_GROUND_SIZE));
            grounds.Add(new Ground("ground4", Ground.DEFAULT_GROUND_SIZE));
            grounds.Add(new Ground("ground8", Ground.DEFAULT_GROUND_SIZE));
            grounds.Add(new Ground("ground10", Ground.DEFAULT_GROUND_SIZE));

            groundPool = (ArrayList)grounds.Clone();

            foreach (Ground ground in grounds)
            {
                ground.showAtPosition(-GameMain.screenWidth);
            }

            
        }
        nextTilePos = 0;
        levelGeneration();
    }

    void Update()
    {
        levelGeneration();
    }

    public static int nextLevel()
    {
        return 1;
    }

    void levelGeneration()
    {
        float curPos = Camera.main.transform.position.x;
        while (nextTilePos < curPos + GameMain.screenWidth)
        {
            Ground ground;
            if (Time.realtimeSinceStartup - this.startTime > this.witchAfterSeconds &&
                    groundInUse.IndexOf(witchGround) == -1)
            {
                //time is up - show witch tile next
                ground = witchGround;
            }
            else {
                float rand = UnityEngine.Random.value * groundPool.Count;
                ground = (Ground)groundPool[(int)rand];

                // remove from pool that stores the currently unused tiles and set as in use
                groundPool.RemoveAt((int)rand);
            }
            groundInUse.Add(ground);

            // show current tile
            ground.showAtPosition(nextTilePos);

            // the next ground tile should be shown after this one
            nextTilePos += ground.getWidth();
            while (true)
            {
                Ground firstGround = (Ground)groundInUse[0];
                if (firstGround.getGameObject().transform.position.x + firstGround.getWidth() < curPos)
                {
                    firstGround.reset();
                    groundInUse.Remove(firstGround);
                    groundPool.Add(firstGround);
                }
                else
                {
                    break;
                }
            }
            
        }
    }

    // player died, show main screen again and jump back to the start scene
    public static void OnPlayerDied()
    {
        // this will reset to the first level
        SceneManager.LoadScene(GameMain.DEATH_SCREEN);
        //SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
        // TODO: show Main UI Screen
    }
}
