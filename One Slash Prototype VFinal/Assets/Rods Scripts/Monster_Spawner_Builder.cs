using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spawner_Builder : MonoBehaviour {
    private int[,] currentMapData;
    public GameObject FireDemon1;
    public GameObject RockGolem2;
    public GameObject KnighKing3;
    public GameObject Icegiant4;
    public GameObject KnightsLvl2Prefab5;
    public GameObject KnightsLvl3Prefab6;
    public string rawMapData = "0,1,0; 1,0,1; 0,0,0; 1,1,1";


    private GameObject _currentWall;

    // Use this for initialization
    void Start()
    {
        //       ParseRawMapData();
        //       BuildMap();
       ReloadMap();
    }

    // Update is called once per frame
    void Update()
    {
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

        foreach (Transform _child in transform)
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
                if (currentMapData[rowCount, colCount] == 0)
                {

                }
                else if (currentMapData[rowCount, colCount] == 1)
                {
                    _currentWall = Instantiate(FireDemon1, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);

                }
                else if (currentMapData[rowCount, colCount] == 2)
                {
                    _currentWall = Instantiate(RockGolem2, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 3)
                {
                    _currentWall = Instantiate(KnighKing3, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 4)
                {
                    _currentWall = Instantiate(Icegiant4, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 5)
                {
                    _currentWall = Instantiate(KnightsLvl2Prefab5, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }
                else if (currentMapData[rowCount, colCount] == 6)
                {
                    _currentWall = Instantiate(KnightsLvl3Prefab6, transform);
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
