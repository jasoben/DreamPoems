using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCreator : MonoBehaviour
{
    public Material crystalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Crystal crystal = new Crystal();
        crystal.InitAsIcosohedron();
        crystal.Subdivide(2);
        crystal.GenerateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
