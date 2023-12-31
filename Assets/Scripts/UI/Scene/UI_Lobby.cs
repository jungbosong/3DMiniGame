using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby : UI_Scene
{
    enum Texts
    {
        TitleText,
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
        BindText(typeof(Texts));
        #endregion

        GetText((int)Texts.TitleText).text = "플레이어를 움직여 미니 게임을 고르세요.";

        return true;
    }
}