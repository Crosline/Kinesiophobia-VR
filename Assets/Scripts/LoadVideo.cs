using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour {

    [SerializeField]
    private GameObject blockCanvas;
    [SerializeField]
    private VideoPlayer videoPlayer;

    private bool _isPlaying = false;


    private bool _flatEnabled = false;
    //private VideoClip video;

    // Start is called before the first frame update
    void Start() {
        if (videoPlayer == null) {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        if (blockCanvas == null) {
            blockCanvas = GameObject.Find("BlockingCanvas");
        }
        StartCoroutine(deneme());
    }
	
	void Update() {
		
		if (!_isPlaying) return;

        if (OVRInput.Get(OVRInput.Button.One))
        {
            if (!videoPlayer.isPaused)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
        }

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
        
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            videoPlayer.playbackSpeed *= 2;
        }
        
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            videoPlayer.playbackSpeed *= 0.5f;
        }

	}



    public IEnumerator deneme() {
        videoPlayer.url = VideoManager.instance.GetSelectedVideo(0);

        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        yield return new WaitForSeconds(3f);
		_isPlaying = true;
        blockCanvas.SetActive(false);
        videoPlayer.Play();

    }

}
