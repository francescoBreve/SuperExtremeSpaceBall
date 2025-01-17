﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {



    public static void SaveProfile(Profile profile){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/profile.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
       
      
        Profile data = profile;
        formatter.Serialize(stream, data);
        System.IO.File.WriteAllText(Application.persistentDataPath +"/NotConvertedprofile.txt", data.toString());

        stream.Close();
    }

    public static Profile LoadProfile(){
        string path = Application.persistentDataPath + "/profile.sav";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Profile tmp = formatter.Deserialize(stream) as Profile;
            stream.Close();

            Profile toReturn = tmp;
            return toReturn;

        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
