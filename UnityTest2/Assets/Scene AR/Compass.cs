using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Compass : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Input.location.Start();
        Input.compass.enabled = true;
	}

	// Update is called once per frame
	void Update () {
        float compassAngle = -Input.compass.trueHeading;

        Vector3 projection = transform.forward - Vector3.Project(transform.forward, Vector3.up);
        float cameraAngle = Mathf.Rad2Deg * Mathf.Atan2(projection.x, projection.z);

        string message = String.Format("Hola! Compass: {0}, camera: {1}.", compassAngle, cameraAngle);

        GameObject.Find("Text").GetComponent<Text>().text = message;




        transform.Rotate(Vector3.up, 10f * Time.deltaTime);


        //tmp += 10f * Time.deltaTime;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -Input.compass.trueHeading, 0f), Time.deltaTime * 3f);


        //var xrot = Mathf.Atan2(Input.acceleration.z, Input.acceleration.y);
        //var yzmag = Mathf.Sqrt(Mathf.Pow(Input.acceleration.y, 2) + Mathf.Pow(Input.acceleration.z, 2));
        //var zrot = Mathf.Atan2(Input.acceleration.x, yzmag);

        //var xangle = xrot * (180 / Mathf.PI) + 90;
        //var zangle = -zrot * (180 / Mathf.PI);
        //transform.eulerAngles = new Vector3(xangle, 0, zangle - Input.compass.trueHeading);


        //transform.rotation = Quaternion.LookRotation(Input.compass.rawVector, Vector3.up);

        //transform.rotation = Quaternion.identity;

    }
}
