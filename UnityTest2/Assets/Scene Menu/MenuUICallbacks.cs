using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUICallbacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void on360click()
    {
        SceneManager.LoadScene("Scene360Video");
    }

    public void onVRclick()
    {
        SceneManager.LoadScene("SceneVR");
    }

    public void onARclick()
    {
        SceneManager.LoadScene("SceneAR");
    }

    public void onBackClick()
    {
        SceneManager.LoadScene("SceneMenu");
    }
}
