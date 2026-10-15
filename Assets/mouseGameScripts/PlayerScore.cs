using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    private const int ScoreToFinish = 6;
    private const string EndingSceneName = "Ending";

    [SerializeField] private TMP_Text scoreText;

    public int Score { get; private set; }
    private bool endingStarted;

    private void Awake()
    {
        RefreshText();
    }

    public void AddCollectedItem()
    {
        if (endingStarted)
            return;

        Score++;
        RefreshText();

        if (Score >= ScoreToFinish)
        {
            endingStarted = true;
            StartCoroutine(LoadEndingAfterCollision());
        }
    }

    private void RefreshText()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {Score}";
    }

    private IEnumerator LoadEndingAfterCollision()
    {
        yield return null;
        SceneManager.LoadScene(EndingSceneName);
    }
}
