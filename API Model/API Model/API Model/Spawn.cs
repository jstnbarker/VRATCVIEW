using Program;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float speed;
    public float heading;
    public Vector3 spawnValues;
    float time;
    float timeDelay;
    ArrayList planeArray;
    public GameObject planePrefab;
    void createNewPlanes(ArrayList planeArray)
    {
        planeArray = Program.Program.Main(null);
        foreach (airplane plane in planeArray)
        {
            float latitude = (float)plane.y;
            float longitude = (float)plane.x;
            float altitude = (float)plane.z;
            spawnValues = new Vector3(latitude, altitude, longitude);
            GameObject newPlane = (GameObject)Instantiate(planePrefab, spawnValues, Quaternion.identity);
            newPlane.tag = "Plane";
            WaitForSeconds(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Started");
        ArrayList planeArray = Program.Program.Main(null);
        Console.WriteLine("Main ran");
        time = 0f;
        timeDelay = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        Console.WriteLine("Update started");
        time = time + (1f * Time.deltaTime);
        if (time >= timeDelay)
        {
            time = 0f;
            GameObject[] planeObjects = (GameObject[])GameObject.FindGameObjectsWithTag("Plane");
            //GameObject[] allObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
            foreach (GameObject obj in planeObjects)
            {
                Destroy(obj);
            }
            createNewPlanes(planeArray);
        }
    }

    private void WaitForSeconds(int v)
    {
        throw new NotImplementedException();
    }
}
