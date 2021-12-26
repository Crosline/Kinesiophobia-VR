using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour {

    [SerializeField]
    private GameObject blockCanvas;
    [SerializeField]
    private VideoPlayer videoPlayer;
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


    public IEnumerator deneme() {
        Debug.Log(videoPlayer.url);
        //videoPlayer.url = "D:" + Path.DirectorySeparatorChar + "Downloads" + Path.DirectorySeparatorChar + "1.mp4";
        //deneme works
        videoPlayer.url = VideoManager.instance.GetSelectedVideo();
        Debug.Log(videoPlayer.url);
        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        yield return new WaitForSeconds(10f);
        blockCanvas.SetActive(false);
        videoPlayer.Play();
        yield return new WaitUntil(() => videoPlayer.isPaused);
        SceneManager.LoadScene(2);


    }
}
