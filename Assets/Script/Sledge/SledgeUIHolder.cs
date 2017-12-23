using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SledgeUIHolder : MonoBehaviour
{
    public static SledgeUIHolder instance;

    public GameObject panel;
    public GameObject dollar;
    public Text dollarText;
    public Animation counterAnim;
    public Text counterText;

    public bool isDelvering;

    Vector3 uiPosition;

    private void Awake()
    {
        if (instance == null) instance = this;
        isDelvering = false;
    }
    private void Start()
    {
        //uiPosition = Camera.main.WorldToScreenPoint(this.transform.position); 
    }

    public void DoingDel(){
        isDelvering = true;

    }

    public void EndDel(){
        isDelvering = false;
    }

    public void HideAndInitCounter(){
        panel.SetActive(false);
        WhiteCounter();
    }

    public void PutCounter(){
        panel.SetActive(true);
        SledgeUIHolder.instance.UpdateCounterText();
        counterAnim.Play();
    }

    public void UpdateCounterText(){
        StringBuilder stb = new StringBuilder();
        stb.Append(GameManager.instance.Stack);
        stb.Append(" / ");

        stb.Append(PrefManager.instance.GetSledMaxCalc());
        counterText.text = stb.ToString();

        if(GameManager.instance.Stack == PrefManager.instance.GetSledMaxCalc()){
            FindObjectOfType<SledgeDeliver>().Deliver();
        }

    }

    public void Dollar(){
        dollar.SetActive(true);
        dollarText.gameObject.SetActive(true);

        // Set dollar text
        var income = GameManager.instance.NowIncome * GameManager.instance.incomeMultiply;
        StringBuilder stb = new StringBuilder("+ ");
        stb.Append(income);
        stb.Append("$");
        dollarText.text = stb.ToString();

        GameManager.instance.ClearStack();
    }

    public void WhiteCounter(){
        counterText.color = Color.white;
    }

}