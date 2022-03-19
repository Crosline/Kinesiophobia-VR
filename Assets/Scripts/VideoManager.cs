using System;
using UnityEngine;

public class VideoManager : MonoBehaviour
{


    public static VideoManager instance;

    public String[] volleyballFemale = new String[6];   //0
    public String[] volleyballMale = new String[6];     //1

    public String[] basketballFemale = new String[6];   //2
    public String[] basketballMale = new String[6];     //3

    public String[] footballFemale = new String[6];     //4
    public String[] footballMale = new String[6];       //5
#if FLAT_VIDEO
    public String[] volleyballFemaleFlat = new String[6];   //0
    public String[] volleyballMaleFlat = new String[6];     //1

    public String[] basketballFemaleFlat = new String[6];   //2
    public String[] basketballMaleFlat = new String[6];     //3

    public String[] footballFemaleFlat = new String[6];     //4
    public String[] footballMaleFlat = new String[6];       //5
#endif
    private String selectedVideo;

    public int b = 0;
    public int g = 0;
    public int s = 0;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }
    private void GetAllVideos()
    {
        volleyballFemale = PlayerPrefsX.GetStringArray("VolleyballFemale", "", 10);
        volleyballMale = PlayerPrefsX.GetStringArray("VolleyballMale", "", 10);

        basketballFemale = PlayerPrefsX.GetStringArray("BasketballFemale", "", 10);
        basketballMale = PlayerPrefsX.GetStringArray("BasketballMale", "", 10);

        footballFemale = PlayerPrefsX.GetStringArray("FootballFemale", "", 10);
        footballMale = PlayerPrefsX.GetStringArray("FootballMale", "", 10);


        // Flat videos
#if FLAT_VIDEO
        volleyballFemaleFlat = PlayerPrefsX.GetStringArray("VolleyballFemaleFlat", "", 10);
        volleyballMaleFlat = PlayerPrefsX.GetStringArray("VolleyballMaleFlat", "", 10);
        
        basketballFemaleFlat = PlayerPrefsX.GetStringArray("BasketballFemaleFlat", "", 10);
        basketballMaleFlat = PlayerPrefsX.GetStringArray("BasketballMaleFlat", "", 10);
        
        footballFemaleFlat = PlayerPrefsX.GetStringArray("FootballFemaleFlat", "", 10);
        footballMaleFlat = PlayerPrefsX.GetStringArray("FootballMaleFlat", "", 10);
  #endif
    }
    public void UpdateVideos(int s, int i, String path, int videoType = 0)
    {

        GetAllVideos();
        if (s == 0)
        {
            if (videoType == 0)
            {
                PlayerPrefsX.SetStringArray("VolleyballFemale", volleyballFemale);
                volleyballFemale[i] = path;
            }
            else
            {
#if FLAT_VIDEO
                PlayerPrefsX.SetStringArray("VolleyballFemaleFlat", volleyballFemaleFlat);
                volleyballFemaleFlat[i] = path;
#endif
            }
        }
        else if (s == 1)
        {
            if (videoType == 0)
            {
                PlayerPrefsX.SetStringArray("VolleyballMale", volleyballMale);
                volleyballMale[i] = path;
            }
            else
            {
#if FLAT_VIDEO
                PlayerPrefsX.SetStringArray("VolleyballMaleFlat", volleyballMaleFlat);
                volleyballMaleFlat[i] = path;
#endif
            }

        }
        else if (s == 2)
        {
            if (videoType == 0)
            {
                PlayerPrefsX.SetStringArray("BasketballFemale", basketballFemale);
                basketballFemale[i] = path;
            }
            else
            {
#if FLAT_VIDEO
                PlayerPrefsX.SetStringArray("BasketballFemaleFlat", basketballFemaleFlat);
                basketballFemaleFlat[i] = path;
#endif
            }
        }
        else if (s == 3)
        {
            if (videoType == 0)
            {
                PlayerPrefsX.SetStringArray("BasketballMale", basketballMale);
                basketballMale[i] = path;
            }
            else
            {
#if FLAT_VIDEO
                PlayerPrefsX.SetStringArray("BasketballMaleFlat", basketballMaleFlat);
                basketballMaleFlat[i] = path;
#endif
            }

        }
        else if (s == 4)
        {
            if (videoType == 0)
            {
                PlayerPrefsX.SetStringArray("FootballFemale", footballFemale);
                footballFemale[i] = path;
            }
            else
            {
#if FLAT_VIDEO
                PlayerPrefsX.SetStringArray("FootballFemaleFlat", footballFemaleFlat);
                footballFemaleFlat[i] = path;
#endif
            }
        }
        else if (s == 5)
        {
            if (videoType == 0)
            {

                PlayerPrefsX.SetStringArray("FootballMale", footballMale);
                footballMale[i] = path;
            }
            else
            {
#if FLAT_VIDEO
                PlayerPrefsX.SetStringArray("FootballMaleFlat", footballMaleFlat);
                footballMaleFlat[i] = path;
#endif
            }
        }

    }

    public string GetSelectedVideo(int videoType = 0)
    {

        GetAllVideos();
        if (videoType == 0)
        {
            if (b == 0)
            {
                if (g == 0)
                { //football male 5
                    selectedVideo = footballMale[s];
                }
                else
                { //football female 4
                    selectedVideo = footballFemale[s];
                }
            }
            else if (b == 1)
            {
                if (g == 0)
                {//volleyball male 1
                    selectedVideo = volleyballMale[s];
                }
                else
                {//volleyball female 0
                    selectedVideo = volleyballFemale[s];
                }
            }
            else if (b == 2)
            {
                if (g == 0)
                {//basketball male 3
                    selectedVideo = basketballMale[s];
                }
                else
                {//basketball female 2
                    selectedVideo = basketballFemale[s];
                }
            }
        }
        else
        {
#if FLAT_VIDEO
            if (b == 0)
            {
                if (g == 0)
                { //football male 5
                    selectedVideo = footballMaleFlat[s];
                }
                else
                { //football female 4
                    selectedVideo = footballFemaleFlat[s];
                }
            }
            else if (b == 1)
            {
                if (g == 0)
                {//volleyball male 1
                    selectedVideo = volleyballMaleFlat[s];
                }
                else
                {//volleyball female 0
                    selectedVideo = volleyballFemaleFlat[s];
                }
            }
            else if (b == 2)
            {
                if (g == 0)
                {//basketball male 3
                    selectedVideo = basketballMaleFlat[s];
                }
                else
                {//basketball female 2
                    selectedVideo = basketballFemaleFlat[s];
                }
            }
#endif
        }

        return selectedVideo;
    }


}
