using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject DebugPrefab;

    public bool IsOrbiting = true;

    public float _orbitSpeed = 100f;

    private Transform _starTransform;
    private float _distanceFromStar;
    private Quaternion _orbitAngle;
    private Vector3 _axis;


    public bool invertX = false;

    public bool invertY = false;

    public bool invertZ = false;
    private float _angleAboutZAxis;
    private float _angleAboutXAxis;
    public Quaternion Angle { get; set; }

    public Vector3 InitialPosition;

    private float angleX;
    private float angleY;

    // Use this for initialization
    void Start()
    {
        _starTransform = GetComponentInParent<SolarSystem>().StarToGenerateAround.transform;

        angleX = Angle.eulerAngles.x;
        angleY = Angle.eulerAngles.y;

        Vector3 vectorToAsteroidFromStar = this.transform.position - _starTransform.position;
        _distanceFromStar = vectorToAsteroidFromStar.magnitude;


        _angleAboutZAxis = Mathf.Sin(vectorToAsteroidFromStar.y / vectorToAsteroidFromStar.magnitude) * Mathf.Rad2Deg;
        _angleAboutXAxis = Mathf.Sin(vectorToAsteroidFromStar.x / vectorToAsteroidFromStar.magnitude) * Mathf.Rad2Deg;
        _orbitAngle = Quaternion.Euler(_angleAboutXAxis, 0, _angleAboutZAxis);

        float ignored;
        Angle.ToAngleAxis(out ignored, out _axis);
        InitialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //const float rotateSpeed = 5f;

        //this.transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, 0, Space.Self);
        
        if (false)
        {
            Instantiate(DebugPrefab, this.transform.position, Quaternion.identity);

            Vector3 vectorToAsteroidFromStar = this.transform.position - _starTransform.position;
            int xFactor = InitialPosition.x < 0 ? 1 : 1;
            int yFactor = InitialPosition.y < 0 ? 1 : 1;
            int zFactor = InitialPosition.z < 0 ? 1 : 1;

            // _axis = new Vector3(-1, 1, -1).normalized;
            
            //// Rotating around the z axis, because the orbit could be tilted
            //Vector3 directionToAsteroid = vectorToAsteroidFromStar.normalized;

            //var moveAngle = _orbitAngle * Quaternion.Euler(0, _orbitSpeed, 0) * directionToAsteroid;

            //var axis = new Vector3(xFactor * _axis.x, yFactor * _axis.y, zFactor * _axis.z);

            ////this.transform.RotateAround(_starTransform.position, Vector3.forward, _orbitSpeed * Time.deltaTime);
            ////this.transform.RotateAround(_starTransform.position, Vector3.up, _orbitSpeed * Time.deltaTime);
            ////this.transform.RotateAround(_starTransform.position, Vector3.right, _orbitSpeed * Time.deltaTime);
            
            //this.transform.RotateAround(_starTransform.position, _starTransform.right, -1 * _orbitSpeed * Time.deltaTime);
            //this.transform.RotateAround(_starTransform.position, _starTransform.up, _orbitSpeed * Time.deltaTime);

            angleX += _orbitSpeed * Time.deltaTime;
            angleY += _orbitSpeed * Time.deltaTime;

            // this.transform.rotation = Quaternion.AngleAxis(angleX, Vector3.up) * Quaternion.AngleAxis(angleY, Vector3.right);
            var rotation = Quaternion.AngleAxis(angleX, Vector3.up) * Quaternion.AngleAxis(angleY, Vector3.right);
            this.transform.position = rotation * this.transform.position;
        }
    }
}

