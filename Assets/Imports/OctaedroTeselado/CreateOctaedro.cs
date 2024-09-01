using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CreateOctaedro : MonoBehaviour
{
    List<Vector3> geometry;
    List<int> topology;
    MeshFilter mf;
    MeshRenderer mr;
    public int iterations = 1;

    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        geometry = new List<Vector3>()
        {
            new Vector3(0, 0, 1), // A - 0
            new Vector3(1, 0, 0),// B - 1
            new Vector3(0, 1, 0), // C - 2
            new Vector3(0, 0, -1), // D - 3
            new Vector3(-1, 0, 0), // E - 4
            new Vector3(0, -1, 0), // F - 5
        };

        topology = new List<int>() {
            // Top
            0, 1, 2,
            1, 3, 2,
            3, 4, 2,
            4, 0, 2,
            //Bottom
            5, 1, 0,
            5, 3, 1,
            5, 4, 3,
            5, 0, 4
        };

        //int limit = topology.Count;
        //for (int j = 0; j < limit; j += 3)
        //{
        //    List<int> division = Subdivide(new List<int> { topology[j], topology[j + 1], topology[j + 2] });
        //    foreach (int t in division) topology.Add(t);
        //}
        //topology.RemoveRange(0, limit);

        Teselate(iterations);

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        Mesh miMesh = new Mesh();
        miMesh.vertices = geometry.ToArray();
        miMesh.triangles = topology.ToArray();
        miMesh.RecalculateBounds();
        miMesh.RecalculateNormals();
        mf.sharedMesh = miMesh;

        mr = gameObject.AddComponent<MeshRenderer>();

        if (material != null)
        {
            mr.material = material; // Asigna el material
        }
       
    }

    public void Teselate(int iterations)
    {
        int limit;
        for (int i = 1; i <= iterations; i++)
        {
            limit = topology.Count;
            for (int j = 0; j < limit; j += 3)
            {
                List<int> division = Subdivide(new List<int> { topology[j], topology[j + 1], topology[j + 2] });
                foreach (int t in division) topology.Add(t);
            }
            topology.RemoveRange(0, limit);
        }
    }

    /// <summary>
    /// Subdivides a triangle
    /// </summary>
    /// <param name="triangle">1 triangle (in form of 3 ints)</param>
    /// <returns>4 triangles (in form in 12 ints)</returns>
    List<int> Subdivide(List<int> triangle)
    {

        // Original Vertices
        int vA = triangle[0];
        int vB = triangle[1];
        int vC = triangle[2];
        int vD, vE, vF;

        // MidPoints
        Vector3 D = ((geometry[vA] + geometry[vB]) / 2).normalized; // Paso 2 de teselado
        Vector3 E = ((geometry[vB] + geometry[vC]) / 2).normalized;
        Vector3 F = ((geometry[vA] + geometry[vC]) / 2).normalized;

        if (geometry.Contains(D)) vD = geometry.IndexOf(D);
        else
        {
            vD = geometry.Count;
            geometry.Add(D);
        }
        if (geometry.Contains(E)) vE = geometry.IndexOf(E);
        else
        {
            vE = geometry.Count;
            geometry.Add(E);
        }
        if (geometry.Contains(F)) vF = geometry.IndexOf(F);
        else
        {
            vF = geometry.Count;
            geometry.Add(F);
        }

        List<int> triangles = new List<int>() { vA, vD, vF, vD, vB, vE, vF, vE, vC, vD, vE, vF };

        return triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
