using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            LevelManager lb = FindObjectOfType<LevelManager>();
            lb.OverwriteAndEnd();
        }
    }
}
