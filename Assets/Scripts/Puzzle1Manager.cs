using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1Manager : MonoBehaviour
{
    GameManager gm;
    string windowText = "";
    public GameObject puzzle1panel;
    public InputField num1;
    public InputField num2;
    public InputField num3;
    public InputField num4;
    public Button box1;
    public string code = "";

    private void Update()
    {
        if (windowText == "")
        {
            gm = FindObjectOfType<GameManager>();
            windowText = gm.windowText.text;
            SetCode();
        }
    }

    void SetCode()
    {
        string sample = "wxyz";
        for (int i = 0; i < windowText.Length; i++)
        {
            char sign = windowText[i];
            if (sample.Contains(sign.ToString()))
            {
                CountOccurrence(sign.ToString());
                sample = sample.Remove(sample.IndexOf(sign), 1);
            }
        }
    }

    void CountOccurrence(string elem)
    {
        int ocr = 0;
        for (int i = 0; i < windowText.Length; i++)
        {
            if (windowText[i].ToString() == elem)
            {
                ocr++;
            }
        }
        code += ocr.ToString();
    }

    public void EnablePanel()
    {
        puzzle1panel.SetActive(true);
    }

    public void DisablePanel()
    {
        puzzle1panel.SetActive(false);
    }

    public void CheckResult()
    {
        string enteredValue = num1.text + num2.text + num3.text + num4.text;
        if (enteredValue == code)
        {
            box1.enabled = false;
            gm.Puzzle1Solved();
        }
        else
        {
            num1.text = "";
            num2.text = "";
            num3.text = "";
            num4.text = "";
        }
        DisablePanel();
    }
}
