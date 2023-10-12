using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ZombieGame : UI_Scene
{
    enum Images
    {
        BlankImage,
    }
    enum Texts
    {
        TitleText,
    }
    enum Buttons
    {
        StopButton,
    }

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Bind
        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));
        #endregion

        GetText((int)Texts.TitleText).text = "나타나는 좀비들을 피하며 미로를 빠져나가세요!";

        return true;
    }

    public void BlankImage()
    {
    }
}
