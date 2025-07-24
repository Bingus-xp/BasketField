using HutongGames.PlayMaker.Actions;
using MSCLoader;
using System;
using System.Drawing;
using UnityEngine;

namespace BasketField
{
    public class BasketField : Mod
    {
        public override string ID => "BasketField"; // Your (unique) mod ID 
        public override string Name => "basketfield"; // Your mod name
        public override string Author => "BingusNTS"; // Name of the Author (your name)
        public override string Version => "1.0.0"; // Version
        public override string Description => ""; // Short description of your mod
        public override byte[] Icon { get => base.Icon; set => base.Icon = value; }
        public override void ModSetup()
        {
            SetupFunction(Setup.OnNewGame, Mod_OnNewGame);
            SetupFunction(Setup.OnLoad, Mod_OnLoad);
            SetupFunction(Setup.OnSave, Mod_OnSave);
            SetupFunction(Setup.Update, Mod_Update);
            SetupFunction(Setup.ModSettings, Mod_Settings);            
        }

        private void Mod_Settings()
        {
            
        }
        private void Mod_Settings_OnValueChanged(string key, object value)
        {
            
        }
        private void Mod_OnNewGame()
        {
            // Called once, when creating a new game. This is useful for deleting old mod saves
        }
        private void Mod_OnLoad()
        {   // texture name of basketball is "basketball2";;;;;;;;
            GameObject basketball = GameObject.Find("basketball(Clone)");
            Texture2D ab = LoadAssets.LoadTexture(this, "basketball2.png");
            basketball.GetComponent<MeshRenderer>().material.mainTexture = ab;


          basketball.transform.position = SaveLoad.ValueExists(this, "ballpos") ? SaveLoad.ReadValue<Vector3>(this, "ballpos") : new Vector3(-10.12888f, 0.3291786f, 14.16051f);
            basketball.transform.eulerAngles = SaveLoad.ValueExists(this, "ballrot") ? SaveLoad.ReadValue<Vector3>(this, "ballrot") : new Vector3(2.760237f, 343.119f, 358.9988f);

           
        }
        private void Mod_OnSave()
        {
            GameObject basketball = GameObject.Find("basketball(Clone)");
            SaveLoad.WriteValue<Vector3>(this, "ballpos", basketball.transform.position);
            SaveLoad.WriteValue<Vector3>(this, "ballrot", basketball.transform.eulerAngles);
            // Called once, when save and quit
            // Serialize your save file here.
        }
        private void Mod_Update()
        {
            // Update is called once per frame
        }
    }
}
