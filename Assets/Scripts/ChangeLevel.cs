using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

class ChangeLevel : MonoBehaviour
{
    IEnumerator NextLevel(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
        
        SceneManager.LoadScene(1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision!");
        //fade out the game and load new level
        float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
        StartCoroutine(NextLevel(fadeTime));
    }
}
