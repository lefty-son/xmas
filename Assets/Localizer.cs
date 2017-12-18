using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour {
    public static Localizer instance;

    private readonly string upgrade_santa = "upgrade_santa";
    private readonly string upgrade_convey = "upgrade_convey";
    private readonly string sled_max = "sled_max";
    private readonly string sled_speed = "sled_speed";

    private Dictionary<string, string> dict;

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    public void Init(){
        dict = new Dictionary<string, string>();
        dict.Clear();
        FillDictionary();
    }

    private void FillDictionary(){
        var lang = PrefManager.instance.GetLanguage();

        // EN
        if(lang == 0){
            dict.Add(upgrade_santa, "Speed of Gift Packing");
            dict.Add(upgrade_convey, "Speed of conveyor belt");
            dict.Add(sled_max, "Sledging capacity");
            dict.Add(sled_speed, "Sleighing speed");
        }
        // KO
        else if(lang == 1){
            dict.Add(upgrade_santa, "선물 포장 속도");
            dict.Add(upgrade_convey, "컨베이어 벨트 속도");
            dict.Add(sled_max, "썰매 용량");
            dict.Add(sled_speed, "썰매 배달 속도");
        }
        // CN
        else if(lang == 2){
            dict.Add(upgrade_santa, "礼品包装速度");
            dict.Add(upgrade_convey, "传送带速度");
            dict.Add(sled_max, "雪橇容量");
            dict.Add(sled_speed, "雪橇递送速度");
        }
        // JP
        else if (lang == 3)
        {
            dict.Add(upgrade_santa, "贈り物の包装速度");
            dict.Add(upgrade_convey, "コンベアベルト速度");
            dict.Add(sled_max, "プレゼント積載量");
            dict.Add(sled_speed, "そりの送信速度");
        }
    }

    public string GetTextFromLocal(string _key){
        return dict[_key];
    }
}
