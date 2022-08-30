using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public GroundPieceController[] allGroundPieces;

    void Start()
    {
        SetUpNewLevel();
    }

    private void SetUpNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPieceController>();
    }

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        else if(gameManager !=null)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetUpNewLevel();
    }
    public void CheckComplete()
    {
        bool isFinished = true;
        for(int i = 0; i < allGroundPieces.Length; i++)
        {
            if(allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if(isFinished)
            NextLevel();
    }

    private void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
