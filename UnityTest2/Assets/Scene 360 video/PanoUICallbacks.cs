using UnityEngine;
using System.Collections;

public class PanoUICallbacks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void quality1000p()
    {
        MediaPlayerCtrl player = FindObjectOfType<MediaPlayerCtrl>();
        player.Stop();
        player.UnLoad();
        player.Load("http://192.168.53.238/video_streams/beach_1000x500_30/index.m3u8");
        player.Play();
    }

    public void quality1920p()
    {
        MediaPlayerCtrl player = FindObjectOfType<MediaPlayerCtrl>();
        player.Stop();
        player.UnLoad();
        player.Load("http://192.168.53.238/video_streams/beach_1920x960_30/index.m3u8");
        player.Play();
    }
}
