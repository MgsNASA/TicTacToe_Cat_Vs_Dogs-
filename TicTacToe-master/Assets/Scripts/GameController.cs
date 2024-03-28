using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;
using System.Threading.Tasks;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText; // Текст для отображения лучшего счета
    public Text startText;

    public int currentScore;
    private int bestScore; // Переменная для хранения лучшего счета

    void Start( )
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt ( "BestScore" , 0 ); // Загрузка лучшего счета из PlayerPrefs
        bestScoreText.text = bestScore.ToString (); // Установка текста лучшего счета при старте
        SetScore ();
    }

    void Update( )
    {
        if ( Input.GetMouseButton ( 0 ) )
        {
            startText.gameObject.SetActive ( false );
        }
    }

    public void CallGameOver( )
    {
        StartCoroutine ( GameOver () );
    }

    IEnumerator GameOver( )
    {
        yield return new WaitForSeconds ( 0.5f );
        gameOverPanel.SetActive ( true );
        yield break;
    }

    public void Restart( )
    {
        SceneManager.LoadScene ( SceneManager.GetActiveScene ().buildIndex );
    }

    public void AddScore( )
    {
        currentScore++;
        if ( currentScore > bestScore )
        {
            bestScore = currentScore; // Обновление лучшего счета
            PlayerPrefs.SetInt ( "BestScore" , bestScore ); // Сохранение лучшего счета в PlayerPrefs
            bestScoreText.text = bestScore.ToString (); // Обновление текста лучшего счета
        }
        SetScore ();
    }

    void SetScore( )
    {
        currentScoreText.text = currentScore.ToString ();
    }
    private void OnEnable( )
    {
        GetData ();
    }
    private void OnDisable( )
    {
        GetData ();
    }
    public async void GetData( )
    {
        YandexGame.NewLeaderboardScores ( "LeaderBoard",bestScore );
    }
}
