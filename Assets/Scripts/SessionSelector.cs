using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionSelector : MonoBehaviour {

    public Dropdown branch;
    public Dropdown gender;
    public Dropdown session;

    void Start() {
		VideoManager.instance.b = 0;
		VideoManager.instance.g = 0;
		VideoManager.instance.s = 0;

        branch.value = 0;
        gender.value = 0;
        session.value = 0;
    }

    void OnEnable() {
        VideoManager.instance.b = 0;
        VideoManager.instance.g = 0;
        VideoManager.instance.s = 0;

        branch.value = 0;
        gender.value = 0;
        session.value = 0;
    }

    public void SetBranch(Dropdown dropdown) {
        VideoManager.instance.b = dropdown.value;
    }
    public void SetGender(Dropdown dropdown) {
        VideoManager.instance.g = dropdown.value;
    }
    public void SetSession(Dropdown dropdown) {
        VideoManager.instance.s = dropdown.value;
    }
}
