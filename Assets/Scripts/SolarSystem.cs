using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public GameObject StarToGenerateAround; 

    public float MinimumDistance = 5f; 

    public float SystemRadius = 25f;

    public int NumberOfObjects = 50;

    public GameObject AsteroidPrefab;

    public List<GameObject> AsteroidModelPrefabs; 

    private readonly System.Random _randomNumbers = new System.Random();

    // Use this for initialization
    void Start () {
        
        if (AsteroidPrefab != null && StarToGenerateAround != null)
        {
            GenerateObjects();
        }
    }

    private void GenerateObjects()
    {
        Vector3 starPosition = StarToGenerateAround.transform.position;

        for (int i = 0; i < NumberOfObjects; i++)
        {
            Vector3 distance = Quaternion.Euler(RandomAngle(), RandomAngle(), RandomAngle()) * new Vector3(RandomSolarDistance(), 0, 0);

            GameObject asteroid = Instantiate(AsteroidPrefab, StarToGenerateAround.transform.parent, true);
            asteroid.transform.position = starPosition;

            var prefabIndex = _randomNumbers.Next(0, AsteroidModelPrefabs.Count);
            Debug.Log("Picking prefab at index: " + prefabIndex);
            var modelPrefab = AsteroidModelPrefabs[prefabIndex];

            GameObject model = Instantiate(modelPrefab, asteroid.transform, true);
            model.transform.localPosition = distance;

            var asteroidComponent = asteroid.GetComponent<Asteroid>();
            asteroidComponent.AsteroidModel = model;
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
}
