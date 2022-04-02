using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurveyManager : MonoBehaviour
{
    public List<string> surveyAnswers = new List<string>();
    public List<string> surveyQuestions;
    public List<Text> questionTexts;
    public SendToGoogle stg;

    // Start is called before the first frame update
    public void Hello() {
        Debug.Log("Hiiiiii");
    }
    
    public void NumberTapped(int a) {
            surveyAnswers.Add(a.ToString());
            // questionTexts[0].gameObject.SetActive(false);
            if (stg == null) {
                stg = GetComponent<SendToGoogle>();
            }
            stg.soru1 = surveyAnswers[0];
            stg.Send();
        
    }

    void Start() {
        for(int i = 0; i < questionTexts.Count; i++) {
            questionTexts[i].text = surveyQuestions[i];
            if(i != 0) {
                questionTexts[i].gameObject.SetActive(false);
            }
        }
    }

}
