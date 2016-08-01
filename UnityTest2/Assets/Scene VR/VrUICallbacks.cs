using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VrUICallbacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onVrModClicked() {
        GameObject.Find("GvrViewerMain").GetComponent<GvrViewer>().VRModeEnabled = GameObject.Find("Toggle").GetComponent<Toggle>().isOn;
    }
}
