using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float timeReqired;

    private float m_CurrTime;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        m_CurrTime = timeReqired;
    }

    private void Update()
    {
        m_CurrTime -= Time.deltaTime;
        if(m_CurrTime <= 0)
        {
            LoadNextScene();
        }
        text.text = m_CurrTime.ToString("0");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
