using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    private Animator anim;
    private AudioSource gunSound;
    private float shootTimer = 0;
    public GameObject cam;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        ps = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        cam = GameObject.Find("Main Camera");
        gunSound = GetComponent<AudioSource>();
    }

    void Shoot() {
        shootTimer = 15;

        anim.ResetTrigger("Spin");
        anim.SetTrigger("Shoot");

        gunSound.PlayOneShot(gunSound.clip, Random.Range(0.7f, 1f));

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1000)) {
            GameObject hitObject = hit.transform.gameObject;
            Debug.Log(hitObject);
            if(hitObject.tag == "Enemy") {
                hitObject.GetComponent<enemyScript>().takeDamage();
                cam.GetComponent<screenShake>().Shake(1f);
            }
        }

        ps.Play();
    }

    public void Shake(float amount) {
        cam.GetComponent<screenShake>().Shake(amount);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && shootTimer == 0) {
            Shoot();
        }

        if(Input.GetMouseButtonDown(1)) {
            anim.ResetTrigger("Shoot");
            anim.SetTrigger("Spin");
        }

        if(shootTimer > 0) {
            shootTimer--;
        }

        Debug.DrawRay(transform.position-(Vector3.back*5f), transform.TransformDirection(Vector3.right)*100, Color.green);
    }
}
