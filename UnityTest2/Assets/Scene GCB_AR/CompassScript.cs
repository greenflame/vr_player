using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CompassScript : MonoBehaviour
{
    public float CompassAngle { get; set; }

    const float RotationRadius = 200;
    const float RotationSensitivity = 4;

    // Use this for initialization
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;

        CompassAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool useCompass = GameObject.Find("Toggle").GetComponent<Toggle>().isOn;

        // Update compass direction
        if (useCompass)  // Use real compass
        {
            CompassAngle = Input.compass.trueHeading;
        }
        else    // Or read value from imput
        {
            if (Input.touchCount == 1)
            {
                Vector2 compassCenter = GameObject.Find("ImageCompass").GetComponent<RectTransform>().transform.position;

                if ((compassCenter - Input.GetTouch(0).position).magnitude < RotationRadius)
                {
                    Vector2 newAngleV = Input.GetTouch(0).position - compassCenter;
                    Vector2 oldAngleV = newAngleV - Input.GetTouch(0).deltaPosition;

                    float newAngle = Mathf.Rad2Deg * Mathf.Atan2(newAngleV.x, newAngleV.y);
                    float oldAngle = Mathf.Rad2Deg * Mathf.Atan2(oldAngleV.x, oldAngleV.y);

                    CompassAngle -= (newAngle - oldAngle) * RotationSensitivity;
                }
            }
        }

        // Rotate compass image
        GameObject.Find("ImageCompass").transform.rotation = Quaternion.Euler(0, 0, CompassAngle);
    }
}
