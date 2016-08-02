using UnityEngine;
using System.Collections;

public class MyMenuItem : MonoBehaviour
{
    private Vector3 BaseScale;
    private float HighlightScale = 1.2f;

    // Use this for initialization
    void Start ()
    {
        BaseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPointerHover())
        {
            transform.localScale = Vector3.Lerp(transform.localScale, BaseScale * HighlightScale, Time.deltaTime * 2.5f);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, BaseScale, Time.deltaTime * 2.5f);
        }
	}

    bool isPointerHover()
    {
        RaycastHit hit;
        GameObject camera = GameObject.Find("Main Camera");

        bool pointerHover = false;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100))
        {
            if (hit.transform.gameObject == transform.gameObject)
            {
                pointerHover = true;
            }
        }

        return pointerHover;
    }
}
