
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Animation>().Play("FadeInFadeOut");
        StartCoroutine(AnimationDone());
    }

    public IEnumerator AnimationDone()
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("level01");
    }
}
