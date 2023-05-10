using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/***************************************
 * Authour: HAN 18080038
 * Object hold: tutorial ipad
 * Content: tutorial behaviour
 **************************************/
public class TutorialBehaviour : MonoBehaviour
{
    [Header("Pages")]
    public GameObject[] tutorialSection; // tutorial section
    public TutorialPagesScriptable[] instructionPages; // instruction pages


    [Header("Insutrction pad")]
    public Image instructionImage; // image to display
    public Text instructionText; //instruction text
    public Text tutorialSectionText;//instruction section text
    private int instrtuctionImageID; //currennt instruciton image 
    private int instructionTextID; // currennt instruction text
    private int _currentTutorial = 0; // current tutorial
    private AudioSource audioSrc; // audio source

    // Start is called before the first frame update
    void Start()
    {
        //get audio source
        audioSrc = this.gameObject.GetComponent<AudioSource>();
        //if lenght array of every item not euqal to each other
        if(tutorialSection.Length != instructionPages.Length || instructionPages.Length != tutorialSection.Length )
        {
           Debug.LogError("ARRAY SIZE ARE NOT THE SAME");
        }
        ChangeTutorial(0);
    }

    public void ChangeTutorial(int _tutorialToChange)
    {
        //increase tutorial id
        _currentTutorial += _tutorialToChange;
        
        //if tutorial length is exceed
        if(_currentTutorial >= tutorialSection.Length - 1 || _currentTutorial < -1)
        {
            //set current tutorial back to beginning
            _currentTutorial = 0;
        }
        //change tutoral section
        if(_currentTutorial - 1 != -1) tutorialSection[_currentTutorial -1].SetActive(false);
        if(tutorialSection[_currentTutorial] != null)tutorialSection[_currentTutorial].SetActive(true);

        //set instruction section text
        tutorialSectionText.text = instructionPages[_currentTutorial].tutorialSectionName;
        //set instruction text
        instructionText.text = instructionPages[_currentTutorial].text[0];
        //if turotial image does exist then change image
        if(instructionPages[_currentTutorial].images[0] != null) instructionImage.sprite = instructionPages[_currentTutorial].images[0];
    }

    public void ChangeTutorialPage(int _pageToChange)
    {
        instructionTextID += _pageToChange; // increase text id
        instrtuctionImageID += _pageToChange; //increase image id
        
        //if image id or text id exceed their own length then set id back to beginning
        if(instructionTextID >= instructionPages[_currentTutorial].text.Length - 1) instructionTextID = 0;
        if(instrtuctionImageID >= instructionPages[_currentTutorial].images.Length - 1) instrtuctionImageID = 0;
        //set instruction text
        instructionText.text = instructionPages[_currentTutorial].text[instructionTextID];
        //if image id does exist
        if(instructionPages[_currentTutorial].images != null)
        {
            //enable image
            instructionImage.enabled = true;
            //set image sprite
            instructionImage.sprite = instructionPages[_currentTutorial].images[instrtuctionImageID];
        } 
        else
        {
            //disable image
            instructionImage.enabled = false;
        }

        if(instructionPages[_pageToChange].tutorialClip[_pageToChange] == null || 
           instructionPages[_pageToChange].tutorialClip.Length <= 0 || 
           instructionPages[_pageToChange].tutorialClip.Length != instructionPages[_pageToChange].text.Length) return;
           
        audioSrc.PlayOneShot(instructionPages[_pageToChange].tutorialClip[_pageToChange],1);
    }

    public void Exit()
    {
        SceneManager.LoadScene("PlayerHub");
    }
}
