using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MenuMain : MonoBehaviour
{
    [SerializeField]
   
   
    public TextMeshProUGUI message;
   

    public GameObject FixedSupport;
    public GameObject Clocks;
    public GameObject MetalBalka;
    public GameObject Pendant;
    public GameObject Weights;

    public Material RedMaterial;
   
    public string defaultText;

    public void Start()
    {
        defaultText = message.text;
       
    }

    public void InfoFixedSupport()
    {
        message.text = "Неподвижная опора установки служит каркасом для установки";
    }


    public void InfoClocks()
    {
        message.text = "Индикатор часового типа показывает величину силы упругости";
    }


    public void InfoMetalBalka()
    {
        message.text = "Засчет натяжения металлической балки изменяется сила упругости";
    }


    public void InfoPendant()
    {
        message.text = "На подвеску вешаются грузики";
    }


    public void InfoWeights()
    {
        message.text = "Грузики,благодаря которым мы можем замерять различные результаты";
    }
    
   
    public void OnExit()
    {
        message.text = defaultText;
    }

    
   
    
}
