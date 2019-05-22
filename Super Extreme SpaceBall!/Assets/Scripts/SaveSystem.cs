using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SaveProfile(Profile profile){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/profile.sav";
    }

}
