using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Space_SolarSystem : MonoBehaviour {

    public GameObject sun;
    public GameObject planet;
   

    void planetGeneration(int numberOfPlanets)
    {
        for (int x = 0; x < numberOfPlanets; x++)
        {
            float xAxis = Random.Range(-10000, 10000);
            float yAxis = Random.Range(-10000, 10000);
            float zAxis = Random.Range(-10000, 10000);
            planet.transform.position = new Vector3(xAxis, yAxis, zAxis);
            Instantiate(planet);
        }
    }



	// Use this for initialization
	void Start () {
        int planetCount = Random.Range(1, 5);
        planetGeneration(planetCount);


        float sunSize = Random.Range(0, 0.55f);
        sun.transform.localPosition = new Vector3(0, 0, 0);
        sun.transform.localScale = new Vector3(sunSize,sunSize,sunSize);
        Instantiate(sun);

        


	}
	

}
