using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text questionText;

    private void Start()
    {
        GenerateQuestion();
    }

    public void Correct()
    {
        ScoreManager.instance.score += 500;
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshPro>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        questionText.text = QnA[currentQuestion].Question;

        SetAnswers();

        QnA.RemoveAt(currentQuestion);
    }
}
