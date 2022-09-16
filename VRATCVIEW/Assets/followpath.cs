using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.Json;
using System.IO;
using System.IO.Stream;
using System;

public class followpath : MonoBehaviour
{
    string path = "./Trace_full_a04b8f.json";
    int step = 0; 
    string trace;

    // Start is called before the first frame update
    void Start()
    {
        FileStream F = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.None)
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
