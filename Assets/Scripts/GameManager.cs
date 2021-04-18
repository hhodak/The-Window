using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public RawImage background;
    public Text windowText;
    public Image puzzle1statusBox;
    public Image puzzle2statusBox;
    public Image puzzle3statusBox;
    public Image puzzle4statusBox;
    string filePath;
    public GameData gameData;

    private void Awake()
    {
        filePath = Application.dataPath + "/TextFiles/gameData.txt";
        gameData = new GameData();
    }

    private void Start()
    {
        if (CheckFile())
            ReadGameData();
        else
            CreateGameData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            File.Delete(filePath);
            Application.Quit();
        }
    }

    string GenerateText()
    {
        string strSample = "xywz";
        string winText = "";
        //int numOfChars = Random.Range(11, 15);
        int numOfChars = 12;
        do
        {
            winText = "";
            for (int i = 0; i < numOfChars; i++)
            {
                winText += strSample[Random.Range(0, 4)];
            }
        } while (!(winText.Contains("w") && winText.Contains("x") && winText.Contains("y") && winText.Contains("z")));
        windowText.text = winText;
        return winText;
    }

    bool CheckFile()
    {
        if (File.Exists(filePath))
            return true;
        else
            return false;
    }

    void ReadGameData()
    {
        string[] data = File.ReadAllText(filePath).Split(' ');
        gameData.windowText = data[0];
        gameData.puzzle1 = bool.Parse(data[1]);
        gameData.puzzle2 = bool.Parse(data[2]);
        gameData.puzzle3 = bool.Parse(data[3]);
        gameData.puzzle4 = bool.Parse(data[4]);
        SetUpParameters();
    }

    void CreateGameData()
    {
        GenerateText();
        gameData.windowText = GenerateText();
        gameData.puzzle1 = false;
        gameData.puzzle2 = false;
        gameData.puzzle3 = false;
        gameData.puzzle4 = false;
        WriteGameData();
        SetUpParameters();
    }

    void WriteGameData()
    {
        StreamWriter writer = new StreamWriter(filePath, false);
        writer.WriteLine(gameData.ToString());
        writer.Close();
    }

    void SetUpParameters()
    {
        windowText.text = gameData.windowText;
        SetColoredStatus(gameData.puzzle1, puzzle1statusBox);
        SetColoredStatus(gameData.puzzle2, puzzle2statusBox);
        SetColoredStatus(gameData.puzzle3, puzzle3statusBox);
        SetColoredStatus(gameData.puzzle4, puzzle4statusBox);
    }

    void SetColoredStatus(bool status, Image image)
    {
        if (status)
            image.color = Color.green;
        else
            image.color = Color.red;
    }

    public void Puzzle1Solved()
    {
        SetColoredStatus(true, puzzle1statusBox);
        gameData.puzzle1 = true;
        WriteGameData();
    }

    public void StartPuzzle2()
    {
        SceneManager.LoadScene(1);
    }
}
