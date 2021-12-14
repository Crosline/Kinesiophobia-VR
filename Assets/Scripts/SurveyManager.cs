using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurveyManager : MonoBehaviour
{
    public List<int> surveyAnswers = new List<int>();
    public List<string> surveyQuestions;
    public List<Text> questionTexts;

    int count = 0;
    // Start is called before the first frame update
    public void Hello() {
        Debug.Log("Hiiiiii");
    }
    
    public void NumberTapped(int a) {
        if(count > questionTexts.Count) {
            
        } else {
            questionTexts[count].gameObject.SetActive(false);
            surveyAnswers.Add(a);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
