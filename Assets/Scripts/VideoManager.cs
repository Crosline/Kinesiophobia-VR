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

    public String[] volleyballFemaleFlat = new String[6];   //0
    public String[] volleyballMaleFlat = new String[6];     //1

    public String[] basketballFemaleFlat = new String[6];   //2
    public String[] basketballMaleFlat = new String[6];     //3

    public String[] footballFemaleFlat = new String[6];     //4
    public String[] footballMaleFlat = new String[6];       //5

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


        //Flat videos
        volleyballFemaleFlat = PlayerPrefsX.GetStringArray("VolleyballFemaleFlat", "", 6);
        volleyballMaleFlat = PlayerPrefsX.GetStringArray("VolleyballMaleFlat", "", 6);

        basketballFemaleFlat = PlayerPrefsX.GetStringArray("BasketballFemaleFlat", "", 6);
        basketballMaleFlat = PlayerPrefsX.GetStringArray("BasketballMaleFlat", "", 6);

        footballFemaleFlat = PlayerPrefsX.GetStringArray("FootballFemaleFlat", "", 6);
        footballMaleFlat = PlayerPrefsX.GetStringArray("FootballMaleFlat", "", 6);
    }
    public void UpdateVideos(int s, int i, String path, int videoType = 0) {
        if (s == 0) {
            volleyballFemale[i] = path;
            if (videoType == 0)
                PlayerPrefsX.SetStringArray("VolleyballFemale", volleyballFemale);
            else
                PlayerPrefsX.SetStringArray("VolleyballFemaleFlat", volleyballFemaleFlat);
        } else if (s == 1) {
            volleyballMale[i] = path;
            if (videoType == 0)
                PlayerPrefsX.SetStringArray("VolleyballMale", volleyballMale);
            else
                PlayerPrefsX.SetStringArray("VolleyballMaleFlat", volleyballMaleFlat);

        } else if (s == 2) {
            basketballFemale[i] = path;
            if (videoType == 0)
                PlayerPrefsX.SetStringArray("BasketballFemale", basketballFemale);
            else
                PlayerPrefsX.SetStringArray("BasketballFemaleFlat", basketballFemaleFlat);
        } else if (s == 3) {
            basketballMale[i] = path;
            if (videoType == 0)
                PlayerPrefsX.SetStringArray("BasketballMale", basketballMale);
            else
                PlayerPrefsX.SetStringArray("BasketballMaleFlat", basketballMaleFlat);

        } else if (s == 4) {
            footballFemale[i] = path;
            if (videoType == 0)
                PlayerPrefsX.SetStringArray("FootballFemale", footballFemale);
            else
                PlayerPrefsX.SetStringArray("FootballFemaleFlat", footballFemaleFlat);
        } else if (s == 5) {
            footballMale[i] = path;
            if (videoType == 0)
                PlayerPrefsX.SetStringArray("FootballMale", footballMale);
            else
                PlayerPrefsX.SetStringArray("FootballMaleFlat", footballMaleFlat);
        }

    }

    public string GetSelectedVideo(int videoType = 0) {
        if (videoType == 0) {
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
        } else {
            if (b == 0) {
                if (g == 0) { //football male 5
                    selectedVideo = footballMaleFlat[s];
                } else { //football female 4
                    selectedVideo = footballFemaleFlat[s];
                }
            } else if (b == 1) {
                if (g == 0) {//volleyball male 1
                    selectedVideo = volleyballMaleFlat[s];
                } else {//volleyball female 0
                    selectedVideo = volleyballFemaleFlat[s];
                }
            } else if (b == 2) {
                if (g == 0) {//basketball male 3
                    selectedVideo = basketballMaleFlat[s];
                } else {//basketball female 2
                    selectedVideo = basketballFemaleFlat[s];
                }
            }
        }

        return selectedVideo;
    }


}
