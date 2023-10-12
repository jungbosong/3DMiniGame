using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            switch(Managers.Scene.GetCurrentScene())
            {
                case "LobbyScene":
                    Managers.Scene.ChangeScene(Define.Scene.ZombieGameScene);
                    break;
                case "ZombieGameScene":

                    break;
            }
        }
    }
}
