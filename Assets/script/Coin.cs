using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f); // bisa diganti sesuai arah putaran

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {

    //        Debug.Log("a");
    //        Destroy(gameObject);
    //    }
    //}
    public AudioSource audioSource;  // Tarik AudioSource dari Inspector
    public AudioClip clipToPlay;     // Drag audio clip di Inspector (opsional)

    // Fungsi untuk memutar suara
    public void PlaySound()
    {
        if (audioSource != null && clipToPlay != null)
        {
            audioSource.PlayOneShot(clipToPlay); // Mainkan satu kali
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound();
            FindObjectOfType<ScoreManager>().AddScore(10);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(death());
            // Hancurkan objek ini
        }
    }
    private IEnumerator death()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}