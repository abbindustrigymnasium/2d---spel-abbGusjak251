using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private GameObject UIManager;
    private GameObject GameManager;
    private float halfPlaygroundWidth;
    
    public GameObject deathAudio;
    private Rigidbody rb;
    private ParticleSystem ps;
    private AudioSource hitAudio;
    private const int maxHealth = 10;
    private const float speed = 7;
    private float deltaTime;
    private Color originalColor;
    private bool chase = false;
    int health;
    
    void Start() {
        health = maxHealth;
        rb = GetComponent<Rigidbody>();
        ps = GetComponentInChildren<ParticleSystem>();
        originalColor = GetComponent<Renderer>().material.color;
        UIManager = GameObject.Find("Canvas");
        GameManager = GameObject.Find("GameManager");
        halfPlaygroundWidth = GameManager.GetComponent<GameManagerScript>().playgroundWidth();

        // Audio
        hitAudio = GetComponent<AudioSource>();

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

    void FixedUpdate() {
        // Check if player is in radius and if so then chase
        chase = playerInRadius();
        if(chase) {
            GameObject target = GameObject.FindWithTag("Player");
            Vector3 vec = (transform.position-target.transform.position)/(-speed);
            rb.velocity = new Vector3(vec.x, rb.velocity.y, vec.z);
        } else {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }

        // Prevent bad stuff from happening
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -(halfPlaygroundWidth-10f), halfPlaygroundWidth-10f));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left)*50, Color.red);
    }

    public void takeDamage() {
        // Spawn particles and play "damage audio"
        ps.Play();
        hitAudio.Play();

        // Decrease health and flash in red
        if(health > 0) {
            health--;
            StartCoroutine("Blink");
        } else {
            // Create audio source
            GameObject audioInstance = Instantiate(deathAudio);
            audioInstance.transform.position = transform.position;

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
            
            // Increase number of kills by player
            UIManager.GetComponent<UIScript>().kills++;

            // Destroy Self
            Destroy(gameObject);
        }
    }
    private bool playerInRadius() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 50f);
        foreach(var hitCollider in hitColliders) {
            if(hitCollider.gameObject.tag == "Player") {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy") {
            float push = Random.Range(-2, 2);
            rb.AddForce(Vector3.back*push, ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back*(-push), ForceMode.Impulse);
        }
    }
}
