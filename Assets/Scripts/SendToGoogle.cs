using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour {

    private String tarih;
    private String cinsiyet;
    private String branch;
    private String seans;

    public String soru1 = "s1";

    public GameObject NoInternetCanvas;

    [SerializeField]
    private String BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf9P2Xxr9kjWU9LJgpmiMUIQHBDHUA2N1XD4RJwsuJ8UsUbkQ/formResponse";

    private void Awake()
    {
        BASE_URL = PlayerPrefs.GetString("FormLink", "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf9P2Xxr9kjWU9LJgpmiMUIQHBDHUA2N1XD4RJwsuJ8UsUbkQ/formResponse");
    }
	
	IEnumerator Start(){
		yield return new WaitUntil(() => OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.B));
		
		if (VideoManager.instance.isFlat)
			SceneManager.LoadScene("FlatVideo");
		else
			SceneManager.LoadScene("360Video");
	}
	
    IEnumerator PostGoogle() {
        WWWForm form = new WWWForm();
        form.AddField("entry.2100849996", cinsiyet);
        form.AddField("entry.336840604", branch);
        form.AddField("entry.1595864976", seans);
        form.AddField("entry.352541524", soru1);
        /*
        ** Outdated
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
        */
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(www.error);
            NoInternetCanvas.SetActive(true);
        } else {
            Debug.Log("Form upload complete!");
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Send() {
		return;
        tarih = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        if (VideoManager.instance.g == 0) {
             cinsiyet = "Erkek";
         } else {
             cinsiyet = "Kadin";
         }

         if (VideoManager.instance.b == 0) {
             branch = "Futbol";
         } else if (VideoManager.instance.b == 1) {
             branch = "Voleybol";
         } else {
             branch = "Basketbol";
         }

         seans = (VideoManager.instance.s + 1).ToString();

       /* cinsiyet = "c";
        branch = "b";
        seans = "s";*/



        StartCoroutine(PostGoogle());

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
