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
                SetAnimatorParameters("safetyLock", "������� �� �����", 2, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 2)
            {
                SetAnimatorParameters("frontSight", "������� �� �������", 3, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 3)
            {
                SetAnimatorParameters("swivel", "������� �� ��������� ��������", 4, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 4)
            {
                SetAnimatorParameters("stopPlate", "������� �� ����� ������", 5, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 5)
            {
                SetAnimatorParameters("sightProtector", "������� �� �����", 6, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 6)
            {
                SetAnimatorParameters("foreEnd", "������� �� ����", 7, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 7)
            {
                SetAnimatorParameters("muzzle", "������� �� �����", 8, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 8)
            {
                SetAnimatorParameters("trigger", "������� �� �������", 9, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 9)
            {
                SetAnimatorParameters("stock", "����� ������� �� �������", 10, 1.0f);
            }
            else if (GameManager.instance.disassemblyStep == 10)
            {
                SetAnimatorParameters("stock", "������� �� �����", 11, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 11)
            {
                SetAnimatorParameters("trigger", "������� �� ����", 12, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 12)
            {
                SetAnimatorParameters("muzzle", "������� �� �����", 13, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 13)
            {
                SetAnimatorParameters("foreEnd", "������� �� ����� ������", 14, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 14)
            {
                SetAnimatorParameters("sightProtector", "������� �� ��������� ��������", 15, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 15)
            {
                SetAnimatorParameters("stopPlate", "������� �� �������", 16, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 16)
            {
                SetAnimatorParameters("swivel", "������� �� �����", 17, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 17)
            {
                SetAnimatorParameters("frontSight", "������� �� ����������������� �����", 18, -10.0f);
            }
            else if (GameManager.instance.disassemblyStep == 18)
            {
                SetAnimatorParameters("safetyLock", "����������! �� ��������� ���� �  ������ ������", 19, -10.0f);
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