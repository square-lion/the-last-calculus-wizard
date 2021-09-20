using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle2Controller : MonoBehaviour
{
    public Text textBoxText;
    public RectTransform textBoxBox;
    public GameObject continueText;


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
        if(curDelay < 0){
            continueText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
                NextStep();
            if(step == 8){
                SceneManager.LoadScene("End Cutscene");
            }
        }
        else{
            curDelay -= Time.deltaTime;
            continueText.SetActive(false);
        }
        
    }

    public void NextStep(){
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

        }
        else{
            textBoxBox.gameObject.SetActive(false);
            gameController.NextProblem(s.equation);

            //StartCoroutine(MiddleMan());
        }
    }

    IEnumerator MiddleMan(){
        yield return new WaitForSeconds(1.9f);
        NextStep();
    }
}
