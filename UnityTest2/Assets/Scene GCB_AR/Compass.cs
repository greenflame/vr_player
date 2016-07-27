using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Compass : MonoBehaviour {

    GameObject center;
    GameObject water_label;
    GameObject arrow;

    GameObject toggle;

	// Use this for initialization
	void Start () {
        Input.location.Start();
        Input.compass.enabled = true;

        center = GameObject.Find("Center");
        water_label = GameObject.Find("Water label");
        arrow = GameObject.Find("Arrow");
        toggle = GameObject.Find("Toggle");
    }

	// Update is called once per frame
	void Update () {

        if (toggle.GetComponent<Toggle>().isOn)
        {
            float compassAngle = Input.compass.trueHeading;

            Vector3 projection = transform.forward - Vector3.Project(transform.forward, Vector3.up);
            float cameraAngle = Mathf.Rad2Deg * Mathf.Atan2(projection.x, projection.z);


            float delta = compassAngle - cameraAngle;
            center.transform.rotation = Quaternion.Slerp(center.transform.rotation, Quaternion.Euler(0, center.transform.rotation.eulerAngles.y + delta, 0), Time.deltaTime / 2f);


            string message = String.Format("Hola! Compass: {0}, camera: {1}.", compassAngle, cameraAngle);
            GameObject.Find("Message text").GetComponent<Text>().text = message;
        }


        // Swipes
        if (Input.touchCount == 1)
        {
            center.transform.Rotate(0, -Input.GetTouch(0).deltaPosition.x, 0);
            water_label.transform.Translate(0, Input.GetTouch(0).deltaPosition.y, 0, Space.World);
        }

        // Arrow rotate
        arrow.transform.Rotate(0, -30 * Time.deltaTime, 0, Space.World);
    }
}
