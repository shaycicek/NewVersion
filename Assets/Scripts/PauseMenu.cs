using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public string input;
    public GameObject pauseMenuUI;
    public TMP_InputField enemyHP;
    public TMP_InputField enemyDFactor;
    public TMP_InputField playerHP;
    public TMP_InputField playerDFactor;
    public TMP_InputField allyHP;
    public TMP_InputField allyDamageFactor;
    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ResetGame()
    {
        Debug.Log("Resetting game");        
        SceneManage.ReloadScene(); // Deðiþebilir???
        
    }

    public void QuitMenu()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void SetEnemyHP()
    {
        PlayerPrefs.SetFloat("EnemyHealth", float.Parse(enemyHP.text));
    }
    public void SetEnemyDFactor()
    {
        PlayerPrefs.SetFloat("EnemyDFactor", float.Parse(enemyDFactor.text));
    }
    public void SetPlayerHP()
    {
        PlayerPrefs.SetFloat("PlayerHealth", float.Parse(playerHP.text));
    }
    public void SetPlayerDFactor()
    {
        PlayerPrefs.SetFloat("PlayerDFactor", float.Parse(playerDFactor.text));
    }
    public void SetAllyHP()
    {
        PlayerPrefs.SetFloat("AllyHealth", float.Parse(allyHP.text));
    }
    public void SetAllyDFactor()
    {
        PlayerPrefs.SetFloat("AllyDFactor", float.Parse(allyDamageFactor.text));
    }


}
