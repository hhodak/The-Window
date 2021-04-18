using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject camera;
    float cameraSpeed = 0.1f;
    float mouseSpeed = 5f;
    string filePath;

    private void Awake()
    {
        filePath = Application.dataPath + "/TextFiles/gameData.txt";
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        camera.transform.Translate(input * cameraSpeed);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            camera.transform.Rotate(mouseSpeed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            camera.transform.Rotate(-mouseSpeed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            camera.transform.Rotate(0, mouseSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            camera.transform.Rotate(mouseSpeed, -mouseSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToTheWindow();
        }
    }

    #region Rotation

    public void FlipLeft()
    {
        puzzle.transform.Rotate(new Vector3(0, 0, -0.5f));
    }

    public void FlipRight()
    {
        puzzle.transform.Rotate(new Vector3(0, 0, 0.5f));
    }

    public void RotateForward()
    {
        puzzle.transform.Rotate(new Vector3(0.5f, 0, 0));
    }

    public void RotateBackward()
    {
        puzzle.transform.Rotate(new Vector3(-0.5f, 0, 0));
    }

    public void SpinLeft()
    {
        puzzle.transform.Rotate(new Vector3(0, -0.5f, 0));
    }

    public void SpinRight()
    {
        puzzle.transform.Rotate(new Vector3(0, 0.5f, 0));
    }
    #endregion

    public void OverwriteAndEnd()
    {
        GameData gd = new GameData();
        string[] data = File.ReadAllLines(filePath);
        data[2] = "true";
        gd.windowText = data[0];
        gd.puzzle1 = bool.Parse(data[1]);
        gd.puzzle2 = bool.Parse(data[2]);
        gd.puzzle3 = bool.Parse(data[3]);
        gd.puzzle4 = bool.Parse(data[4]);
        ReturnToTheWindow();
    }

    void ReturnToTheWindow()
    {
        SceneManager.LoadScene(0);
    }
}
