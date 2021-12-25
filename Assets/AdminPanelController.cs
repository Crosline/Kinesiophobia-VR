using UnityEngine;
using UnityEngine.UI;

public class AdminPanelController : MonoBehaviour {

	public Dropdown branch;
	public Dropdown gender;
	public Dropdown session;

	void Awake() {

		PlayerPrefs.SetInt("Branch", 0);
		PlayerPrefs.SetInt("Gender", 0);
		PlayerPrefs.SetInt("Session", 0);

		UpdateSelection();
	}

	public void UpdateSelection() {
		int b, g, s;
		b = PlayerPrefs.GetInt("Branch", 0);
		g = PlayerPrefs.GetInt("Gender", 0);
		s = PlayerPrefs.GetInt("Session", 0);
		branch.value = b;
		gender.value = g;
		session.value = s;

	}

	public void SelectBranch() {
		PlayerPrefs.SetInt("Branch", branch.value);
		UpdateSelection();
	}

	public void SelectGender() {
		PlayerPrefs.SetInt("Gender", gender.value);
		UpdateSelection();
	}

	public void SelectSession() {
		PlayerPrefs.SetInt("Session", session.value);
		UpdateSelection();
	}

	public void SelectVideo() {
		NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) => {
			if (path != null) {
				int b, g, s;
				b = PlayerPrefs.GetInt("Branch", 0); //0: football, 1: volleyball, 2:basketball
				g = PlayerPrefs.GetInt("Gender", 0); //0:male, 1:female
				/*
				volleyball
					f: 0
					m: 1
				basketball
					f: 2
					m: 3
				football
					f: 4
					m: 5
				 */
				s = PlayerPrefs.GetInt("Session", 0);
				if (b == 0) {
					if (g == 0) { //football male 5
						VideoManager.instance.UpdateVideos(5, s, path);
					} else { //football female 4
						VideoManager.instance.UpdateVideos(4, s, path);
					}
				} else if (b == 1) {
					if (g == 0) {//volleyball male 1
						VideoManager.instance.UpdateVideos(1, s, path);
					} else {//volleyball female 0
						VideoManager.instance.UpdateVideos(0, s, path);
					}
				} else if (b == 2) {
					if (g == 0) {//basketball male 3
						VideoManager.instance.UpdateVideos(3, s, path);
					} else {//basketball female 2
						VideoManager.instance.UpdateVideos(2, s, path);
					}
				}
			}
		}, "Seans videosu seçin", "video/mp4");

	}

}