using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> pages;
    public Sprite[] muteSprites;
    private bool isMute;
    public Button muteButton;
    
    // Start is called before the first frame update
    void Start()
    {
       // muteButton = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToPage(int pageIndex)
    {
        if (pageIndex < pages.Count && pages[pageIndex] != null)
        {
            SetActiveAllPages(false);
            pages[pageIndex].gameObject.SetActive(true);
           // pages[pageIndex].SetSelectedUIToDefault();
        }
    }

    public void GoToPageByName(string pageName)
    {
        GameObject page = pages.Find(item => item.name == pageName);
        int pageIndex = pages.IndexOf(page);
        GoToPage(pageIndex);
    }
    
    public void SetActiveAllPages(bool activated)
    {
        if (pages != null)
        {
            foreach (GameObject page in pages)
            {
                if (page != null)
                    page.gameObject.SetActive(activated);
            }
        }
    }
    public void LoadLevelByName(string levelToLoadName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoadName);
    }

    public void Mute()
    {
        if (!isMute)
        {
            AudioListener.volume = 0;
            isMute = true;
            muteButton.GetComponent<Image>().sprite = muteSprites[1];
        }
        else
        {
            AudioListener.volume = 1;
            isMute = false;
            muteButton.GetComponent<Image>().sprite = muteSprites[0];
        }
    }
}
