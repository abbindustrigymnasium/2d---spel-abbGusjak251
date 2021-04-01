using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private GameObject UIManager;
    private Rigidbody rb;
    private ParticleSystem ps;
    private const int maxHealth = 10;
    private const float speed = 7;
    private float deltaTime;
    private Color originalColor;
    int health;
    
    void Start() {
        health = maxHealth;
        rb = GetComponent<Rigidbody>();
        ps = GetComponentInChildren<ParticleSystem>();
        originalColor = GetComponent<Renderer>().material.color;
        UIManager = GameObject.Find("Canvas");

        // Set Alpha of Blood splat
        Transform bloodSprite = gameObject.transform.Find("BloodSplat");
        bloodSprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .2f);
    }

    public IEnumerator Blink() {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        GetComponent<Renderer>().material.color = originalColor;
        StopCoroutine("Blink");
    }

    void Update() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 50)) {
            GameObject target = hit.transform.gameObject;
            if(target.tag == "Player") {
                rb.velocity = (transform.position-target.transform.position)/(-speed);
            } else {
                rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            }
        } else {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left)*50, Color.red);
    }

    public void takeDamage() {
        ps.Play();
        if(health > 0) {
            health--;
            StartCoroutine("Blink");
        } else {
            Transform bloodSprite = gameObject.transform.Find("BloodSplat");
            bloodSprite.gameObject.SetActive(true);
            bloodSprite.SetParent(null);

            // Clean up some blood if there's too much on the ground
            GameObject[] bloodSplats = GameObject.FindGameObjectsWithTag("Blood");
            if(bloodSplats.Length >= 15) {
                for(int i=0; i<bloodSplats.Length; i++) {
                    if(i<2) {
                        Destroy(bloodSplats[i]);
                    }
                }
            }
            
            UIManager.GetComponent<UIScript>().kills++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy") {
            float push = Random.Range(-2, 2);
            rb.AddForce(Vector3.back*push, ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back*(-push), ForceMode.Impulse);
        }
    }
}
