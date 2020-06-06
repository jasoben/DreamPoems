using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalCreator : MonoBehaviour
{
    public Material crystalMaterial;
    Crystal crystal = new Crystal();
    public float growSpeed;

    // Start is called before the first frame update
    void Start()
    {
        crystal = new Crystal();
        crystal.m_Material = crystalMaterial;
        crystal.InitAsIcosohedron();
        crystal.Subdivide(2);
        crystal.GenerateMesh();

        crystal.m_crystalMesh.transform.position = new Vector3(0, 20, 0);

    }

    // Update is called once per frame
    void Update()
    {
        List<Vector3> newVerts = crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.vertices.ToList<Vector3>();

        for (int i = 0; i < crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.vertices.Length; i += 12)
        {
            Vector3 worldVertexPos = crystal.m_crystalMesh.transform.TransformPoint(crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.vertices[i]);
            Vector3 normalDirection = worldVertexPos - crystal.m_crystalMesh.transform.position;

            normalDirection = normalDirection.normalized;

            newVerts[i] = crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.vertices[i] + (normalDirection * Mathf.Sin(Time.time) * growSpeed);
            Debug.Log(Mathf.Sin(Time.time));
            }

        crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.SetVertices(newVerts);
    }

    List<int> CheckForNearbyVertices(Vector3 worldPos, int index)
    {
        List<int> nearbyVerts = new List<int>();
        nearbyVerts.Add(index);

        for (int i =0; i < crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.vertices.Length; i++)
        {
            Vector3 localPos = crystal.m_crystalMesh.GetComponent<MeshFilter>().mesh.vertices[i];

            if (Vector3.Distance(crystal.m_crystalMesh.transform.TransformPoint(localPos), worldPos) < .2f)
            {
                nearbyVerts.Add(i);
            }
        }

        return nearbyVerts;
    }
}
