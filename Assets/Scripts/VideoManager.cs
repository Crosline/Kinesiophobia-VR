using System;
using UnityEngine;

public class VideoManager : MonoBehaviour {


    public static VideoManager instance;

    public String[] volleyballFemale = new String[6];   //0
    public String[] volleyballMale = new String[6];     //1

    public String[] basketballFemale = new String[6];   //2
    public String[] basketballMale = new String[6];     //3

    public String[] footballFemale = new String[6];     //4
    public String[] footballMale = new String[6];       //5

    private String selectedVideo;

    public int b = 0;
    public int g = 0;
    public int s = 0;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            GetAllVideos();
        }
    }
    private void GetAllVideos() {
        volleyballFemale = PlayerPrefsX.GetStringArray("VolleyballFemale", "", 6);
        volleyballMale = PlayerPrefsX.GetStringArray("VolleyballMale", "", 6);

        basketballFemale = PlayerPrefsX.GetStringArray("BasketballFemale", "", 6);
        basketballMale = PlayerPrefsX.GetStringArray("BasketballMale", "", 6);

        footballFemale = PlayerPrefsX.GetStringArray("FootballFemale", "", 6);
        footballMale = PlayerPrefsX.GetStringArray("FootballMale", "", 6);
    }
    public void UpdateVideos(int s, int i, String path) {
        if (s == 0) {
            volleyballFemale[i] = path;
            PlayerPrefsX.SetStringArray("VolleyballFemale", volleyballFemale);
        } else if (s == 1) {
            volleyballMale[i] = path;
            PlayerPrefsX.SetStringArray("VolleyballMale", volleyballMale);

        } else if (s == 2) {
            basketballFemale[i] = path;
            PlayerPrefsX.SetStringArray("BasketballFemale", basketballFemale);
        } else if (s == 3) {
            basketballMale[i] = path;
            PlayerPrefsX.SetStringArray("BasketballMale", basketballMale);

        } else if (s == 4) {
            footballFemale[i] = path;
            PlayerPrefsX.SetStringArray("FootballFemale", footballFemale);
        } else if (s == 5) {
            footballMale[i] = path;
            PlayerPrefsX.SetStringArray("FootballMale", footballMale);
        }

    }

    public string GetSelectedVideo() {
        if (b == 0) {
            if (g == 0) { //football male 5
                selectedVideo = footballMale[s];
            } else { //football female 4
                selectedVideo = footballFemale[s];
            }
        } else if (b == 1) {
            if (g == 0) {//volleyball male 1
                selectedVideo = volleyballMale[s];
            } else {//volleyball female 0
                selectedVideo = volleyballFemale[s];
            }
        } else if (b == 2) {
            if (g == 0) {//basketball male 3
                selectedVideo = basketballMale[s];
            } else {//basketball female 2
                selectedVideo = basketballFemale[s];
            }
        }
        return selectedVideo;
    }


}
