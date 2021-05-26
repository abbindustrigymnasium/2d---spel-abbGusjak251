using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawnPrefab;
    public GameObject playground;
    public GameObject UI;
    private GameObject audioSlider, controlsDisplay;
    public bool Game;
    public string currentScene;
    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        // Init Scene
        currentScene = SceneManager.GetActiveScene().name;
        Physics.gravity = Vector3.down * 40f;

        // Find Audio Slider and controls display
        audioSlider = GameObject.FindWithTag("AudioSlider");
        controlsDisplay = GameObject.Find("Controls");
        
    }

    private void StartGame() {
        float playgroundWidth = playground.GetComponent<Collider>().bounds.size.x;
        float playgroundHeight= playground.GetComponent<Collider>().bounds.size.z;
        
        GameObject player = Instantiate(playerPrefab);
        GameObject spawner = Instantiate(spawnPrefab);

        player.transform.position = new Vector3(0-(playgroundWidth*0.4f), 20, 0);
        spawner.transform.position = new Vector3(0+(playgroundWidth*0.4f), 20, 0);

        hideSettings();
    }
    
    public float playgroundWidth() {
        return (float)playground.GetComponent<Collider>().bounds.size.z;
    }

    private void hideSettings() {
        audioSlider.SetActive(false);
        controlsDisplay.SetActive(false);
        Cursor.visible = false;
    }

    private void showSettings() {
        audioSlider.SetActive(true);
        controlsDisplay.SetActive(true);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Game)  {
            Cursor.visible = true;
            UI.GetComponent<UIScript>().showMenu();
            audioSlider.SetActive(true);
            controlsDisplay.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Return)) {
                Game = true;
                StartGame();
                UI.GetComponent<UIScript>().clearText();
            }
            return;
        }
        
        // Restart Scene and quit game
        if(Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(currentScene);
        }
        if(Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            if(audioSlider.activeSelf) {
                hideSettings();
            } else {
                showSettings();
            }
        }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        //Debug.Log(fps);


        // Change audio level based on player input (slider)
        AudioListener.volume = audioSlider.GetComponent<Slider>().value;
    }
}
