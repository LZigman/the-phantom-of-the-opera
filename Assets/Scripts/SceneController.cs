using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Animator transitionAnim;
    private static readonly int End = Animator.StringToHash("End");
    private static readonly int Start = Animator.StringToHash("Start");

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    
    public void Retry()
    {
        StartCoroutine(ReloadLevel());
    }

    private IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger(End);
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger(Start);
    }

    private IEnumerator ReloadLevel()
    {
        transitionAnim.SetTrigger(End);
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        transitionAnim.SetTrigger(Start);
    }
}
