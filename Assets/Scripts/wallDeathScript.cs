using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDeathScript : MonoBehaviour
{
    private void onCollisionEnter(Collider other) {
        GameObject.FindWithTag("Player").GetComponent<Movement>().Death(false);
    }
}
