using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    private float xstart;
    private float ystart;
    private float zstart;
    private float shake = 0f;
    private float shakeAmount = .2f;
    private float decreaseFactor = 1f;
    const float range = 2f;
    // Start is called before the first frame update
    private void Awake() {
        transform.position = new Vector3(0, 100, -80);
    }
    
    private void Start()
    {
        Vector3 pos = transform.position;
        xstart = pos.x;
        ystart = pos.y;
        zstart = pos.z;
    }

    public void Shake(float amount) {
        try {
            shake = amount;
        }
        catch {
            shake = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(shake > 0f) {
            float randx = Random.Range(-shakeAmount, shakeAmount);
            float randy = Random.Range(-shakeAmount, shakeAmount);
            transform.position = new Vector3(transform.position.x+randx, transform.position.y+randy, transform.position.z);
            shake -= Time.deltaTime * decreaseFactor;
        } else {
            shake = 0f;
            Vector3 startPos = new Vector3(xstart, ystart, zstart);
            transform.position = Vector3.Lerp(transform.position, startPos, .05f);
        }


    }
}
