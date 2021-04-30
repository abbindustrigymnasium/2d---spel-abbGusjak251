using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawnPrefab;
    public GameObject playground;
    public GameObject UI;
    public bool Game;
    public string currentScene;
    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Physics.gravity = Vector3.down * 40f;
        
    }

    private void StartGame() {
        float playgroundWidth = playground.GetComponent<Collider>().bounds.size.x;
        float playgroundHeight= playground.GetComponent<Collider>().bounds.size.z;
        
        GameObject player = Instantiate(playerPrefab);
        GameObject spawner = Instantiate(spawnPrefab);

        player.transform.position = new Vector3(0-(playgroundWidth*0.4f), 20, 0);
        spawner.transform.position = new Vector3(0+(playgroundWidth*0.4f), 20, 0);
    }
    
    public float playgroundWidth() {
        return (float)playground.GetComponent<Collider>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Game)  {
            UI.GetComponent<UIScript>().showMenu();
            if(Input.GetKeyDown(KeyCode.Return)) {
                Game = true;
                StartGame();
                UI.GetComponent<UIScript>().clearText();
            }
            return;
        }
        
        if(Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(currentScene);
        }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        Debug.Log(fps);
    }
}
