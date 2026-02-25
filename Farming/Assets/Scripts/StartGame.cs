using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Sprite[] sprites;
    private int index = 0;
    public Image image;
    //加载的UI
    public GameObject progressPanel;
    private AsyncOperation asyncOperation;
    public Text progressText;
    public GameObject loadingText;
    public Image progressTiao;
    public GameObject pressAnyKey;

    private int progress;
    private int loadProgress = 0;

    public GameObject titleText;
    public GameObject startBtn;
    public GameObject dialogue;
    private bool isDialogue = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && isDialogue == true)
        {
            index++;
            if (index < sprites.Length)
            {
                image.sprite = sprites[index];
            }
            else
            {
                //加载场景
                //SceneManager.LoadScene("Main");
                //异步加载
                StartCoroutine(LoadNewScene());
            }
        }
        if (asyncOperation == null)
            return;
        if (asyncOperation.progress < 0.9f)
        {
            progress = (int)(asyncOperation.progress * 100);
        }
        else
        {
            progress = 100;
        }
        if (loadProgress < progress)
        {
            loadProgress++;
            progressTiao.fillAmount = loadProgress * 5.0f / 100f;
            progressText.text = progress.ToString() + "%";
        }
        if (loadProgress == 100)
        {
            pressAnyKey.SetActive(true);
            loadingText.SetActive(false);
            if (Input.anyKeyDown)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
    IEnumerator LoadNewScene()
    {
        progressPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false;
        yield return asyncOperation;
    }
    public void StartButtonClick()
    {
        titleText.SetActive(false);
        startBtn.SetActive(false);
        dialogue.SetActive(true);
        isDialogue = true;
    }
}
