using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;

    [SerializeField] GameObject innerTube;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeOut;


    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd(){
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        innerTube.GetComponent<Rigidbody>().isKinematic = true;

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // Stop the music
        }
        collisionFX.Play();

        mainCam.GetComponent<Animator>().Play("CollisionCam");

        yield return new WaitForSeconds(2);

        fadeOut.SetActive(true);

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);

    }
}
