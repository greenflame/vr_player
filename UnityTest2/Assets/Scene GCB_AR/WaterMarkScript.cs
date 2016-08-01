using UnityEngine;
using System.Collections;

public class WaterMarkScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Vertical position
        if (Input.touchCount == 1 && Input.GetTouch(0).position.x > Screen.width - 50)
        {
            transform.Translate(0, Input.GetTouch(0).deltaPosition.y, 0, Space.World);
        }

        // Rotate
        GameObject.Find("Arrow").transform.Rotate(0, -30 * Time.deltaTime, 0, Space.World);
    }
}
