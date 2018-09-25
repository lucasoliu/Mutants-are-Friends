using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<List<GameObject>> tiles;

    // Tile Types
    public GameObject floor;
    public GameObject wall;
    public GameObject water;
    public GameObject door;

    // Items
    public GameObject device;
    public GameObject dna;
    public GameObject key;

    // Player Objects
    public GameObject player;
    public GameObject bird;

    //public AudioSource music;

    // Use this for initialization
    void Awake()
    {
        /*music = GetComponent<AudioSource>();
        music.time = Utils.musicOffset;
        music.Play();*/
        string sceneName = SceneManager.GetActiveScene().name;
        if (Utils.Level0 == sceneName)
        {
            initializeLevel0();
        }
        else if (Utils.Level1 == sceneName)
        {
            initializeLevel1();
        }
        else if (Utils.Level2 == sceneName)
        {
            initializeLevel2();
        }
        else if (Utils.Level3 == sceneName)
        {
            initializeLevel3();
        }
    }

    // Create Tiles
    private void initializeLevel0()
    {
        GameObject currentTile;
        tiles = new List<List<GameObject>>();
        for (int x = 0; x < 7; x++)
        {
            List<GameObject> currentCol = new List<GameObject>();
            tiles.Add(currentCol);
            for (int y = 0; y < 5; y++)
            {

                if (x == 0 || x == 6 || y == 0 || y == 4)
                {
                    currentTile = Instantiate(wall, Utils.indexToVector(x, y, Utils.tileLayer),
                                                     Quaternion.identity);
                }
                else
                {
                    currentTile = Instantiate(floor, Utils.indexToVector(x, y, Utils.tileLayer),
                                                     Quaternion.identity);
                }
                currentCol.Add(currentTile);
            }
        }
        currentTile = tiles[3][3];
        tiles[3][3] = Instantiate(water, Utils.indexToVector(3, 3, Utils.tileLayer),
                                  Quaternion.identity);
        Destroy(currentTile);
        currentTile = tiles[4][3];
        tiles[4][3] = Instantiate(water, Utils.indexToVector(4, 3, Utils.tileLayer),
                                  Quaternion.identity);
        Destroy(currentTile);

        Instantiate(player, Utils.indexToVector(1, 1, Utils.playerLayer), Quaternion.identity);
        Instantiate(device, Utils.indexToVector(1, 3, Utils.playerLayer), Quaternion.identity);
        Instantiate(dna, Utils.indexToVector(3, 1, Utils.playerLayer), Quaternion.identity);
        //Instantiate(bird, Utils.indexToVector(2, 1, Utils.playerLayer), Quaternion.identity);
        Instantiate(key, Utils.indexToVector(5, 1, Utils.playerLayer), Quaternion.identity);
        Instantiate(door, Utils.indexToVector(5, 3, Utils.playerLayer), Quaternion.identity);
    }

    private void initializeLevel1()
    {
        tiles = new List<List<GameObject>>();
        for (int x = 0; x < 11; x++)
        {
            tiles.Add(new List<GameObject>());
            for (int y = 0; y < 3; y++)
            {
                tiles[x].Add(null);
            }
        }

        for (int x = 1; x < 10; x++)
        {
            tiles[x][1] = Instantiate(floor, Utils.indexToVector(x, 1, Utils.tileLayer), Quaternion.identity);
        }

        for (int x = 0; x < 11; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (tiles[x][y] == null)
                {
                    tiles[x][y] = Instantiate(wall, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
                }
            }
        }

        tiles[7][1] = Instantiate(key, Utils.indexToVector(7, 1, Utils.playerLayer), Quaternion.identity);
        tiles[9][1] = Instantiate(door, Utils.indexToVector(9, 1, Utils.playerLayer), Quaternion.identity);
        Instantiate(player, Utils.indexToVector(1, 1, Utils.playerLayer), Quaternion.identity);
    }

    private void initializeLevel2()
    {
        tiles = new List<List<GameObject>>();
        for (int x = 0; x < 16; x++)
        {
            tiles.Add(new List<GameObject>());
            for (int y = 0; y < 13; y++)
            {
                tiles[x].Add(null);
            }
        }

        for (int x = 1; x < 7; x++)
        {
            tiles[x][11] = Instantiate(floor, Utils.indexToVector(x, 11, Utils.tileLayer), Quaternion.identity);
        }
        for (int x = 1; x < 15; x++)
        {
            tiles[x][1] = Instantiate(floor, Utils.indexToVector(x, 1, Utils.tileLayer), Quaternion.identity);
        }
        for (int y = 1; y < 12; y++)
        {
            tiles[6][y] = Instantiate(floor, Utils.indexToVector(6, y, Utils.tileLayer), Quaternion.identity);
        }

        for (int x = 1; x < 5; x++)
        {
            for (int y = 5; y < 10; y++)
            {
                tiles[x][y] = Instantiate(floor, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
            }
        }
        tiles[5][6] = Instantiate(floor, Utils.indexToVector(5, 6, Utils.tileLayer), Quaternion.identity);
        tiles[5][7] = Instantiate(floor, Utils.indexToVector(5, 7, Utils.tileLayer), Quaternion.identity);
        tiles[5][8] = Instantiate(floor, Utils.indexToVector(5, 8, Utils.tileLayer), Quaternion.identity);

        for (int x = 8; x < 15; x++)
        {
            for (int y = 4; y < 9; y++)
            {
                tiles[x][y] = Instantiate(floor, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
            }
        }
        //tiles[7][5] = Instantiate(floor, Utils.indexToVector(7, 5, Utils.tileLayer), Quaternion.identity);
        tiles[7][6] = Instantiate(floor, Utils.indexToVector(7, 6, Utils.tileLayer), Quaternion.identity);
        tiles[7][7] = Instantiate(floor, Utils.indexToVector(7, 7, Utils.tileLayer), Quaternion.identity);
        tiles[7][8] = Instantiate(floor, Utils.indexToVector(7, 8, Utils.tileLayer), Quaternion.identity);

        tiles[10][7] = Instantiate(water, Utils.indexToVector(10, 7, Utils.tileLayer), Quaternion.identity);
        tiles[10][6] = Instantiate(water, Utils.indexToVector(10, 6, Utils.tileLayer), Quaternion.identity);
        tiles[10][5] = Instantiate(water, Utils.indexToVector(10, 5, Utils.tileLayer), Quaternion.identity);

        tiles[12][7] = Instantiate(water, Utils.indexToVector(12, 7, Utils.tileLayer), Quaternion.identity);
        tiles[12][6] = Instantiate(water, Utils.indexToVector(12, 6, Utils.tileLayer), Quaternion.identity);
        tiles[12][5] = Instantiate(water, Utils.indexToVector(12, 5, Utils.tileLayer), Quaternion.identity);

        tiles[11][7] = Instantiate(water, Utils.indexToVector(11, 7, Utils.tileLayer), Quaternion.identity);
        tiles[11][5] = Instantiate(water, Utils.indexToVector(11, 5, Utils.tileLayer), Quaternion.identity);

        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 13; y++)
            {
                if (tiles[x][y] == null)
                {
                    tiles[x][y] = Instantiate(wall, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
                }
            }
        }

        Instantiate(player, Utils.indexToVector(1, 11, Utils.playerLayer), Quaternion.identity);
        Instantiate(device, Utils.indexToVector(1, 1, Utils.playerLayer), Quaternion.identity);
        Instantiate(dna, Utils.indexToVector(14, 1, Utils.playerLayer), Quaternion.identity);
        tiles[2][7] = Instantiate(door, Utils.indexToVector(2, 7, Utils.playerLayer), Quaternion.identity);
        tiles[11][6] = Instantiate(key, Utils.indexToVector(11, 6, Utils.playerLayer), Quaternion.identity);
    }

    private void initializeLevel3()
    {
        tiles = new List<List<GameObject>>();
        for (int x = 0; x < 23; x++)
        {
            tiles.Add(new List<GameObject>());
            for (int y = 0; y < 15; y++)
            {
                tiles[x].Add(null);
            }
        }
        //left room
        for (int x = 2; x < 6; x++)
        {
            for (int y = 4; y < 9; y++)
            {
                tiles[x][y] = Instantiate(floor, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
            }
        }
        //right room
        for (int x = 17; x < 21; x++)
        {
            for (int y = 4; y < 9; y++)
            {
                tiles[x][y] = Instantiate(floor, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
            }
        }
        //top room
        for (int x = 10; x < 13; x++)
        {
            for (int y = 10; y < 13; y++)
            {
                tiles[x][y] = Instantiate(floor, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
            }
        }
        //middle horizontal corridor
        for (int x = 6; x < 17; x++)
        {
            tiles[x][6] = Instantiate(floor, Utils.indexToVector(x, 6, Utils.tileLayer), Quaternion.identity);
        }
        //middle vertical corridor
        for (int y = 7; y < 11; y++)
        {
            tiles[11][y] = Instantiate(floor, Utils.indexToVector(11, y, Utils.tileLayer), Quaternion.identity);
        }
        //island for key
        tiles[13][3] = Instantiate(floor, Utils.indexToVector(13, 3, Utils.tileLayer), Quaternion.identity);
        //rest are poison
        for (int x = 0; x < 23; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                if (x == 0 || x == 22 || y == 0 || y == 14)
                {
                    tiles[x][y] = Instantiate(wall, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
                }
                else if (tiles[x][y] == null)
                {
                    tiles[x][y] = Instantiate(water, Utils.indexToVector(x, y, Utils.tileLayer), Quaternion.identity);
                }
            }
        }
        //playerLayer
        Instantiate(player, Utils.indexToVector(11, 6, Utils.playerLayer), Quaternion.identity);
        Instantiate(device, Utils.indexToVector(3, 6, Utils.playerLayer), Quaternion.identity);
        Instantiate(dna, Utils.indexToVector(19, 6, Utils.playerLayer), Quaternion.identity);
        tiles[11][11] = Instantiate(door, Utils.indexToVector(11, 11, Utils.playerLayer), Quaternion.identity);
        tiles[13][3] = Instantiate(key, Utils.indexToVector(13, 3, Utils.playerLayer), Quaternion.identity);
    }
}