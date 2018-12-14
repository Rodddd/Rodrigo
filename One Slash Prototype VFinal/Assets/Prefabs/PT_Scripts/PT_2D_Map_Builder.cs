﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_2D_Map_Builder : MonoBehaviour {
    private int[,] currentMapData;
    public GameObject PlayerPrefab9;
    public GameObject wallPrefab1;
    public GameObject Piller3;
    public GameObject exitPrefab2;
    public GameObject pickupPrefab4;
    public GameObject SandTilePrefab7;
    public GameObject Concrete8;
    public GameObject FireBowlPrefab5;
    public GameObject GrassPrefab6;
    public GameObject KnightLvl2Prefab10;
    public GameObject KnightLvl3Prefab11;
    public PT_camera_follow followCam;
    public string rawMapData = "0,1,0; 1,0,1; 0,0,0; 1,1,1";
    

    private GameObject _currentWall;

    // Use this for initialization
    void Start () {
 //       ParseRawMapData();
 //       BuildMap();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("r"))
        {
            if (rawMapData != "")
            {
                ReloadMap();
            }
        }
	}

    public void ReloadMap()
    {
        ClearMap();
        ParseRawMapData();
        BuildMap();
    }

    public void ClearMap()
    {
        
        foreach(Transform _child in transform)
        {
            Destroy(_child.gameObject);
        }
    }

    public void BuildMap()
    {

        //positive x is right 
        //negative y is down
        for (int rowCount = 0; rowCount < currentMapData.GetLength(0); rowCount++)
        {
            for (int colCount = 0; colCount < currentMapData.GetLength(1); colCount++)
            {
                if(currentMapData[rowCount, colCount] == 0)
                {

                }
                else if (currentMapData[rowCount, colCount] == 1)
                {
                    _currentWall = Instantiate(wallPrefab1, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);

                }
                else if (currentMapData[rowCount, colCount] == 2)
                {
                    _currentWall = Instantiate(exitPrefab2, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 3)
                {
                    _currentWall = Instantiate(Piller3, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 4)
                {
                    _currentWall = Instantiate(pickupPrefab4, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 5)
                {
                    _currentWall = Instantiate(FireBowlPrefab5, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 6)
                {
                    _currentWall = Instantiate(GrassPrefab6, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 7)
                {
                    _currentWall = Instantiate(SandTilePrefab7, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 8)
                {
                    _currentWall = Instantiate(Concrete8, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 9)
                {
                    _currentWall = Instantiate(PlayerPrefab9, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 10)
                {
                    _currentWall = Instantiate(KnightLvl2Prefab10, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 11)
                {
                    _currentWall = Instantiate(KnightLvl3Prefab11, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
            }

        }
    }

    public void ParseRawMapData()
    {
        //break the map string on semicolons
        string[] dataRows;
        dataRows = rawMapData.Split(';');
        int NumberOfRows = dataRows.Length;
        //break the first line on commas to get a number of columns
        string[] dataColumns = dataRows[0].Split(',');
        int NumberOfColumns = dataColumns.Length;
        //create a new array
        currentMapData = new int[NumberOfRows, NumberOfColumns];
        //loop through and load the data from each string into the array
        int rowCount = 0;
        foreach (string _row in dataRows)
        {
            dataColumns = _row.Split(',');
            int columnCount = 0;
            foreach (string _item in dataColumns)
            {
              //print(_item);
                
                currentMapData[rowCount, columnCount] = Convert.ToInt32(_item.Trim());
                columnCount++;
            }
            rowCount++;
        }
    }
}
