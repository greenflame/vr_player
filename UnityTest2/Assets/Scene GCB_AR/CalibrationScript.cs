using UnityEngine;
using System.Collections;

public class CalibrationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Calculate camera direction
        GameObject camera = GameObject.Find("Camera");
        Vector3 projection = camera.transform.forward - Vector3.Project(camera.transform.forward, Vector3.up);
        float cameraAngle = Mathf.Rad2Deg * Mathf.Atan2(projection.x, projection.z);

        // Apply calibration
        float delta = FindObjectOfType<CompassScript>().CompassAngle - cameraAngle;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y + delta, 0), 2f * Time.deltaTime);

    }
}
