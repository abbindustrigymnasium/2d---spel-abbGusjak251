using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    private float xstart;
    private float ystart;
    private float zstart;
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

    public void Shake() {
        float newx = xstart + Random.Range(-range, range);
        float newy = ystart + Random.Range(-range, range);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(newx, newy, transform.position.z), 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0)) {
            Shake();
        }
        */

        Vector3 startPos = new Vector3(xstart, ystart, zstart);
        transform.position = Vector3.MoveTowards(transform.position, startPos, 1);
    }
}
