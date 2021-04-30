using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public int kills = 0;
    public float screenW, screenH;
    public int wave = 0;
    public int b = 0;
    private Text[] texts = new Text[2];
    private GameObject player;
    Text killDisplay, waveDisplay, gameOverDisplay;
    private void Awake()
    {
        // Find UI elements
        killDisplay = GameObject.Find("KillDisplay").GetComponent<Text>();
        waveDisplay = GameObject.Find("WaveDisplay").GetComponent<Text>();
        gameOverDisplay = GameObject.Find("GameOverDisplay").GetComponent<Text>();

        // Get screen width + height
        screenW = Screen.width;
        screenH = Screen.height;

        texts[0] = killDisplay;
        texts[1] = waveDisplay;

        // Margin to sides
        float margin = (int)Mathf.Round(screenW/10);
        Debug.Log(margin);

        // Set position of UI elements
        killDisplay.transform.position = new Vector2(margin, screenH*0.95f);
        waveDisplay.transform.position = new Vector2(screenW-margin, screenH*0.95f);
        gameOverDisplay.transform.position = new Vector2(screenW/2, screenH*0.95f);

        // Set font sizes
        foreach(Text t in texts) {
            t.fontSize = (int)Mathf.Round(screenW/80);
        }
        gameOverDisplay.fontSize = (int)Mathf.Round(screenW/40);
    }

    public void showGameOver() {
        gameOverDisplay.text = "Game Over [Press R to Restart]";
    }
    public void showMenu() {
        gameOverDisplay.text = "Press [Enter] to Start";
    }

    public void clearText() {
        gameOverDisplay.text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        /*foreach(Text text in texts) {
        }
        */

        killDisplay.text = "Kills: " + kills;
        waveDisplay.text = "Wave: " + wave;
    }
}
