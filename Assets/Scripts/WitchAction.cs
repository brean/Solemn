using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// the user encountered the Witch! Time to Battle!
public class WitchAction : MonoBehaviour {
    private bool stopWorld = false;
    private GameObject cam;

    void OnTriggerEnter2D(Collider2D col)
    {
        // GroundCheck is part of the Player
        if (col.gameObject.name == "GroundCheck")
        {
            StopActions();
        }
    }

    IEnumerator NextLevel(float fadeTime)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(2);
    }

    void Update()
    {
        if (stopWorld)
        {
            if (this.transform.position.x < cam.transform.position.x )
            {
                MoveCamera move = cam.GetComponent<MoveCamera>();
                move.StopMove();

                Animator ani = GameObject.Find("witch").GetComponent<Animator>();
                ani.Play("push");

                float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
                StartCoroutine(NextLevel(fadeTime));

                // prevent this code from running again
                stopWorld = false;
            }
        }
    }

    // stop user interaction and camera
    void StopActions()
    {
        // we will stop the world as soon as the witch is centered
        // (see Update)
        stopWorld = true;
        cam = Camera.main.gameObject;

        GameObject player = GameObject.Find("Player");
        PlayerControl control = player.GetComponent<PlayerControl>();
        control.Stop();
        
    }
}
