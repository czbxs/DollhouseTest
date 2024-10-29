

using UnityEngine;
using System.Collections;
// Soomla store
#if UNITY_ANDROID || UNITY_IOS
//using Soomla;
//using Soomla.Store;
//using Soomla.Profile;
#endif

public class MenuScene : MonoBehaviour 
{
    void Start()
    {

    }

    public void PlayButtonClick()
    {
        GetComponent<SceneTransition>().PerformTransition();
    }

    public void FirstButtonClick() 
    {
        GetComponent<SceneTransition>().PerformNotads();
    }
}
