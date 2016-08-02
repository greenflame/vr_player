using UnityEngine;
using System.Collections;

public class ViewStabilizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Calculate camera direction
        GameObject camera = GameObject.Find("Main Camera");
        Vector3 projection = camera.transform.forward - Vector3.Project(camera.transform.forward, Vector3.up);
        float cameraAngle = Mathf.Rad2Deg * Mathf.Atan2(projection.x, projection.z);

        float aim = cameraAngle;
        float bound = 50;

        if (aim > bound)
        {
            aim = bound;
        }

        if (aim < -bound)
        {
            aim = -bound;
        }

        Quaternion destination = Quaternion.Euler(0, transform.rotation.eulerAngles.y - cameraAngle + aim, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, destination, 1f * Time.deltaTime);
    }
}
