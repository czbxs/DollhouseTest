

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string scene = "<Insert scene name>";
    public float duration = 1.0f;
    public Color color = Color.black;

    public void PerformTransition()
	{
      
       Transition.LoadLevel(scene, duration, color);
        
       
	}
    public void PerformNotads()
    {
        Transition.LoadLevel(scene, duration, color);
    }

}
