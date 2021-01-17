using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveManager : MonoBehaviour {

    private GameObject grass;
    private GameObject newObject;

    //instantiating
    public GameObject grassBlock;
    public GameObject carrot;

    void Start()
    {
        grass = GameObject.Find("Grass");
    }

    void Update()
    {

    }

    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.txt", FileMode.Open);
        PlayerData player = new PlayerData();

        //save credits
        player.credits = Credits.getCredits();

        //save grass blocks
        int grassBlockCount = grass.transform.childCount;
        player.grassBlockPosX = new float[grassBlockCount];
        player.grassBlockPosY = new float[grassBlockCount];
        player.grassBlockSorting = new int[grassBlockCount];

        int count = 0;
        foreach (Transform child in grass.transform)
        {            
            player.grassBlockPosX[count] = child.gameObject.transform.position.x;
            player.grassBlockPosY[count] = child.gameObject.transform.position.y;
            player.grassBlockSorting[count] = child.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            count++;
        }

        //save plants
        int plantCount = GameObject.FindGameObjectsWithTag("PlantPrefab").Length;

        player.plantName = new String[plantCount];
        player.plantPosX = new float[plantCount];
        player.plantPosY = new float[plantCount];
        player.growthTimer = new float[plantCount];
        player.growthStage = new int[plantCount];
        player.sortingLayer = new int[plantCount];
        
        count = 0;
        foreach (GameObject plant in GameObject.FindGameObjectsWithTag("PlantPrefab"))
        {
            String plantName = plant.gameObject.name;
            //remove (Clone) from the end of object name
            if ((plantName.Substring(plantName.Length - 7, 7)).Equals("(Clone)"))
            {
                player.plantName[count] = plantName.Substring(0, plantName.Length - 7);
            }
            else
            {
                player.plantName[count] = plant.gameObject.name;
            }

            player.plantPosX[count] = plant.transform.position.x;
            player.plantPosY[count] = plant.transform.position.y;
            Seeds script = plant.GetComponent<Seeds>();
            player.growthTimer[count] = script.timer;
            player.growthStage[count] = script.growthStage;
            player.sortingLayer[count] = script.sortingLayer;

            count++;
        }

        //finishing up
        binary.Serialize(file, player);
        file.Close();
    }

    public void Load()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.txt", FileMode.Open);
        PlayerData player = (PlayerData)binary.Deserialize(file);
        file.Close();

        //delete all existing grass blocks and plants
        foreach (GameObject plant in GameObject.FindGameObjectsWithTag("PlantPrefab"))
        {
            Destroy(plant);
        }
        foreach (GameObject grass in GameObject.FindGameObjectsWithTag("GrassBlock"))
        {
            Destroy(grass);
        }

        //load credits
        Credits.setCredits(player.credits);

        //load grass blocks
        int grassBlockCount = player.grassBlockPosX.Length;

        Vector3 pos;
        for (int i = 0; i < grassBlockCount; i++)
        {
            pos = new Vector3(player.grassBlockPosX[i], player.grassBlockPosY[i], 0);
            newObject = Instantiate(grassBlock, pos, Quaternion.identity) as GameObject;
            newObject.GetComponent<SpriteRenderer>().sortingOrder = player.grassBlockSorting[i];
            newObject.transform.SetParent(grass.transform, true);
        }

        //load plants
        int plantCount = player.plantPosX.Length;

        for (int i = 0; i < plantCount; i++)
        {
            pos = new Vector3(player.plantPosX[i], player.plantPosY[i], 0);
            Debug.Log("Prefabs/Plants/" + player.plantName[i]);
            newObject = Instantiate(Resources.Load(("Prefabs/Plants/" + player.plantName[i]), typeof(GameObject)), pos, Quaternion.identity) as GameObject;
            newObject.GetComponent<Seeds>().timer = player.growthTimer[i];
            newObject.GetComponent<Seeds>().growthStage = player.growthStage[i];
            newObject.GetComponent<SpriteRenderer>().sortingOrder = player.sortingLayer[i];
            newObject.GetComponent<Seeds>().sortingLayer = player.sortingLayer[i];
        }
        
    }
}

