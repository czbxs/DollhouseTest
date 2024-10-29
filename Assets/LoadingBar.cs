using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Image loadingImage;
    public GameObject loadingbg;
    public GameObject MenuController; // ��� MenuController ����

    private MenuScene menuScene; // ���ڴ洢 MenuScene ���

    private async void Start()
    {
        menuScene = MenuController.GetComponent<MenuScene>();

        StartCoroutine(FillLoadingBar());

    }


    private IEnumerator FillLoadingBar()
    {

        float duration = 5f; // Duration in seconds
        float currentTime = 0f;

        while (currentTime <= duration)
        {
            float fillAmount = currentTime / duration;
            loadingImage.fillAmount = fillAmount;
            currentTime += Time.deltaTime;
            yield return null;
        }

        GotoNextScene();
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL(""); // Replace with your actual privacy policy URL
    }


    private void GotoNextScene()
    {
        
        menuScene.FirstButtonClick();
    
    }




}
