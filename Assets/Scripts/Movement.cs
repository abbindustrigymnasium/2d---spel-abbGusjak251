using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public bool dead;
    public float speed = 30f;
    private Transform ground;
    private float hmove;
    private float vmove;
    // Start is called before the first frame update
    private void Start()
    {
        ground = GameObject.Find("playground").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if(dead) return;
        hmove = Input.GetAxisRaw("Horizontal");
        vmove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(hmove*speed, rb.velocity.y, vmove*speed);
    }

    public void Death() {
            // Destroy spawner
            Destroy(GameObject.Find("SpawnManager"));

            // Destroy all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies) {
                Destroy(enemy);
            }

            // Make player shoot away on death
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * 20f + Vector3.forward * 20f, ForceMode.Impulse);

            // Release Gun
            GameObject gun = GameObject.Find("glock19");
            gun.transform.SetParent(null);
            gun.AddComponent<Rigidbody>();
            Destroy(gun.GetComponent<gunScript>());

            GameObject.Find("Canvas").GetComponent<UIScript>().showGameOver();

            // Set boolean dead to true
            dead = true;
    }

    private void FixedUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -100, ground.position.x/2), transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision other) {
        if(dead) return;
        if(other.gameObject.tag == "Enemy") {
            Death();
        }
    }
}
