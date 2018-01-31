using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance { get; private set; }
    public string ambientSound;
    public string respawnSound;
    public bool playerHasWonGame = false;
    public Transform respawnTransform;
    public GameObject playerObject;
    public PlayerHealthManager playerHealthManager;
    private bool _sceneLoaded = false;
    public bool SceneLoaded { get; private set; }
    private string _sceneBeingLoaded;

    public void GetPlayer() {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            playerHealthManager = playerObject.GetComponent<PlayerHealthManager>();
    }

    public void GetRespawn() {
        GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
        if (respawn != null) {
            respawnTransform = respawn.transform;
        }
    }

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

    public void LoadScene (string gameLevel){
        SceneManager.LoadScene(gameLevel);
        _sceneLoaded = true;
        _sceneBeingLoaded = gameLevel;
        GetPlayer();
        GetRespawn();
    }

    public void LoadScene (int gameLevel){
        SceneManager.LoadScene(gameLevel);
        _sceneLoaded = true;
        _sceneBeingLoaded = SceneManager.GetSceneByBuildIndex(gameLevel).name;
        GetPlayer();
        GetRespawn();
    }

    public void ReloadScene () {
        LoadScene(GetCurrentLevel());
    }

    public void RespawnPlayer() {
        playerObject.transform.position = respawnTransform.position;
        playerHealthManager.hp = 100;
        playerHealthManager.alive = true;
    }

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        GetPlayer();
        GetRespawn();
    }

    void Update() {
        if (playerObject == null) {
            GetPlayer();
        }
        if (respawnTransform == null) {
            GetRespawn();
        }

        if (GetCurrentLevel() == "Menu") {
            if (Input.GetButtonDown("Submit")) {
                LoadScene("MapWorld");
                AudioManager.instance.Play(ambientSound);
            }
        } else {
            if (Input.GetButtonDown("Cancel")) {
                LoadScene("Menu");
            }
            if (!AudioManager.instance.IsPlaying(ambientSound)) {
                AudioManager.instance.Play(ambientSound);
            }
        }

        if (playerHasWonGame) {
            playerHasWonGame = false;
            LoadScene("Win");
        }

        if (playerHealthManager != null && !playerHealthManager.alive) {
            RespawnPlayer();
            AudioManager.instance.Play(respawnSound);
        }
    }
}
