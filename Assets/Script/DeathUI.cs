using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathUI : MonoBehaviour
{
    public TextMeshProUGUI highStageText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI exitText;

    public float exitTime = 5;
    bool use;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            UIManager.instance.PindahScene("Mainmenu");

            AudioManager.instance.ButtonClickSFX();
        }


        if (exitTime <= 0 && !use)
        {
            use = true;
            UIManager.instance.PindahScene("Mainmenu");

            AudioManager.instance.ButtonClickSFX();
        }
        else if (exitTime > 0)
        {
            exitTime -= Time.deltaTime;
            exitText.text = "Kembali ke Menu utama " + exitTime.ToString("F0");
        }
    }

    public void Set(int stage)
    {
        GameSave.instance.SaveStage(stage);

        highStageText.text = "Tingkat tertinggi : " + GameSave.instance.highStage;
        stageText.text = "Tingkat ini : " + stage;
    }
}
