using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void onCollisionEnter(Collider other) {
        GameObject.FindWithTag("Player").GetComponent<Movement>().Death(false);
    }
}
