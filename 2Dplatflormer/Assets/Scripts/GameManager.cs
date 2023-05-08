using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static Vector2 lastCheckpoint;
    public static int mapCount;
    public static int secretCount;


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
            lastCheckpoint = new Vector2(0, 0) ;
        }

    }


    public static int GetMapIndex()
    {
        Debug.Log($"GetMapIndex :{mapCount}");
        return mapCount;
    }


    public static void SetMapIndex(int count)
    {
        mapCount=count;
        PlayerPrefs.SetInt("MapCount", count);
        PlayerPrefs.Save();
    }


    public static void SetStartMap()
    {
        if (PlayerPrefs.HasKey("MapCount"))
        {
            int startMapCount = PlayerPrefs.GetInt("MapCount");
            mapCount = startMapCount;
        }
        else
        {
            mapCount = 0;
        }
    }

     public static void AddSecretItem(int count)
    {
        secretCount = count;
        PlayerPrefs.SetInt("SecretCount", secretCount);
        PlayerPrefs.Save();
        Debug.Log($"Secret item count = {secretCount}");
    }

    public static int ReturnNum()
    {
        int coin = PlayerPrefs.GetInt("SecretCount");
        return coin;
    }
}
