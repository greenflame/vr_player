using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Compass : MonoBehaviour
{
    float compassAngle = 0;

    // Use this for initialization
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool useCompass = GameObject.Find("Toggle").GetComponent<Toggle>().isOn;

        // Find compass direction
        if (useCompass)  // Use real compass
        {
            compassAngle = Input.compass.trueHeading;
        }
        else    // Or read value from imput
        {
            if (Input.touchCount == 1)
            {
                Vector2 compassCenter = GameObject.Find("ImageCompass").GetComponent<RectTransform>().transform.position;

                if ((compassCenter - Input.GetTouch(0).position).magnitude < 200)
                {
                    Vector2 newAngleV = Input.GetTouch(0).position - compassCenter;
                    Vector2 oldAngleV = newAngleV - Input.GetTouch(0).deltaPosition;

                    float newAngle = Mathf.Rad2Deg * Mathf.Atan2(newAngleV.x, newAngleV.y);
                    float oldAngle = Mathf.Rad2Deg * Mathf.Atan2(oldAngleV.x, oldAngleV.y);

                    compassAngle -= (newAngle - oldAngle) * 4;
                }
            }
        }

        // Calculate camera direction
        GameObject camera = GameObject.Find("Camera");
        Vector3 projection = camera.transform.forward - Vector3.Project(camera.transform.forward, Vector3.up);
        float cameraAngle = Mathf.Rad2Deg * Mathf.Atan2(projection.x, projection.z);

        // Apply calibration
        float delta = compassAngle - cameraAngle;
        GameObject center = GameObject.Find("Center");

        if (useCompass) // Smooth rotation
        {
            center.transform.rotation = Quaternion.Slerp(center.transform.rotation, Quaternion.Euler(0, center.transform.rotation.eulerAngles.y + delta, 0), 2f * Time.deltaTime);
        }
        else
        {
            center.transform.rotation = Quaternion.Euler(0, center.transform.rotation.eulerAngles.y + delta, 0);
        }


        // Update ui : Label
        string message = String.Format("Compass: {0}, camera: {1}.", compassAngle, cameraAngle);
        GameObject.Find("Message text").GetComponent<Text>().text = message;

        // Compass picture
        GameObject.Find("ImageCompass").transform.rotation = Quaternion.Euler(0, 0, compassAngle);
    }
}
