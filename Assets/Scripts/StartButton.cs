using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private bool _isMouseOnButton;
    private void OnMouseEnter()
    {
        _isMouseOnButton = true;
    }
    private void OnMouseExit()
    {
        _isMouseOnButton = false;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
