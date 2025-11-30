using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Score: " + PlayerController.score;
        PlayerController.score = 0;
    }

    // Button click
    public void OnButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
