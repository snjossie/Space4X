using Assets.Scripts;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    public Vector3 RotateSpeed;

    public GameObject AsteroidModel { get; set; }

    public GameObject textPrefab;

    public string AsteroidName { get; private set; }

    private GameObject nameText;

    private GameObject asteroidNameParent;

    void Start()
    {
        asteroidNameParent = GameObject.FindWithTag("AsteroidNames");
        UpdateName();

        RotateSpeed = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    void Update()
    {
        UpdateName();

        AsteroidModel.transform.Rotate(RotateSpeed.x * Time.deltaTime, RotateSpeed.y * Time.deltaTime, RotateSpeed.z * Time.deltaTime, Space.Self);
    }

    private void UpdateName()
    {
        if (nameText == null)
        {
            AsteroidName = AsteroidNames.RandomName();

            nameText = new GameObject();
            nameText.transform.parent = this.transform;
            var textComponent = nameText.AddComponent<GUIText>();
            textComponent.text = AsteroidName;
        }

        var viewportPos = Camera.main.WorldToViewportPoint(AsteroidModel.transform.position);

        if (viewportPos.z >= 0 && viewportPos.x.IsBetweenIncludeLimits(0f, 1f) && viewportPos.y.IsBetweenIncludeLimits(0f, 1f))
        {
            nameText.SetActive(true);
            nameText.transform.position = viewportPos;
        }
        else
        {
            nameText.SetActive(false);
        }
    }
}

