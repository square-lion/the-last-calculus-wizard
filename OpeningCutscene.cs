using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour{

    public Text textBoxText;

    public GameObject continueText;

    public Animator anim;

    public BattleStep[] steps;
    public int step;

    public float delay;
    private float curDelay;
    
    
    
    public void Start(){
        LaunchStep(steps[0]);
    }

    void Update(){
        if(curDelay < 0){
            continueText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
                NextStep();
            else if(step == 5)
                SceneManager.LoadScene("HouseIntegral");
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
            textBoxText.text = s.text;

            if(step == 3 || step == 4){
                anim.SetTrigger("Move");
            }
    }
}
