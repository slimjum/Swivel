using Microsoft.Xna.Framework.Graphics;
using StudioForge.BlockWorld;
using StudioForge.Engine;
using StudioForge.TotalMiner;
using StudioForge.TotalMiner.API;
using Swivel.Swappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swivel.EntryPoint
{
    public class ExamplePlugin : ITMPlugin
    {
        public void Callback(string data, GlobalPoint3D? p, ITMActor actor, ITMActor contextActor)
        {
            //throw new NotImplementedException();
        }

        public void Draw(ITMPlayer player, ITMPlayer virtualPlayer, Viewport vp)
        {
            //throw new NotImplementedException();
        }

        public bool HandleInput(ITMPlayer player)
        {
            return true;
        }

        public void Initialize(ITMPluginManager mgr, ITMMod mod)
        {
            Swapper.Setup();
            CoreGlobals.AudioManager.StopSongImmediately();

            //Debug.WriteLine("called Initialize");
        }

        public void InitializeGame(ITMGame game)
        {
            Debug.WriteLine("called InitializeGame");
        }

        public void PlayerJoined(ITMPlayer player)
        {
            player.AddToInventory(new InventoryItem(Item.Blueprint, 1, (byte)Item.Chest), out int index);
            //throw new NotImplementedException();
        }

        public void PlayerLeft(ITMPlayer player)
        {
            //throw new NotImplementedException();
        }

        public object[] RegisterLuaFunctions(ITMScriptInstance si)
        {
            return new object[0];
        }

        public void UnloadMod()
        {
            //Loader.Cleanup();

            //Debug.WriteLine("Unload");
            //throw new NotImplementedException();
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Update(ITMPlayer player)
        {
            //throw new NotImplementedException();
        }

        public void WorldSaved(int version)
        {
            //throw new NotImplementedException();
        }
    }

    class TMPluginProvider : ITMPluginProvider
    {
        public ITMPlugin GetPlugin()
        {
            return new ExamplePlugin();
        }

        public ITMPluginArcade GetPluginArcade()
        {
            return null;
        }

        public ITMPluginBiome GetPluginBiome()
        {
            return null;
        }

        public ITMPluginBlocks GetPluginBlocks()
        {
            return null;
        }

        public ITMPluginConfig GetPluginConfig()
        {
            return null;
        }

        public ITMPluginGUI GetPluginGUI()
        {
            return null;
        }

        public ITMPluginNet GetPluginNet()
        {
            return null;
        }
    }
}
