using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    
    public bool takeHealth;
    
    
    //General
    public int playerHealth = 100;
    public int enemyHealth = 100;

    //Enemies
    public Animator ryan;
    public Animator player;

    public Equation[] equations;
    public int equationID = 0;
    public Equation curEquation;

    //Button UI
    public Image playerHealthCircle;
    public Image enemyHealthCircle;

    public Button[] ruleButtons;

    public ColorBlock basic;

    void Awake(){
        basic = ruleButtons[0].colors;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            //NextProblem();
        }
    }

    //When New Problem
    public void NextProblem(Equation e){
        ryan.SetTrigger("Attack");
        curEquation = Instantiate(e, transform.position, transform.rotation);
    }


    //IDs are 0-5
    public void RuleButtonClicked(int id){
        player.SetTrigger("Attack");

        ruleButtons[id].interactable = false;

        ColorBlock temp = basic;
        temp.disabledColor = Color.red;

        ruleButtons[id].colors = temp;


        if(curEquation.rules[id]){
            curEquation.rules[id] = false;
            curEquation.ruleNumber--;

            
            ColorBlock p = basic;
            p.disabledColor = Color.green;

            ruleButtons[id].colors = p;

            if(curEquation.ruleNumber == 0)
                Solved();
        }
        else{
            TakePlayerHealth(10);
        }
    }

    public void TakePlayerHealth(int amount){
        playerHealth -= amount;
        playerHealthCircle.fillAmount = playerHealth/100f;
    }

    public void TakeEnemyHealth(int amount){
        enemyHealth -= amount;
        enemyHealthCircle.fillAmount = enemyHealth/100f;
    }

    public void Solved(){
        if(takeHealth)
            TakeEnemyHealth(20);

        curEquation.Solved();

        foreach(Button b in ruleButtons){
            b.interactable = true;
            b.colors = basic;
        }

        equationID++;
    }
}
