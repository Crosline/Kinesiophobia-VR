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

    int count = 0;
    // Start is called before the first frame update
    public void Hello() {
        Debug.Log("Hiiiiii");
    }
    
    public void NumberTapped(int a) {
        if(count > questionTexts.Count) {
            questionTexts[count].gameObject.SetActive(false);
            if (stg == null) {
                stg = GetComponent<SendToGoogle>();
            }
            stg.soru1 = surveyAnswers[0];
            stg.soru2 = surveyAnswers[1];
            stg.Send();
        } else {
            questionTexts[count].gameObject.SetActive(false);
            surveyAnswers.Add(a.ToString());
            Debug.Log("Question #" + count + " : " + surveyAnswers[count]);
            count++;
            questionTexts[count].gameObject.SetActive(true);
        }
        
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
