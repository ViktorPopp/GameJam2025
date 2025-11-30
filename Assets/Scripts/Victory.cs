using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Button click
    public void OnButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
