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
        //Calls the Shape Generator Class
        shapeGenerator = new ShapeGenerator(shapeSettings);


        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }

        //Creates a new index of Terrain Faces
        terrainFaces = new Space_TerrainFace[6];
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };


        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                int meshNumber = 1;
                GameObject meshObj = new GameObject("Planet Mesh" + meshNumber.ToString());
                meshObj.transform.parent = transform;

                //Adds the Standard Grey Material
                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            //Calls the constructor in the Space_TerrainFace Class
            terrainFaces[i] = new Space_TerrainFace(shapeGenerator,meshFilters[i].sharedMesh,resolution,directions[i]);

        }
    }//End Initialize Function



    //Generates Planet Originally
    public void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        GenerateColors();
    }
    //Is Called if the Shape Settings are updated
    public void OnShapeSettingsUpdated()
    {
        Initialize();
        GenerateMesh();
    }

    //Calls if the Color Settings are Updated
    public void OnColorSettingsUpdated()
    {
        Initialize();
        GenerateColors();
    }

    //Generates all the meshes from the terrainFaces Variable index
    void GenerateMesh()
    {
        foreach(Space_TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    //Gets the Planet Color from the Color Settings
    void GenerateColors()
    {
        foreach(MeshFilter m in meshFilters)
        {
            m.GetComponent<MeshRenderer>().sharedMaterial.color = colorSettings.planetColor;
        }
    }
    //Rotation speed arond the sun
    public float rotationSpeed;

    //Updates the planet in the editor
    private void OnValidate()
    {
        GeneratePlanet();
    }

    //Is called when the game starts
    void Start()
    {
        rotationSpeed = Random.Range(-5, -1);
    GeneratePlanet();
    }

    //Called every tick to update all current things
    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime); //Rotates around the center point of 0,0,0
    }


}
