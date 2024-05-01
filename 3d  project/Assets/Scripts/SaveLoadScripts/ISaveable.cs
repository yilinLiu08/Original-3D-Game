using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    DataDefinition GetDataID();

    void RegisterSaveData() => DataManager.Instance.RegisterSaveData(this);




    void UnRegisterSaveData() => DataManager.Instance.UnRegisterSaveData(this);

    void GetSaveData(Data data);

    void LoadData(Data data);


}
