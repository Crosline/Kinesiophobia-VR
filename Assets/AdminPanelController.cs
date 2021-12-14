using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPanelController : MonoBehaviour {
	
	public Dropdown branch;
	public Dropdown gender;
	public Dropdown session;
	
	public void UpdateSelection() {
		int b, g, s;
		b = PlayerPrefs.GetInt("Branch", 0);
		g = PlayerPrefs.GetInt("Gender", 0);
		s = PlayerPrefs.GetInt("Session", 0);
		branch.value = b;
		gender.value = g;
		session.value = s;
		
	}
	
	public void SelectBranch(int b) {
		PlayerPrefs.SetInt("Branch", b);
		UpdateSelection();
	}
	
	public void SelectGender(int g) {
		PlayerPrefs.SetInt("Gender", g);
		UpdateSelection();
	}
	
	public void SelectSession(int s) {
		PlayerPrefs.SetInt("Session", s);
		UpdateSelection();
	}
	
	public void SelectVideo() {
		
	}
	
}