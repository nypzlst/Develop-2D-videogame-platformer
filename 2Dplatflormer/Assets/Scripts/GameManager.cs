using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static Vector2 lastCheckpoint;

    public static void SetLastCheckpoint(Vector2 checkpointPosition)
    {
        lastCheckpoint= checkpointPosition;
        PlayerPrefs.SetFloat("CheckpointX",checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        PlayerPrefs.Save();
        Debug.Log($"Set last checkpoint :{lastCheckpoint}");
    }

    public static Vector2 GetLaskCheckpoint()
    {
        Debug.Log($"Get last checkpoint :{lastCheckpoint}");
        return lastCheckpoint;
    }

    public static void SetStartPosition()
    {
       
        if (PlayerPrefs.HasKey("CheckpointX") && PlayerPrefs.HasKey("CheckpointY"))
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            lastCheckpoint = new Vector2(x,y);
        }
        else
        {
            lastCheckpoint = new Vector2(87, 5);
        }

    }
}
