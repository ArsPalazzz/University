using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;


public class ClickAnimation : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    public GameObject textMesh;




    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (animator != null)
        {
            if (GameManager.instance.disassemblyStep == 1)
            {
                SetAnimatorParameters("safetyLock", "Нажмите на мушку", 2, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 2)
            {
                SetAnimatorParameters("frontSight", "Нажмите на карабин", 3, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 3)
            {
                SetAnimatorParameters("swivel", "Нажмите на стопорную пластину", 4, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 4)
            {
                SetAnimatorParameters("stopPlate", "Нажмите на кожух ствола", 5, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 5)
            {
                SetAnimatorParameters("sightProtector", "Нажмите на цевье", 6, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 6)
            {
                SetAnimatorParameters("foreEnd", "Нажмите на дуло", 7, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 7)
            {
                SetAnimatorParameters("muzzle", "Нажмите на курок", 8, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 8)
            {
                SetAnimatorParameters("trigger", "Нажмите на приклад", 9, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 9)
            {
                SetAnimatorParameters("stock", "Снова нажмите на приклад", 10, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 10)
            {
                SetAnimatorParameters("stock", "Нажмите на курок", 11, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 11)
            {
                SetAnimatorParameters("trigger", "Нажмите на дуло", 12, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 12)
            {
                SetAnimatorParameters("muzzle", "Нажмите на цевье", 13, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 13)
            {
                SetAnimatorParameters("foreEnd", "Нажмите на кожух ствола", 14, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 14)
            {
                SetAnimatorParameters("sightProtector", "Нажмите на стопорную пластину", 15, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 15)
            {
                SetAnimatorParameters("stopPlate", "Нажмите на карабин", 16, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 16)
            {
                SetAnimatorParameters("swivel", "Нажмите на мушку", 17, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 17)
            {
                SetAnimatorParameters("frontSight", "Нажмите на предохранительный замок", 18, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 18)
            {
                SetAnimatorParameters("safetyLock", "Поздравляю! Вы завержили сбор и  разбор оружия", 19, -10.0f);
            }
        }
    }


    private void SetAnimatorParameters(string boolName, string nextText, int nextStep, float direction)
    {
        if (!AnimatorHasParameter(animator, boolName))
        {
            Debug.LogWarning($"Animator does not have a parameter named '{boolName}'.");
            return;
        }

        animator.SetBool(boolName, true);
        animator.SetFloat("direction", direction);
        textMesh.GetComponent<TextMeshProUGUI>().text = nextText;
        GameManager.instance.disassemblyStep = nextStep;

    }

    private bool AnimatorHasParameter(Animator animator, string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
            {
                return true;
            }
        }
        return false;
    }

   


   
}