using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public int kills = 0;
    public int wave = 0;
    private Text[] texts = new Text[2];
    private GameObject player;
    Text killDisplay, waveDisplay, gameOverDisplay;
    private void Awake()
    {
        killDisplay = GameObject.Find("KillDisplay").GetComponent<Text>();
        waveDisplay = GameObject.Find("WaveDisplay").GetComponent<Text>();
        gameOverDisplay = GameObject.Find("GameOverDisplay").GetComponent<Text>();

        texts[0] = killDisplay;
        texts[1] = waveDisplay;

        int margin = 200;
        killDisplay.transform.position = new Vector2(margin, Screen.height*0.95f);
        waveDisplay.transform.position = new Vector2(Screen.width-margin, Screen.height*0.95f);
        gameOverDisplay.transform.position = new Vector2(Screen.width/2, Screen.height*0.8f);
    }

    public void showGameOver() {
        gameOverDisplay.text = "Game Over Press R to Restart";
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        /*foreach(Text text in texts) {
        }
        */

        killDisplay.text = "Kills: " + kills;
        waveDisplay.text = "Wave: " + wave;
    }
}
