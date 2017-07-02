using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{

    public GameObject StarToGenerateAround; 

    public float MinimumDistance = 5f; 

    public float SystemRadius = 25f;

    public int NumberOfObjects = 50;

    public GameObject ObjectPrefab;

    public List<GameObject> AsteroidModelPrefabs; 

	// Use this for initialization
	void Start () {



	    if (ObjectPrefab != null && StarToGenerateAround != null)
	    {
	        QualitySettings.antiAliasing = 8;
	        GenerateObjects();
	    }

		
	}

    private void GenerateObjects()
    {
        Vector3 starPosition = StarToGenerateAround.transform.position;

        for (int i = 0; i < NumberOfObjects; i++)
        {
            Quaternion angleFromStar = Quaternion.Euler(RandomAngle(), 0, 0);
            Vector3 distance = new Vector3(RandomSolarDistance(), 0, 0);

            // Vector3 locationOfNewObject = angleFromStar * distance + starPosition;
            // Vector3 locationOfNewObject = new Vector3(10, 10, 10);

            GameObject obj = Instantiate(ObjectPrefab, distance + starPosition, Quaternion.identity, StarToGenerateAround.transform.parent);

            var modelPrefab = AsteroidModelPrefabs[Mathf.RoundToInt(Random.Range(0, AsteroidModelPrefabs.Count - 1))];
            GameObject model = Instantiate(modelPrefab, Vector3.zero, Quaternion.identity, obj.transform);
            model.transform.localPosition = Vector3.zero;

            float rotateY = RandomAngle();
            float rotateX = RandomAngle();

            obj.transform.RotateAround(starPosition, Vector3.up, rotateY);
            obj.transform.RotateAround(starPosition, Vector3.right, rotateX);
            // obj.GetComponent<Asteroid>().Angle = Quaternion.Euler(rotateX, rotateY, 0);
        }
    }

    private float RandomAngle()
    {
        return Random.Range(-360, 360);
    }

    private float RandomSolarDistance()
    {
        int factor = 1;
        if (Random.value < 0.5)
        {
            factor = -1;
        }

        return factor * Random.Range(MinimumDistance, SystemRadius);
    }

    // Update is called once per frame
	void Update () {
		
	}
}
