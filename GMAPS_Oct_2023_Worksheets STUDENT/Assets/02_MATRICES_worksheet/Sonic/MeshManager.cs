﻿/* Note that Mesh.vertices returns a copy of the vertices array for a mesh.
 * 
 * From the Unity documentation: Returns a copy of the vertex positions or assigns a 
 * new vertex positions array.
 * 
 * Mesh.vertices is actually a C# property, that doesn't just return a value. See the 
 * source code here, if you're interested:
 * 
 * https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Graphics/Mesh.cs
 * (line 143)
 */

using UnityEngine;

public class MeshManager : MonoBehaviour
{
    private MeshFilter meshFilter;

    [HideInInspector]
    public Mesh originalMesh { get; private set; }
    public Mesh clonedMesh { get; private set; }

    public Vector3[] vertices { get; private set; }
    public int[] triangles { get; private set; }

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.sharedMesh;

        clonedMesh = new Mesh();
        clonedMesh.name = "clone";
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;

        meshFilter.mesh = clonedMesh;

        vertices = clonedMesh.vertices;
        triangles = clonedMesh.triangles;
    }

    
}

