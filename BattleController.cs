using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    public Text textBoxText;
    public RectTransform textBoxBox;
    public GameObject continueText;

    public Image[] buttonBlockers;

    public BattleStep[] steps;
    public int step = 0;

    public float delay;
    private float curDelay;

    GameController gameController;


    void Awake(){
        gameController = FindObjectOfType<GameController>();

        curDelay = delay;
    }

    public void Start(){
        LaunchStep(steps[0]);
    }

    void Update(){
        if(curDelay < 0 && step != 8 && step != 12 && step != 16 && step != 21 && step != 25 && step != 29){
            continueText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
                NextStep();
            if(step >= 31)
                SceneManager.LoadScene("Middle Cutscene");
        }
        else{
            curDelay -= Time.deltaTime;
            continueText.SetActive(false);
        }
        
    }

    void NextStep(){
        curDelay = delay;
        step++;
        LaunchStep(steps[step]);
    }

    public void LaunchStep(BattleStep s){
        if(s.equation == null){
            textBoxBox.gameObject.SetActive(true);
            textBoxBox.sizeDelta = s.textboxSize;
            textBoxText.GetComponent<RectTransform>().sizeDelta = s.textSize;
            textBoxText.text = s.text;

            if(step == 8){
                buttonBlockers[2].gameObject.SetActive(false);
            }
            if(step == 12){
                buttonBlockers[0].gameObject.SetActive(false);
            }
            if(step == 16){
                buttonBlockers[1].gameObject.SetActive(false);
            }
            if(step == 21){
                buttonBlockers[3].gameObject.SetActive(false);
            }
            if(step == 25){
                buttonBlockers[4].gameObject.SetActive(false);
            }
            if(step == 29){
                buttonBlockers[5].gameObject.SetActive(false);
            }

        }
        else{
            textBoxBox.gameObject.SetActive(false);
            gameController.NextProblem(s.equation);

                StartCoroutine(MiddleMan());
        }
    }

    IEnumerator MiddleMan(){
        yield return new WaitForSeconds(1.9f);
        NextStep();
    }

    public void PowerESolved(){
        buttonBlockers[2].gameObject.SetActive(true);
        NextStep();
    }
    public void SumESolved(){
        buttonBlockers[0].gameObject.SetActive(true);
        NextStep();
    }
    public void DiffESolved(){
        buttonBlockers[1].gameObject.SetActive(true);
        NextStep();
    }
    public void ProductESolved(){
        buttonBlockers[3].gameObject.SetActive(true);
        NextStep();
    }
    public void QuotientESolved(){
        buttonBlockers[4].gameObject.SetActive(true);
        NextStep();
    }
    public void ChainESolved(){
        buttonBlockers[5].gameObject.SetActive(true);
        NextStep();
    }
}
