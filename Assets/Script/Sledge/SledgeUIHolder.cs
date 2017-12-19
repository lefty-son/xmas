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

    Vector3 uiPosition;

    private void Awake()
    {
        if (instance == null) instance = this;

    }
    private void Start()
    {
        uiPosition = Camera.main.WorldToScreenPoint(this.transform.position); 
    }

    public void HideAndInitCounter(){
        panel.SetActive(false);

        WhiteCounter();
    }

    public void PutCounter(){
        panel.SetActive(true);
        SledgeUIHolder.instance.UpdateCounterText();
        counterAnim.Play();
        panel.transform.position = uiPosition + new Vector3(75, 25, 0);
    }

    public void UpdateCounterText(){
        StringBuilder stb = new StringBuilder();
        stb.Append(GameManager.instance.Stack);
        stb.Append(" / ");

        stb.Append(PrefManager.instance.GetSledMaxCalc());
        counterText.text = stb.ToString();
    }

    public void Dollar(){
        dollar.SetActive(true);
        dollarText.gameObject.SetActive(true);

        // Set dollar text
        var income = GameManager.instance.NowIncome;
        StringBuilder stb = new StringBuilder("+ ");
        stb.Append(income);
        stb.Append("$");
        dollarText.text = stb.ToString();

        GameManager.instance.ClearStack();
        dollar.transform.position = uiPosition + new Vector3(50, 25, 0);
    }

    public void WhiteCounter(){
        counterText.color = Color.white;
    }

}