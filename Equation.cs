using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equation : MonoBehaviour
{
    [Header("Info")]
    public string equation;
    public string solution;

    [Header("Rules Needed")]
    /*Index Rules
    0 - Sum
    1 - Diff
    2 - Power
    3 - Product
    4 - Quotient
    5 - Chain
    */
    public bool[] rules;
    public int ruleNumber;

    private Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    public void Solved(){
        animator.SetTrigger("Solved");
    }

    public void CheckForTrigger(){
        if(gameObject.name == "PowerE(Clone)")
            FindObjectOfType<BattleController>().PowerESolved();
        if(gameObject.name == "SumE(Clone)")
            FindObjectOfType<BattleController>().SumESolved();
        if(gameObject.name == "DiffE(Clone)")
            FindObjectOfType<BattleController>().DiffESolved();
        if(gameObject.name == "ProductE(Clone)")
            FindObjectOfType<BattleController>().ProductESolved();
        if(gameObject.name == "QuotientE(Clone)")
            FindObjectOfType<BattleController>().QuotientESolved();
        if(gameObject.name == "ChainE(Clone)")
            FindObjectOfType<BattleController>().ChainESolved();
    }

    public void AnimationCompeted(){
        Destroy(this.gameObject);
    }

    public void BattleFinish(){
        FindObjectOfType<Battle2Controller>().NextStep();
    }
}
