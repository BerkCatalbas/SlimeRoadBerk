using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    private int Scorepoint=0;
    public AudioSource Collect;
    public Text ScoreText;
    public GameObject EndMenu, WinText,Ball;

    public void CollectDiamond(GameObject DiamondCollected) //Elmas Toplama Fonksiyonu
    {
        Collect.Play();
        Destroy(DiamondCollected);
        Scorepoint += 10;
        ScoreText.text ="Score: "+ Scorepoint.ToString();
    }

    public void Menu(bool Win) // Win yazisi gorunup gorunmemesi icin
    {
        Time.timeScale = 0f;
        EndMenu.SetActive(true);
        if (Win == true)
            WinText.SetActive(true);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {
        Ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update() // Platformun sonuna yaklastigimizda veya bug ile assagi dusersek eger oyun bitiyor
    {
        if (Ball.transform.position.x > 90)
            Menu(true);
        else if (Ball.transform.position.y < 0)
            Menu(false);
    }
   
}
