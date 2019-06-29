using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SharpDX;
using SharpDX.Direct3D9;
using PoeHUD.Controllers;
using PoeHUD.Framework.Helpers;
using PoeHUD.Hud;
using PoeHUD.Models;
using PoeHUD.Plugins;
using PoeHUD.Poe.Components;
using PoeHUD.Poe.RemoteMemoryObjects;
using PoeHUD.Poe.Elements;
using Delve.Libs;


namespace Delve
{
    public partial class Delve : BaseSettingsPlugin<Settings>
    {
        #region Global Scope
        private RectangleF _drawRect;



        public float CurrentDelveMapZoom = 0.635625f;

        private HashSet<EntityWrapper> _delveEntities;

        public Version version = Assembly.GetExecutingAssembly().GetName().Version;
        public string PluginVersion;
        public DateTime buildDate;

        public static int Selected;


        public static int idPop;

        public string CustomImagePath;

        public string PoeHudImageLocation;

        private string _areaName;
        private bool DelveIsAzuriteMine => _areaName == "Azurite Mine" ? true : false;

        public FossilTiers FossilList = new FossilTiers();
        
        //needed to be added for custom delve file
        public ContainersTires DelveContainersList = new ContainersTires();

        public LargeMapData LargeMapInformation { get; set; }

        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            },
        };

        //cloned for new json file 
        public static readonly JsonSerializerSettings JsonDelveContainers = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            },
        };
        #endregion

        #region Initialise
        public override void Initialise()
        {
            buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);

            PluginName = "Delve";
            PluginVersion = $"{version}";
            _delveEntities = new HashSet<EntityWrapper>();
            PoeHudImageLocation = PluginDirectory + @"\..\..\textures\";
            CustomImagePath = PluginDirectory + @"\Resources\";

            OnAreaChange += AreaChange;

            if (File.Exists($@"{PluginDirectory}\Fossil_Tiers.json"))
            {
                var jsonFile = File.ReadAllText($@"{PluginDirectory}\Fossil_Tiers.json");
                FossilList = JsonConvert.DeserializeObject<FossilTiers>(jsonFile, JsonSettings);

            }
            else
            {
                LogError("Error loading Fossil_Tiers.json, Please re-download from github repository",
                    10);
            }

            //load Delve Chest jason file
            if (File.Exists($@"{PluginDirectory}\DelveContainers.json"))
            {
                var containers = File.ReadAllText($@"{PluginDirectory}\DelveContainers.json");
                DelveContainersList = JsonConvert.DeserializeObject<ContainersTires>(containers, JsonDelveContainers);
            }

            else
            {
                LogError("Error loading DelveContainers.json, Please re-download from github repository",
                    10);
            }
            //end of new json file load

            StringNicer.InitList();
        }

        #endregion
        
        #region Render
        public override void Render()
        {
            base.Render();
            if (!Settings.Enable.Value || !DelveIsAzuriteMine) return;
            if (!Settings.DelveChests) return;
            {
                foreach (var entity in _delveEntities.ToArray())
                {
                    //Mining Supplies

                    #region Delve Mining Supplies

                    if (Settings.DelveMiningSuppliesChestLabel.Value && DelveContainersList.DelveMiningSupplies.ToList()
                            .Any(s =>
                                string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }
                        
                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveMiningSuppliesChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMiningSuppliesChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMiningSuppliesChestLabelBorderSize,
                            Settings.DelveMiningSuppliesChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveMiningSuppliesChestLabelSize, screenPosition,
                            Settings.DelveMiningSuppliesChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveMiningSuppliesDynamiteChestLabel.Value && DelveContainersList
                                 .DelveMiningSuppliesDynamite.ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveMiningSuppliesDynamiteChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMiningSuppliesDynamiteChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMiningSuppliesDynamiteChestLabelBorderSize,
                            Settings.DelveMiningSuppliesDynamiteChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveMiningSuppliesDynamiteChestLabelSize, screenPosition,
                            Settings.DelveMiningSuppliesDynamiteChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveMiningSuppliesFlaresChestLabel.Value && DelveContainersList
                                 .DelveMiningSuppliesFlares.ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveMiningSuppliesFlaresChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMiningSuppliesFlaresChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMiningSuppliesFlaresChestLabelBorderSize,
                            Settings.DelveMiningSuppliesFlaresChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveMiningSuppliesFlaresChestLabelSize, screenPosition,
                            Settings.DelveMiningSuppliesFlaresChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Azurite

                    #region Azurite Nodes

                    else if (Settings.DelveAzuriteVeinChestLabel.Value && DelveContainersList.DelveAzurite.ToList().Any(
                                 s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveAzuriteVeinChestLabelSize,
                            FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);

                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveAzuriteVeinChestLabelColor);

                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveAzuriteVeinChestLabelBorderSize,
                            Settings.DelveAzuriteVeinChestLabelBorderColor);

                        Graphics.DrawText(textToDisplay, Settings.DelveAzuriteVeinChestLabelSize, screenPosition,
                            Settings.DelveAzuriteVeinChestLabelTextColor, FontDrawFlags.Center);

                    }

                    #endregion

                    //Delve Resonators

                    #region Delve Resonators

                    else if (Settings.DelveResonatorTier1ChestLabel.Value && DelveContainersList.DelveResonatorTier1
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveResonatorTier1ChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveResonatorTier1ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveResonatorTier1ChestLabelBorderSize,
                            Settings.DelveResonatorTier1ChestLabelBorderColor);

                        Graphics.DrawText(textToDisplay, Settings.DelveResonatorTier1ChestLabelSize, screenPosition,
                            Settings.DelveResonatorTier1ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveResonatorTier2ChestLabel.Value && DelveContainersList.DelveResonatorTier2
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveResonatorTier2ChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveResonatorTier2ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveResonatorTier2ChestLabelBorderSize,
                            Settings.DelveResonatorTier2ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveResonatorTier2ChestLabelSize, screenPosition,
                            Settings.DelveResonatorTier2ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveResonatorTier3ChestLabel.Value && DelveContainersList.DelveResonatorTier3
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveResonatorTier3ChestLabelSize, FontDrawFlags.Center);
                        var screenPosition = GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);

                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveResonatorTier3ChestLabelColor);

                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveResonatorTier3ChestLabelBorderSize,
                            Settings.DelveResonatorTier3ChestLabelBorderColor);

                        Graphics.DrawText(textToDisplay, Settings.DelveResonatorTier3ChestLabelSize, screenPosition,
                            Settings.DelveResonatorTier3ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Fossils

                    #region Delve Fossils

                    else if (Settings.DelveFossilTier1ChestLabel.Value && DelveContainersList.DelveFossilTier1.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveFossilTier1ChestLabelSize, FontDrawFlags.Center);

                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFossilTier1ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFossilTier1ChestLabelBorderSize,
                            Settings.DelveFossilTier1ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveFossilTier1ChestLabelSize, screenPosition,
                            Settings.DelveFossilTier1ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveFossilTier2ChestLabel.Value && DelveContainersList.DelveFossilTier2.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveFossilTier2ChestLabelSize, FontDrawFlags.Center);

                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFossilTier2ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFossilTier2ChestLabelBorderSize,
                            Settings.DelveFossilTier2ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveFossilTier2ChestLabelSize, screenPosition,
                            Settings.DelveFossilTier2ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveFossilTier3ChestLabel.Value && DelveContainersList.DelveFossilTier3.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveFossilTier3ChestLabelSize, FontDrawFlags.Center);

                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFossilTier3ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFossilTier3ChestLabelBorderSize,
                            Settings.DelveFossilTier3ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveFossilTier3ChestLabelSize, screenPosition,
                            Settings.DelveFossilTier3ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Currency

                    #region Delve Currency

                    else if (Settings.DelveCurrencyTier1ChestLabel.Value && DelveContainersList.DelveCurrencyTier1
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveCurrencyTier1ChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveCurrencyTier1ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveCurrencyTier1ChestLabelBorderSize,
                            Settings.DelveCurrencyTier1ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveCurrencyTier1ChestLabelSize, screenPosition,
                            Settings.DelveCurrencyTier1ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveCurrencyTier2ChestLabel.Value && DelveContainersList.DelveCurrencyTier2
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveCurrencyTier2ChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveCurrencyTier2ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveCurrencyTier2ChestLabelBorderSize,
                            Settings.DelveCurrencyTier2ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveCurrencyTier2ChestLabelSize, screenPosition,
                            Settings.DelveCurrencyTier2ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveCurrencyTier3ChestLabel.Value && DelveContainersList.DelveCurrencyTier3
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveCurrencyTier3ChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveCurrencyTier3ChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveCurrencyTier3ChestLabelBorderSize,
                            Settings.DelveCurrencyTier3ChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveCurrencyTier3ChestLabelSize, screenPosition,
                            Settings.DelveCurrencyTier3ChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve On/Off Pathway Chest

                    #region On/Off Pathway Chest

                    else if (Settings.DelveOnPathwayChestLabel.Value && DelveContainersList.DelveOnPath.ToList().Any(
                                 s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveOnPathwayChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);

                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveOnPathwayChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveOnPathwayChestLabelBorderSize, Settings.DelveOnPathwayChestLabelBorderColor);

                        Graphics.DrawText(textToDisplay, Settings.DelveOnPathwayChestLabelSize, screenPosition,
                            Settings.DelveOnPathwayChestLabelTextColor, FontDrawFlags.Center);
                    }

                    else if (Settings.DelveOffPathwayChestLabel.Value && DelveContainersList.DelveOffPath.ToList().Any(
                                 s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveOffPathwayChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);

                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveOffPathwayChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveOffPathwayChestLabelBorderSize,
                            Settings.DelveOffPathwayChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveOffPathwayChestLabelSize, screenPosition,
                            Settings.DelveOffPathwayChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Generic Chest

                    #region Delve Generic Chest

                    else if (Settings.DelveGenericChestLabel.Value && DelveContainersList.DelveGenericChest.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveGenericChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveGenericChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveGenericChestLabelBorderSize, Settings.DelveGenericChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveGenericChestLabelSize, screenPosition,
                            Settings.DelveGenericChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Armour Chest

                    #region Delve Armour Chest

                    else if (Settings.DelveArmourChestLabel.Value && DelveContainersList.DelveArmourChest.ToList().Any(
                                 s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveArmourChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveArmourChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveArmourChestLabelBorderSize, Settings.DelveArmourChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveArmourChestLabelSize, screenPosition,
                            Settings.DelveArmourChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Weapon Chest

                    #region Delve Weapon Chest

                    else if (Settings.DelveWeaponChestLabel.Value && DelveContainersList.DelveWeaponChest.ToList().Any(
                                 s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveWeaponChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveWeaponChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveWeaponChestLabelBorderSize, Settings.DelveWeaponChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveWeaponChestLabelSize, screenPosition,
                            Settings.DelveWeaponChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Trinket Chest

                    #region Delve Trinket Chest

                    else if (Settings.DelveTrinketChestLabel.Value && DelveContainersList.DelveTrinketChest.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveTrinketChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveTrinketChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveTrinketChestLabelBorderSize, Settings.DelveTrinketChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveTrinketChestLabelSize, screenPosition,
                            Settings.DelveTrinketChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Gem Chest

                    #region Delve Gem Chest

                    else if (Settings.DelveGemChestLabel.Value && DelveContainersList.DelveGemChest.ToList().Any(s =>
                                 string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveGemChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveGemChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveGemChestLabelBorderSize, Settings.DelveGemChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveGemChestLabelSize, screenPosition,
                            Settings.DelveGemChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Vaal Chest

                    #region Delve Vaal Chest

                    else if (Settings.DelveVaalChestLabel.Value && DelveContainersList.DelveVaalChest.ToList().Any(s =>
                                 string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveVaalChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveVaalChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveVaalChestLabelBorderSize, Settings.DelveVaalChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveVaalChestLabelSize, screenPosition,
                            Settings.DelveVaalChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Abyssal Chest

                    #region Delve Abyssal Chest

                    else if (Settings.DelveAbyssalChestLabel.Value && DelveContainersList.DelveAbyssalChest.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveAbyssalChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveAbyssalChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveAbyssalChestLabelBorderSize, Settings.DelveAbyssalChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveAbyssalChestLabelSize, screenPosition,
                            Settings.DelveAbyssalChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Dynamite Chest

                    #region Delve Dynamite Chest

                    else if (Settings.DelveDynamiteChestLabel.Value && DelveContainersList.DelveDynamiteChest.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveDynamiteChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveDynamiteChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveDynamiteChestLabelBorderSize, Settings.DelveDynamiteChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveDynamiteChestLabelSize, screenPosition,
                            Settings.DelveDynamiteChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Legacy League Chest

                    #region Delve Legacy League Chest

                    else if (Settings.DelveLegacyLeagueChestLabel.Value && DelveContainersList.DelveLegacyLeagueChest
                                 .ToList().Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveLegacyLeagueChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveLegacyLeagueChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveLegacyLeagueChestLabelBorderSize,
                            Settings.DelveLegacyLeagueChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveLegacyLeagueChestLabelSize, screenPosition,
                            Settings.DelveLegacyLeagueChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Map Chest

                    #region Delve Map Chest

                    else if (Settings.DelveMapChestLabel.Value && DelveContainersList.DelveMapChest.ToList().Any(s =>
                                 string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveMapChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMapChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveMapChestLabelBorderSize, Settings.DelveMapChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveMapChestLabelSize, screenPosition,
                            Settings.DelveMapChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Fragment Chest

                    #region Delve Fragment Chest

                    else if (Settings.DelveFragmentChestLabel.Value && DelveContainersList.DelveFragmentChest.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveFragmentChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFragmentChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveFragmentChestLabelBorderSize, Settings.DelveFragmentChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveFragmentChestLabelSize, screenPosition,
                            Settings.DelveFragmentChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //Delve Special Chest

                    #region Delve Special Chest

                    else if (Settings.DelveSpecialChestLabel.Value && DelveContainersList.DelveSpecialChest.ToList()
                                 .Any(s =>
                                     string.Equals(s, entity.Path, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        var textToDisplay = "";

                        var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                        switch (Settings.NiceString.Value)
                        {
                            case true:
                                textToDisplay = stringifyReturn.IsFound
                                    ? stringifyReturn.NiceString
                                    : stringifyReturn.UglyString.Split('/').Last();
                                break;
                            case false:
                                textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                break;
                        }

                        var textBox = Graphics.MeasureText(textToDisplay, Settings.DelveSpecialChestLabelSize, FontDrawFlags.Center);
                        var screenPosition =
                            GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);
                        Graphics.DrawBox(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveSpecialChestLabelColor);
                        Graphics.DrawFrame(
                            new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                            Settings.DelveSpecialChestLabelBorderSize, Settings.DelveSpecialChestLabelBorderColor);
                        Graphics.DrawText(textToDisplay, Settings.DelveSpecialChestLabelSize, screenPosition,
                            Settings.DelveSpecialChestLabelTextColor, FontDrawFlags.Center);
                    }

                    #endregion

                    //debug portion

                    #region Debug

                    else
                    {
                        if (!Settings.Enable && !DelveIsAzuriteMine) return;

                        var mineMap = GameController.Game.IngameState.IngameUi.MineMap;
                        if (Settings.DelveMineMapConnections.Value)
                            DrawMineMapConnections(mineMap);

                        if (!mineMap.IsVisible)
                            RenderMapImages();


                        if (Settings.DebugHotkey.PressedOnce())
                            Settings.DebugMode.Value = !Settings.DebugMode.Value;

                        if (Settings.DebugMode.Value)
                        {
                            if (entity.Path.StartsWith("Metadata/Terrain/Leagues/Delve/Objects/DelveWall") ||
                                entity.Path.StartsWith("Metadata/Terrain/Leagues/Delve/Objects/DelveLight"))
                                continue;

                            if (Settings.ShouldHideOnOpen.Value && entity.GetComponent<Chest>().IsOpened)
                                continue;

                            var textToDisplay = "";

                            var stringifyReturn = StringNicer.GetCoolStrings(entity.Path);

                            switch (Settings.NiceString.Value)
                            {
                                case true:
                                    textToDisplay = stringifyReturn.IsFound
                                        ? stringifyReturn.NiceString
                                        : stringifyReturn.UglyString.Split('/').Last();
                                    break;
                                case false:
                                    textToDisplay = stringifyReturn.UglyString.Split('/').Last();
                                    break;
                            }

                            var textBox =
                                Graphics.MeasureText(textToDisplay, 20,
                                    FontDrawFlags
                                        .Center); // NEEDED FONT SIZE AS INPUT TO MEASURE  -- Debug never had this
                            var screenPosition =
                                GameController.Game.IngameState.Camera.WorldToScreen(entity.Pos, entity);

                            Graphics.DrawBox(
                                new RectangleF(screenPosition.X - textBox.Width / 2 - 10,
                                    screenPosition.Y - textBox.Height / 2, textBox.Width + 20, textBox.Height * 2),
                                Color.White);

                            Graphics.DrawText(textToDisplay, 20, screenPosition, Color.Black, FontDrawFlags.Center);
                        }
                    }
                            #endregion
                }
            }
        }
        #endregion

        #region Not Render
        private void AreaChange(AreaController area)
        {
            _delveEntities.Clear();
            _areaName = area.CurrentArea.Name;
        }

        private void _drawData(string icon, string data)
        {
            var textSize = Graphics.MeasureText(data, 20, FontDrawFlags.Left | FontDrawFlags.VerticalCenter);

            _drawRect.Width = _drawRect.Height + textSize.Width + 10;

            Graphics.DrawBox(_drawRect, Color.Black);

            var imgRect = _drawRect;
            imgRect.Width = imgRect.Height;
            Graphics.DrawPluginImage(Path.Combine(PluginDirectory, icon), imgRect);
            Graphics.DrawFrame(_drawRect, 2, Color.Gray);

            var textPos = _drawRect.TopLeft;
            textPos.Y += _drawRect.Height / 2;
            textPos.X += _drawRect.Height + 3;

            Graphics.DrawText(data, 20, textPos, FontDrawFlags.Left | FontDrawFlags.VerticalCenter);



            _drawRect.X += _drawRect.Width + 1;
        }

        public class LargeMapData
        {
            public Camera @Camera { get; set; }
            public PoeHUD.Poe.Elements.Map @MapWindow { get; set; }
            public RectangleF @MapRec { get; set; }
            public Vector2 @PlayerPos { get; set; }
            public float @PlayerPosZ { get; set; }
            public Vector2 @ScreenCenter { get; set; }
            public float @Diag { get; set; }
            public float @K { get; set; }
            public float @Scale { get; set; }

            public LargeMapData(GameController gc)
            {
                @Camera = gc.Game.IngameState.Camera;
                @MapWindow = gc.Game.IngameState.IngameUi.Map;
                @MapRec = @MapWindow.GetClientRect();
                @PlayerPos = gc.Player.GetComponent<Positioned>().GridPos;
                @PlayerPosZ = gc.Player.GetComponent<Render>().Z;
                @ScreenCenter = new Vector2(@MapRec.Width / 2, @MapRec.Height / 2).Translate(0, -20)
                                   + new Vector2(@MapRec.X, @MapRec.Y)
                                   + new Vector2(@MapWindow.LargeMapShiftX, @MapWindow.LargeMapShiftY);
                @Diag = (float)Math.Sqrt(@Camera.Width * @Camera.Width + @Camera.Height * @Camera.Height);
                @K = @Camera.Width < 1024f ? 1120f : 1024f;
                @Scale = @K / @Camera.Height * @Camera.Width * 3f / 4f / @MapWindow.LargeMapZoom;
            }
        }

        private void DrawToLargeMiniMap(EntityWrapper entity)
        {
            var icon = GetMapIcon(entity);
            if (icon == null)
            {
                return;
            }

            var iconZ = icon.EntityWrapper.GetComponent<Render>().Z;
            var point = LargeMapInformation.ScreenCenter
                        + MapIcon.DeltaInWorldToMinimapDelta(icon.WorldPosition - LargeMapInformation.PlayerPos,
                            LargeMapInformation.Diag, LargeMapInformation.Scale,
                            (iconZ - LargeMapInformation.PlayerPosZ) /
                            (9f / LargeMapInformation.MapWindow.LargeMapZoom));

            var texture = icon.TextureIcon;
            var size = icon.Size * 2; // icon.SizeOfLargeIcon.GetValueOrDefault(icon.Size * 2);
            texture.DrawPluginImage(Graphics, new RectangleF(point.X - size / 2f, point.Y - size / 2f, size, size));
        }

        private void DrawToSmallMiniMap(EntityWrapper entity)
        {
            var icon = GetMapIcon(entity);
            if (icon == null)
            {
                return;
            }

            var smallMinimap = GameController.Game.IngameState.IngameUi.Map.SmallMinimap;
            var playerPos = GameController.Player.GetComponent<Positioned>().GridPos;
            var posZ = GameController.Player.GetComponent<Render>().Z;
            const float scale = 240f;
            var mapRect = smallMinimap.GetClientRect();
            var mapCenter = new Vector2(mapRect.X + mapRect.Width / 2, mapRect.Y + mapRect.Height / 2).Translate(0, 0);
            var diag = Math.Sqrt(mapRect.Width * mapRect.Width + mapRect.Height * mapRect.Height) / 2.0;
            var iconZ = icon.EntityWrapper.GetComponent<Render>().Z;
            var point = mapCenter + MapIcon.DeltaInWorldToMinimapDelta(icon.WorldPosition - playerPos, diag, scale, (iconZ - posZ) / 20);
            var texture = icon.TextureIcon;
            var size = icon.Size;
            var rect = new RectangleF(point.X - size / 2f, point.Y - size / 2f, size, size);
            mapRect.Contains(ref rect, out var isContain);
            if (isContain)
            {
                texture.DrawPluginImage(Graphics, rect);
            }
        }

        //****NEEDS REFRACTORING**** 
        private MapIcon GetMapIcon(EntityWrapper e)
        {
            if (Settings.DelvePathWays)
            {
                if (e.Path.StartsWith("Metadata/Terrain/Leagues/Delve/Objects/DelveLight"))
                {
                    return new MapIcon(e, new HudTexture(CustomImagePath + "abyss-crack.png", Settings.DelvePathWaysNodeColor), () => true,
                            Settings.DelvePathWaysNodeSize);
                }
            }

            if (Settings.DelveChests)
            {
                if (!e.GetComponent<Chest>().IsOpened)
                {
                    if (e.Path.EndsWith("Encounter"))
                    {
                        return null;
                    }
                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveMiningSuppliesDynamite"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Bombs.png", Settings.DelveMiningSuppliesDynamiteChestColor),
                            () => Settings.DelveMiningSuppliesDynamiteChest, Settings.DelveMiningSuppliesDynamiteChestSize);
                    }
                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DynamiteGeneric")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DynamiteArmour")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DynamiteWeapon")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DynamiteTrinkets"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Bombs.png", Settings.DelveMiningSuppliesDynamiteChestColor),
                            () => Settings.DelveMiningSuppliesDynamiteChest, Settings.DelveMiningSuppliesDynamiteChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveMiningSuppliesFlares"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Flare.png", Settings.DelveMiningSuppliesFlaresChestColor),
                            () => Settings.DelveMiningSuppliesFlaresChest, Settings.DelveMiningSuppliesFlaresChestSize);
                    }


                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/OffPathCurrency")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/PathCurrency")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencySockets")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericCurrency"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Currency.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericRandomEnchant"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Enchant.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmour6LinkedUniqueBody")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeapon6LinkedTwoHanded")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourFullyLinkedBody"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "SixLink.png", Settings.DelveCurrencyTier1ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DynamiteCurrency"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Currency.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourBody2AdditionalSockets"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "AdditionalSockets.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericAtziriFragment"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Fragment.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericPaleCourtFragment"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "PaleCourtComplete.png", Settings.DelveCurrencyTier1ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericRandomEssence")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialGenericEssence"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Essence.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencySilverCoins"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "SilverCoin.png", Settings.DelveCurrencyTier3ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencyWisdomScrolls"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "WisDomCurrency.png", Settings.DelveCurrencyTier3ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericDivination")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourDivination")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponDivination")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsDivination")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencyDivination"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "divinationCard.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrency"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Currency.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveAzuriteVein"))
                    {
                        return new MapIcon(e, new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveAzuriteVeinChestColor),
                            () => Settings.DelveAzuriteVeinChest, Settings.DelveAzuriteVeinChestSize);
                    }


                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/Resonator3")
                         || e.Path.StartsWith("Metadata/Chests/DelveChests/Resonator4")
                         || e.Path.StartsWith("Metadata/Chests/DelveChests/Resonator5"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "ResonatorT1.png", Settings.DelveResonatorTier1ChestColor),
                            () => Settings.DelveResonatorTier1Chest, Settings.DelveResonatorTier1ChestSize * 0.7f);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/Resonator2"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "ResonatorT2.png", Settings.DelveResonatorTier2ChestColor),
                            () => Settings.DelveResonatorTier2Chest, Settings.DelveResonatorTier2ChestSize * 0.7f);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/Resonator1"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "ResonatorT3.png", Settings.DelveResonatorTier3ChestColor),
                            () => Settings.DelveResonatorTier3Chest, Settings.DelveResonatorTier3ChestSize * 0.7f);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourMovementSpeed"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "SpeedArmour.png", Settings.DelveCurrencyTier1ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniqueMana"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "UniqueManaFlask.png", Settings.DelveCurrencyTier1ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize * 1.3f);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericRandomEnchant"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Enchant.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }




                    if (e.Path.StartsWith("Metadata/Chests/DelveChests")
                        && (e.Path.EndsWith("FossilChest") || e.Path.EndsWith("FossilChestDynamite")))
                    {
                        foreach (var @string in FossilList.T1)
                        {
                            if (e.Path.ToLower().Contains(@string.ToLower()))
                            {
                                return new MapIcon(e, new HudTexture(CustomImagePath + "AbberantFossilT1.png", Settings.DelveFossilTier2ChestColor),
                                    () => Settings.DelveFossilTier1Chest, Settings.DelveFossilTier1ChestSize);
                            }
                        }
                        foreach (var @string in FossilList.T2)
                        {
                            if (e.Path.ToLower().Contains(@string.ToLower()))
                            {
                                return new MapIcon(e, new HudTexture(CustomImagePath + "AbberantFossilT2.png", Settings.DelveFossilTier2ChestColor),
                                    () => Settings.DelveFossilTier2Chest, Settings.DelveFossilTier2ChestSize);
                            }
                        }
                        foreach (var @string in FossilList.T3)
                        {
                            if (e.Path.ToLower().Contains(@string.ToLower()))
                            {
                                return new MapIcon(e, new HudTexture(CustomImagePath + "AbberantFossilT3.png", Settings.DelveFossilTier3ChestColor),
                                    () => Settings.DelveFossilTier3Chest, Settings.DelveFossilTier3ChestSize);
                            }
                        }


                        return new MapIcon(e, new HudTexture(CustomImagePath + "AbberantFossil.png", Settings.DelveFossilTier3ChestColor),
                            () => Settings.DelveFossilTier3Chest, Settings.DelveFossilTier3ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityProtoVaalResonator")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/Resonator"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "ResonatorT1.png", Settings.DelveResonatorTier1ChestColor),
                            () => Settings.DelveResonatorTier1Chest, Settings.DelveResonatorTier1ChestSize * 0.7f);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencyMaps")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestMap"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Map.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourCorrupted")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencyVaal")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponCorrupted")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsCorrupted")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityVaalDoubleCorrupted"))
                    {
                        return new MapIcon(e, new HudTexture(CustomImagePath + "Corrupted.png", Settings.DelveCurrencyTier2ChestColor),
                            () => Settings.DelveCurrencyTier1Chest, Settings.DelveCurrencyTier1ChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Terrain/Leagues/Delve/Objects/DelveWall"))
                    {

                        switch (e.IsAlive)
                        {
                            case false:
                                return new MapIcon(e, new HudTexture(CustomImagePath + "hidden_door.png", Settings.DelveWallColor),
                                    () => Settings.DelveWall, Settings.DelveWallSize);
                            case true:
                                return new MapIcon(e, new HudTexture(CustomImagePath + "gate.png", Settings.DelveWallColor),
                                    () => Settings.DelveWall, Settings.DelveWallSize);
                        }
                    }

                    //To Do CHest Icons
                    #region Chest Icons Todo
                    // TODO: Add useful icons to these

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/PathGeneric")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/OffPathGeneric"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/PathArmour")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/OffPathArmour"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/PathWeapon")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/OffPathWeapon"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/PathTrinkets")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/OffPathTrinkets")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericTrinkets")
                        )
                    {
                        return new MapIcon(e,
                            new HudTexture(CustomImagePath + "rare-amulet.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/ProsperoChest"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericAdditionalUniques")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourMultipleUnique")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponMultipleUnique")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsMultipleUnique"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericAdditionalUnique")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsUnique")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourUnique")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponUnique")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniquePhysical")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniqueFire")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniqueCold")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniqueLightning")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniqueChaos")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialUniqueMana")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityAbyssUnique")
                    )
                    {
                        return new MapIcon(e,
                        new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                        () => true,
                        Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericProphecyItem"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericElderItem")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsElder")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourElder")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponElder"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericShaperItem")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponShaper")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsShaper")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourShaper"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericOffering"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericDelveUnique"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueOnslaught"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueAnarchy"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueAmbushInvasion"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueDomination"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueNemesis"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueRampage"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueBeyond"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueBloodlines"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueTorment"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueWarbands"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueTempest"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueTalisman"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeaguePerandus"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueBreach"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueHarbinger"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueAbyss"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueBestiary"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGenericLeagueIncursion"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourMultipleResists"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourLife"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourAtlas"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmourOfCrafting")
                        || e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsOfCrafting"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponPhysicalDamage"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponCaster"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponExtraQuality"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponCannotRollCaster"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeaponCannotRollAttacker"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeapon30QualityUnique"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsAmulet"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsRing"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsJewel"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsAtlas"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinketsEyesOfTheGreatwolf"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGemGCP"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGemHighQuality"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGemHighLevel"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGemHighLevelQuality"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGemLevel4Special"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCurrencyHighShards"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveCurrencyTier1ChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestMapChisels"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestMapCorrupted"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestAssortedFossils"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialArmourMinion"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsMinion"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecialGenericMinion"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityVaalImplicit"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityVaalAtzoatlRare"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityVaalUberAtziri"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityVaalDoubleCorrupted"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityAbyssStygian"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityAbyssJewels"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityAbyssHighJewel"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityProtoVaalAzurite"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityProtoVaalFossils"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestCityProtoVaalEmblem"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestSpecial"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGem"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestTrinkets"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestWeapon"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestArmour"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    if (e.Path.StartsWith("Metadata/Chests/DelveChests/DelveChestGeneric"))
                    {
                        return new MapIcon(e,
                            new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                            () => true,
                            Settings.DelveOnPathwayChestSize);
                    }

                    // catch missing delve chests
                    if (Settings.DelveOnPathwayChest)
                    {
                        if (e.Path.StartsWith("Metadata/Chests/DelveChests") && !e.Path.Contains("Encounter"))
                        {
                            return new MapIcon(e,
                                new HudTexture(PoeHudImageLocation + "strongbox.png", Settings.DelveOnPathwayChestColor),
                                () => true,
                                Settings.DelveOnPathwayChestSize);
                        }
                    }
                    #endregion
                }

            }

            return null;
        }

        public override void EntityAdded(EntityWrapper entityWrapper)
        {
            if (!DelveIsAzuriteMine)
                return;

            if (entityWrapper.Path.StartsWith("Metadata/Chests/DelveChests/")
                || entityWrapper.Path.StartsWith("Metadata/Terrain/Leagues/Delve/Objects/DelveWall")
                || entityWrapper.Path.StartsWith("Metadata/Terrain/Leagues/Delve/Objects/DelveLight")
            )
            {
                _delveEntities.Add(entityWrapper);
            }
        }
        public override void EntityRemoved(EntityWrapper entityWrapper)
        {
            if (!DelveIsAzuriteMine)
                return;

            if (_delveEntities.Contains(entityWrapper))
            {
                _delveEntities.Remove(entityWrapper);
            }
        }

        public class FossilTiers
        {
            [JsonProperty("t1")]
            public string[] T1 { get; set; }

            [JsonProperty("t2")]
            public string[] T2 { get; set; }

            [JsonProperty("t3")]
            public string[] T3 { get; set; }
        }

        //Added for new json file properties definition class
        public partial class ContainersTires
        {
            [JsonProperty("DelveOnPath")]
            public List<string> DelveOnPath { get; set; }

            [JsonProperty("DelveOffPath")]
            public List<string> DelveOffPath { get; set; }

            [JsonProperty("DelveMiningSupplies")]
            public List<string> DelveMiningSupplies { get; set; }

            [JsonProperty("DelveMiningSuppliesDynamite")]
            public List<string> DelveMiningSuppliesDynamite { get; set; }

            [JsonProperty("DelveMiningSuppliesFlares")]
            public List<string> DelveMiningSuppliesFlares { get; set; }

            [JsonProperty("DelveAzurite")]
            public List<string> DelveAzurite { get; set; }

            [JsonProperty("DelveCurrencyTier1")]
            public List<string> DelveCurrencyTier1 { get; set; }

            [JsonProperty("DelveCurrencyTier2")]
            public List<string> DelveCurrencyTier2 { get; set; }

            [JsonProperty("DelveCurrencyTier3")]
            public List<string> DelveCurrencyTier3 { get; set; }

            [JsonProperty("DelveResonatorTier1")]
            public List<string> DelveResonatorTier1 { get; set; }

            [JsonProperty("DelveResonatorTier2")]
            public List<string> DelveResonatorTier2 { get; set; }

            [JsonProperty("DelveResonatorTier3")]
            public List<string> DelveResonatorTier3 { get; set; }

            [JsonProperty("DelveFossilTier1")]
            public List<string> DelveFossilTier1 { get; set; }

            [JsonProperty("DelveFossilTier2")]
            public List<string> DelveFossilTier2 { get; set; }

            [JsonProperty("DelveFossilTier3")]
            public List<string> DelveFossilTier3 { get; set; }

            [JsonProperty("DelveGenericChest")]
            public List<string> DelveGenericChest { get; set; }

            [JsonProperty("DelveArmourChest")]
            public List<string> DelveArmourChest { get; set; }

            [JsonProperty("DelveWeaponChest")]
            public List<string> DelveWeaponChest { get; set; }

            [JsonProperty("DelveTrinketChest")]
            public List<string> DelveTrinketChest { get; set; }

            [JsonProperty("DelveGemChest")]
            public List<string> DelveGemChest { get; set; }

            [JsonProperty("DelveVaalChest")]
            public List<string> DelveVaalChest { get; set; }

            [JsonProperty("DelveAbyssalChest")]
            public List<string> DelveAbyssalChest { get; set; }

            [JsonProperty("DelveDynamiteChest")]
            public List<string> DelveDynamiteChest { get; set; }

            [JsonProperty("DelveLegacyLeagueChest")]
            public List<string> DelveLegacyLeagueChest { get; set; }

            [JsonProperty("DelveMapChest")]
            public List<string> DelveMapChest { get; set; }

            [JsonProperty("DelveFragmentChest")]
            public List<string> DelveFragmentChest { get; set; }

            [JsonProperty("DelveSpecialChest")]
            public List<string> DelveSpecialChest { get; set; }
        }

        private void RenderMapImages()
        {
            if (GameController.Game.IngameState.IngameUi.Map.LargeMap.IsVisible)
            {
                LargeMapInformation = new LargeMapData(GameController);
                foreach (var entity in _delveEntities.ToArray())
                {
                    if (entity is null) continue;
                    DrawToLargeMiniMap(entity);
                }
            }
            else if (GameController.Game.IngameState.IngameUi.Map.SmallMinimap.IsVisible)
            {
                foreach (var entity in _delveEntities.ToArray())
                {
                    if (entity is null) continue;
                    DrawToSmallMiniMap(entity);
                }
            }
        }

        private void DrawMineMapConnections(SubterraneanChart mineMap)
        {
            if (!mineMap.IsVisible)
                return;

            RectangleF connectionArea = RectangleF.Empty;
            RectangleF mineMapArea = mineMap.GetClientRect();
            float reducedWidth = ((100 - Settings.ShowRadiusPercentage.Value) * mineMapArea.Width) / 200;
            float reduceHeight = ((100 - Settings.ShowRadiusPercentage.Value) * mineMapArea.Height) / 200;
            mineMapArea.Inflate(0 - reducedWidth, 0 - reduceHeight);
            foreach (var zone in mineMap.GridElement.Children)
            {
                foreach (var block in zone.Children)
                {
                    foreach (var connection in block.Children)
                    {
                        var width = (int)connection.Width;
                        if ((width == 10 || width == 4) && mineMapArea.Intersects(connection.GetClientRect()))
                            Graphics.DrawFrame(connection.GetClientRect(), 1, Color.Yellow);
                    }
                }
            }
        } 
        #endregion
    }
}