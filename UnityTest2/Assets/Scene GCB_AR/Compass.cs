using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Compass : MonoBehaviour
{

    GameObject center;
    GameObject water_label;
    GameObject arrow;
    GameObject toggle;
    GameObject compass;

    float compassAngle = 0;

    // Use this for initialization
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;

        center = GameObject.Find("Center");
        toggle = GameObject.Find("Toggle");
        compass = GameObject.Find("ImageCompass");

        water_label = GameObject.Find("Water label");
        arrow = GameObject.Find("Arrow");
    }

    // Update is called once per frame
    void Update()
    {

        // Use real compass
        if (toggle.GetComponent<Toggle>().isOn)
        {
            compassAngle = Input.compass.trueHeading;
        }
        else
        {
            // Read compass from controller
            if (Input.touchCount == 1)
            {    
                compassAngle += -Input.GetTouch(0).deltaPosition.x;
            }
        }

        GameObject camera = GameObject.Find("Camera");
        Vector3 projection = camera.transform.forward - Vector3.Project(camera.transform.forward, Vector3.up);
        float cameraAngle = Mathf.Rad2Deg * Mathf.Atan2(projection.x, projection.z);


        float delta = compassAngle - cameraAngle;
        //center.transform.rotation = Quaternion.Slerp(center.transform.rotation, Quaternion.Euler(0, center.transform.rotation.eulerAngles.y + delta, 0), Time.deltaTime / 2f);
        center.transform.rotation = Quaternion.Slerp(center.transform.rotation, Quaternion.Euler(0, center.transform.rotation.eulerAngles.y + delta, 0), 0.1f);


        string message = String.Format("Compass: {0}, camera: {1}.", compassAngle, cameraAngle);
        GameObject.Find("Message text").GetComponent<Text>().text = message;


        // Arrow height
        if (Input.touchCount == 1)
        {
            water_label.transform.Translate(0, Input.GetTouch(0).deltaPosition.y, 0, Space.World);
        }

        // Arrow rotate
        arrow.transform.Rotate(0, -30 * Time.deltaTime, 0, Space.World);

        // Compass
        compass.transform.rotation = Quaternion.Euler(0, 0, compassAngle);
    }
}
