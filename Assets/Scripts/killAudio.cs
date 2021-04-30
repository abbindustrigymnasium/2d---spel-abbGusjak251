using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killAudio : MonoBehaviour
{
    private AudioSource audio_;

    void Start()
    {
        audio_ = GetComponent<AudioSource>();
    }

    private IEnumerator fuck() {
        yield return new WaitForSeconds(audio_.clip.length-0.1f);
        Destroy(gameObject);
    }

    private void RandomizePitch() {
        audio_.pitch = Random.Range(0.8f, 1.2f);
    }
    void Update()
    {
        if(!audio_.isPlaying) {
            RandomizePitch();
            audio_.Play();
            StartCoroutine("fuck");
        }
    }
}
