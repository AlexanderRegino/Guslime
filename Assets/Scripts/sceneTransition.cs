using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Image fadeImage;
    [SerializeField] Color fadeColor = Color.black;
    [SerializeField] float fadeTime = 1;

    void Start()
    {
        FadeInSlide();
    }


    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine()
        {
            float timer = 0;
            while(timer < fadeTime) //Decrement until timer depletes 
            {
                timer += Time.deltaTime; //Add the time from last frame
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f - (timer / fadeTime));

                yield return null; //Wait for a frame
            }
            fadeImage.color = Color.clear;
            yield return null;
        }
    }


    public void FadeOut(string sceneName)
    {
        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine()
        {
            float timer = 0;
            while (timer < fadeTime) //Decrement until timer depletes 
            {
                timer += Time.deltaTime; //Add the time from last fram     
                yield return null; //Wait for a frame
            }
            fadeImage.color = Color.clear;
            yield return null;
            SceneManager.LoadScene(sceneName);
        }
    }



    public void FadeOutSlide(string levelName)
    {
        StartCoroutine(FadeOutSlideRoutine(levelName));
    }
    IEnumerator FadeOutSlideRoutine(string levelName)
    {
        float timer = 0;
        Vector3 initialPosition = fadeImage.transform.position;
        Vector3 targetPosition = initialPosition - Vector3.up * Screen.height; // Move it downwards by the screen height

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float t = timer / fadeTime;
            fadeImage.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        // Optionally wait for an additional moment if desired
        yield return new WaitForSeconds(0.5f);

        // Save the current level to PlayerPreferences
        PlayerPrefs.SetString("CurrentLevel", levelName);
        PlayerPrefs.Save();

        // You can trigger any additional logic here if needed

        // For example, if you want to reset the scene without loading a new scene
        SceneManager.LoadScene("MainGameplayLoop");

        // Or if you have other logic, you can call it here
    }

    public void FadeInSlide()
    {
        StartCoroutine(FadeOutSlideRoutine());
        IEnumerator FadeOutSlideRoutine()
        {
            float timer = 0;
            Vector3 initialPosition = fadeImage.transform.position;
            Vector3 targetPosition = initialPosition + Vector3.up * Screen.height;

            while (timer < fadeTime)
            {
                timer += Time.deltaTime;
                float t = timer / fadeTime;
                fadeImage.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
                yield return null;
            }
            yield return null;
        }
    }
}
