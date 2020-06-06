using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalMeshMorpher : MonoBehaviour
{
    Mesh crystalMesh;
    List<Vector3> newVerts = new List<Vector3>();
    public float growSpeed;
    public int meshSkipCount;
    List<int> vertsToAffect = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        crystalMesh = GetComponent<MeshFilter>().mesh;

        for (int i = 0; i < crystalMesh.vertexCount; i += meshSkipCount)
        {
            foreach (int vertIndex in FindNearbyVertexIndecies(i))
            {
                vertsToAffect.Add(vertIndex);
            }
        }
    }

    List<int> FindNearbyVertexIndecies(int vertIndex)
    {
        List<int> nearbyVerts = new List<int>();
        nearbyVerts.Add(vertIndex);

        for(int i = 0; i < crystalMesh.vertices.Length; i++)
        {
            Vector3 worldPosVertIndex = transform.TransformPoint(crystalMesh.vertices[vertIndex]);
            Vector3 worldPosThisIndex = transform.TransformPoint(crystalMesh.vertices[i]);

            if (Vector3.Distance(worldPosThisIndex, worldPosVertIndex) < .001f)
            {
                if (!vertsToAffect.Contains(i))
                    nearbyVerts.Add(i);
            }
        }

        return nearbyVerts;
    }

    // Update is called once per frame
    void Update()
    {
        newVerts = crystalMesh.vertices.ToList();

        for(int i = 0; i < vertsToAffect.Count; i++)
        {
            newVerts[i] = crystalMesh.vertices[i] + crystalMesh.normals[i] * (Mathf.Sin(Time.time) * growSpeed);
        }

        crystalMesh.SetVertices(newVerts);
        
    }
}
