using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    string[] speciesType  = new string[] { "Cod", "Bass", "Catfish", "Trout", "Salmon" };
    public string species = "water";
    public float length = 0f;
    public int value = 0;


    // Start is called before the first frame update
    void Awake()
    {
        //Awake means that this plays when it gets instanciated 
        RandomSpecies();
        RandomLength();
        RandomValue();
    }

    void RandomSpecies()
    {
        species = speciesType[Random.Range(0, speciesType.Length)];
        //Debug.Log(species);
    }
    void RandomLength()
    {
        length = Random.Range(0, 200f);
        //Debug.Log(length);
    }
    void RandomValue()
    {
        value = Random.Range(10 , 70);
       // Debug.Log(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    
}
