using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class Data
{
    [Serializable]
    public class ScenePos
    {
        [SerializeField]
        private string name;
        public string Name => name;
        [SerializeField]
        public bool isSave;
        [SerializeField]
        private float x, y, z;

        public ScenePos(string name)
        {
            this.name = name;
            isSave = false;
            x = 0; y = 0; z = 0;
        }

        public void SetPos(Vector3 pos)
        {
            x = pos.x; y = pos.y; z = pos.z;
        }

        public Vector3 GetPos()
        {
            return new Vector3(x, y, z);
        }
    }

    [Serializable]
    public class PlayerData
    {
        [SerializeField]
        private string id;
        public string ID => id;
        [SerializeField]
        private List<ScenePos> scenePos = new List<ScenePos>();
        public int hp;
        public bool[] skill;

        public PlayerData(string playerID)
        {
            id = playerID;
            scenePos = new List<ScenePos>();
            hp = 0;
            skill = new bool[3];
        }

        public void SetPos(string sceneName, Vector3 pos)
        {
            foreach (ScenePos scenePos in scenePos)
            {
                if (scenePos.Name == sceneName)
                {
                    scenePos.SetPos(pos);
                    return;
                }
            }
            var newPos = new ScenePos(sceneName);
            newPos.SetPos(pos);
            scenePos.Add(newPos);
        }

        public bool GetPos(string sceneName, ref Vector3 pos)
        {
            foreach (ScenePos scenePos in scenePos)
            {
                if (scenePos.Name == sceneName)
                {
                    pos = scenePos.GetPos();
                    return true;
                }
            }
            return false;
        }
    }

    [SerializeField]
    private List<PlayerData> playerDatas = new List<PlayerData>();

    public PlayerData GetData(string playerID)
    {
        foreach (PlayerData playerData in playerDatas)
        {
            if (playerData.ID == playerID)
            {
                return playerData;
            }
        }
        return null;
    }

    public void Add(string playerID, Vector3 pos, int hp, bool[] skill)
    {
        var playerData = new PlayerData(playerID);
        playerData.SetPos(SceneManager.GetActiveScene().name, pos);
        playerData.hp = hp;
        playerData.skill = skill;
        playerDatas.Add(playerData);
    }

    //public Dictionary<string, Vector3> characterPosDict = new Dictionary<string, Vector3>();
    //public Dictionary<string, int> intSavedData = new Dictionary<string, int>();
    //public Dictionary<string, float> floatSavedData = new Dictionary<string, float>();
}
