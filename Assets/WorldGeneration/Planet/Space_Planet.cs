using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Planet : MonoBehaviour {

    [Range(2,256)]
    public int resolution = 10;

    public ShapeSettings shapeSettings;
    public ColorSettings colorSettings;
    ShapeGenerator shapeGenerator;


    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    Space_TerrainFace[] terrainFaces;

    


    void Initialize()
    {
        shapeGenerator = new ShapeGenerator(shapeSettings);


        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new Space_TerrainFace[6];
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {

                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;


                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new Space_TerrainFace(shapeGenerator,meshFilters[i].sharedMesh,resolution,directions[i]);

        }
    }

    public void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        GenerateColors();
    }

    public void OnShapeSettingsUpdated()
    {
        Initialize();
        GenerateMesh();
    }


    public void OnColorSettingsUpdated()
    {
        Initialize();
        GenerateColors();
    }


    void GenerateMesh()
    {
        foreach(Space_TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }


    void GenerateColors()
    {
        foreach(MeshFilter m in meshFilters)
        {
            m.GetComponent<MeshRenderer>().sharedMaterial.color = colorSettings.planetColor;
        }
    }

    public float rotationSpeed;


    private void OnValidate()
    {
        GeneratePlanet();
    }
    void Start()
    {
        rotationSpeed = Random.Range(-20, -1);
    GeneratePlanet();
    }
    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
    }


}
