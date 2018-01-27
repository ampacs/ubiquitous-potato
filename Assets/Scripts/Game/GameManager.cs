using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }
    public GameObject playerObject;
    private bool _sceneLoaded = false;
    public bool SceneLoaded { get; private set; }
    private string _sceneBeingLoaded;

    public bool HasSceneLoaded () {
        return _sceneLoaded;
    }

    public string SceneBeingLoaded () {
        return _sceneBeingLoaded;
    }

    public bool IsPlayerInScene () {
        return playerObject != null;
    }

    public string GetCurrentLevel () {
        return SceneManager.GetActiveScene().name;
    }

    public int GetCurrentLevelIndex () {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public float levelTimer;

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void LoadScene (string gameLevel){
        SceneManager.LoadScene(gameLevel);
        _sceneLoaded = true;
        _sceneBeingLoaded = gameLevel;
        levelTimer = 0;
        Time.timeScale = 1;
    }

    public void LoadScene (int gameLevel){
        SceneManager.LoadScene(gameLevel);
        _sceneLoaded = true;
        _sceneBeingLoaded = SceneManager.GetSceneByBuildIndex(gameLevel).name;
        levelTimer = 0;
        Time.timeScale = 1;
    }

    public void ReloadScene () {
        LoadScene(GetCurrentLevel());
    }

    public void TogglePause () {
        if (Time.timeScale != 0) {
            Time.timeScale = 0;
        } else if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
    }

    void Update () {
        if (playerObject != null) {

        }
    }

    void LateUpdate() {
        if (playerObject == null) {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null) {
                
            }
        }
        _sceneLoaded = false;
    }
}
