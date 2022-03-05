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
    [SerializeField]
    private VideoPlayer flatVideoPlayer;

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

        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.One))
        {
            ReLoadVideo();
        }

	}



    public IEnumerator deneme() {
        videoPlayer.url = VideoManager.instance.GetSelectedVideo(0);
        Debug.Log(VideoManager.instance.GetSelectedVideo(0));
        flatVideoPlayer.url = VideoManager.instance.GetSelectedVideo(1);
        Debug.Log(VideoManager.instance.GetSelectedVideo(1));

        videoPlayer.Prepare();
        flatVideoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        yield return new WaitForSeconds(10f);
		_isPlaying = true;
        blockCanvas.SetActive(false);
        videoPlayer.Play();
        flatVideoPlayer.Play();
        flatVideoPlayer.GetComponent<MeshRenderer>().enabled = _flatEnabled;
        yield return new WaitUntil(() => videoPlayer.isPaused);
        SceneManager.LoadScene(2);


    }


    public void ReLoadVideo(InputAction.CallbackContext context)
    {
        ReLoadVideo();
    }

    private void ReLoadVideo()
    {
        _flatEnabled = !_flatEnabled;

        flatVideoPlayer.GetComponent<MeshRenderer>().enabled = _flatEnabled;
    }
}
