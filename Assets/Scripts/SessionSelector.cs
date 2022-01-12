using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionSelector : MonoBehaviour
{
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
