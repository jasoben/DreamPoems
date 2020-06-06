using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDuplicator : MonoBehaviour
{

    public float farDistance;
    public int numberOfObjects;

    public GameObject crystal;
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < numberOfObjects; i++)
        {
            GameObject newCrystal = Instantiate(crystal);
            newCrystal.transform.Translate(new Vector3(Random.Range(0, farDistance), 0, Random.Range(0, farDistance)));
            newCrystal.transform.Rotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
