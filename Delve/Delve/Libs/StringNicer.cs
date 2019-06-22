using System.Collections.Generic;

namespace Delve.Libs
{
    public class StringNicer
    {
        public static Dictionary<string, string> ChestList = new Dictionary<string, string>();


        public static Stringify GetCoolStrings(string inputstring)
        {
            return new Stringify(inputstring);
        }

        public class Stringify
        {
            public string NiceString { get; set; }
            public string UglyString { get; set; }
            public bool IsFound { get; set; }

            public Stringify(string inputString)
            {
                if (ChestList.TryGetValue(inputString, out string outPutValue))
                {
                    // use myValue;
                    NiceString = outPutValue;
                    UglyString = inputString;
                    IsFound = true;
                }
                else
                {
                    // use myValue, still in scope, null if not found
                    NiceString = outPutValue;
                    UglyString = inputString;
                    IsFound = false;
                }
            }
        }
        
        public static void InitList()
        {
            ChestList.Add("Metadata/Chests/DelveChests/AberrantFossilChest", "Aberrant Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/AethericFossilChest", "Aetheric Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/AethericFossilChestDynamite", "Aetheric Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/BloodstainedFossilChest", "Bloodstained Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/BoundFossilChest", "Bound Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/BoundFossilChestDynamite", "Bound Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/ClothMajorSpider", "Strange Webbing");
            ChestList.Add("Metadata/Chests/DelveChests/CorrodedFossilChest", "Corroded Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/CorrodedFossilChestDynamite", "Corroded Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteChest1_1", "Flawed Azurite Chest");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteChest1_2", "Azurite Chest");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteChest1_3", "Rich Azurite Chest");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteChest2_1", "Pure Azurite Chest");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteVein1_1", "Flawed Azurite Vein");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteVein1_2", "Azurite Vein");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteVein1_3", "Rich Azurite Vein");
            ChestList.Add("Metadata/Chests/DelveChests/DelveAzuriteVein2_1", "Pure Azurite Vein");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmour1", "Abandoned Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmour2", "Abandoned Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmour3", "Abandoned Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmour6LinkedUniqueBody", "Exceptional Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourAtlas", "Unusual Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourBody2AdditionalSockets", "Pocked Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourCorrupted", "Twisted Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourDivination", "Abandoned Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourElder", "Eldritch Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourExtraQuality", "Superior Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourFullyLinkedBody", "Abandoned Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourLife", "Vital Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourMovementSpeed", "Traveller's Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourMultipleResists", "Resistant Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourMultipleUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourOfCrafting", "Flexible Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourShaper", "Astral Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestArmourUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestAssortedFossils", "Prehistoric Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityAbyssHighJewel", "Abyssal Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityAbyssJewels", "Abyssal Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityAbyssStygian", "Rattling Coffer");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityAbyssUnique", "Abyssal Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityProtoVaalAzurite", "Prehistoric Ore");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityProtoVaalEmblem", "Prehistoric Rings");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityProtoVaalFossils", "Prehistoric Fossils");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityProtoVaalResonator", "Prehistoric Resonators");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityVaalAtzoatlRare", "Handcrafted Antiques");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityVaalDoubleCorrupted", "Disturbing Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityVaalImplicit", "Bloodstained Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCityVaalUberAtziri", "Mythical Crate");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrency1", "Abandoned Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrency2", "Abandoned Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrency3", "Abandoned Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencyDivination", "Light Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencyHighShards", "Shattered Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencyMaps", "Cartographer's Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencyMaps2", "Cartographer's Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencySilverCoins", "Glimmering Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencySockets", "Pocked Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencySockets2", "Pocked Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencyVaal", "Bloodstained Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestCurrencyWisdomScrolls", "Packed Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGem1", "Abandoned Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGem2", "Abandoned Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGem3", "Abandoned Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGemGCP", "Gemcutter's Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGemHighLevel", "Ancient Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGemHighLevelQuality", "Inscribed Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGemHighQuality", "Superior Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGemLevel4Special", "Exceptional Gems");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGeneric1", "Sealed Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGeneric2", "Sealed Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGeneric3", "Sealed Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericAdditionalUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericAdditionalUniques", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericAtziriFragment", "Bloodstained Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericCurrency", "Opulent Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericDelveUnique", "Treasured Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericDivination", "Light Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericElderItem", "Eldritch Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueAbyss", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueAmbushInvasion", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueAnarchy", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueBestiary", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueBeyond", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueBloodlines", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueBreach", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueDomination", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueHarbinger", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueIncursion", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueNemesis", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueOnslaught", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeaguePerandus", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueRampage", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueTalisman", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueTempest", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueTorment", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericLeagueWarbands", "Hidden Heirlooms");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericOffering", "Clean Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericPaleCourtFragment", "Pale Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericProphecyItem", "Foreboding Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericRandomEnchant", "Enchanted Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericRandomEssence", "Murmuring Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericShaperItem", "Astral Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestGenericTrinkets", "Encrusted Lockbox");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMap1", "Abandoned Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMap2", "Abandoned Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMap3", "Abandoned Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapChisels", "Cartographer's Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapCorrupted", "Bloodstained Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapElderMap", "Eldritch Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapHorizon", "Strange Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapSextants", "Explorer's Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapShaped", "Astral Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapShaperFragment", "Puzzling Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestMapUnique", "Beautiful Charts");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourAspect", "Feral Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourChaos", "Malignant Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourCold", "Frosty Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourFire", "Smouldering Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourLightning", "Charged Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourMana", "Inspiring Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourMinion", "Grim Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialArmourPhysical", "Heavy Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericChaos", "Malignant Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericCold", "Frosty Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericEssence", "Whispering Coffer");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericFire", "Smouldering Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericLightning", "Charged Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericMana", "Inspiring Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericMinion", "Grim Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialGenericPhysical", "Heavy Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsAbyss", "Gazing Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsAbyss2", "Gazing Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsAspect", "Feral Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsChaos", "Malignant Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsCold", "Frosty Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsFire", "Smouldering Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsLightning", "Charged Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsMana", "Inspiring Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsMinion", "Grim Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsPhysical", "Heavy Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialTrinketsTalisman", "Feral Talismans");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniqueChaos", "Malignant Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniqueCold", "Frosty Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniqueFire", "Smouldering Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniqueLightning", "Charged Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniqueMana", "Inspiring Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniqueMinion", "Grim Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialUniquePhysical", "Heavy Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialWeaponChaos", "Malignant Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialWeaponCold", "Frosty Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialWeaponFire", "Smouldering Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialWeaponLightning", "Charged Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestSpecialWeaponPhysical", "Heavy Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinkets1", "Abandoned Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinkets2", "Abandoned Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinkets3", "Abandoned Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsAmulet", "Abandoned Amulets");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsAtlas", "Unusual Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsCorrupted", "Twisted Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsDivination", "Light Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsElder", "Eldritch Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsEyesOfTheGreatwolf", "Ritualistic Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsJewel", "Abandoned Jewels");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsMultipleUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsOfCrafting", "Flexible Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsRing", "Abandoned Rings");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsShaper", "Astral Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestTrinketsUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeapon1", "Abandoned Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeapon2", "Abandoned Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeapon3", "Abandoned Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeapon30QualityUnique", "Masterwork Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeapon6LinkedTwoHanded", "Exceptional Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponCannotRollAttacker", "Hexed Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponCannotRollCaster", "Honed Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponCaster", "Runed Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponCorrupted", "Twisted Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponDivination", "Light Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponElder", "Eldritch Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponExtraQuality", "Superior Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponMultipleUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponPhysicalDamage", "Heavy Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponShaper", "Astral Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/DelveChestWeaponUnique", "Hidden Treasures");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSupplies1_1", "Mining Supplies");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSupplies1_2", "Mining Supplies");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSupplies2_1", "Mining Supplies");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSuppliesDynamite", "Dynamite Cache");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSuppliesDynamite2", "Dynamite Cache");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSuppliesFlares1_1", "Flare Cache");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSuppliesFlares1_2", "Large Flare Cache");
            ChestList.Add("Metadata/Chests/DelveChests/DelveMiningSuppliesFlaresEncounter", "Flare Cache");
            ChestList.Add("Metadata/Chests/DelveChests/DenseFossilChest", "Dense Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteArmour", "Hidden Armour");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteCurrency", "Hidden Wealth");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteCurrency2", "Hidden Riches");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteCurrency3", "Hidden Opulence");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteGeneric", "Hidden Loot");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteTrinkets", "Hidden Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/DynamiteWeapon", "Hidden Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/EnchantedFossilChest", "Enchanted Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/EnchantedFossilChestDynamite", "Enchanted Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/EncrustedFossilChest", "Encrusted Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/FacetedFossilChest", "Faceted Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/FracturedFossilChest", "Fractured Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/FrigidFossilChest", "Frigid Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/GildedFossilChest", "Gilded Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/GlyphicFossilChest", "Glyphic Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/HollowFossilChest", "Hollow Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/JaggedFossilChest", "Jagged Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/LucentFossilChest", "Lucent Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/MetallicFossilChest", "Metallic Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/OffPathArmour", "Lost Armour");
            ChestList.Add("Metadata/Chests/DelveChests/OffPathCurrency", "Lost Wealth");
            ChestList.Add("Metadata/Chests/DelveChests/OffPathGeneric", "Lost Loot");
            ChestList.Add("Metadata/Chests/DelveChests/OffPathTrinkets", "Lost Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/OffPathWeapon", "Lost Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/PathArmour", "Forgotten Armour");
            ChestList.Add("Metadata/Chests/DelveChests/PathCurrency", "Forgotten Wealth");
            ChestList.Add("Metadata/Chests/DelveChests/PathGeneric", "Forgotten Loot");
            ChestList.Add("Metadata/Chests/DelveChests/PathTrinkets", "Forgotten Jewellery");
            ChestList.Add("Metadata/Chests/DelveChests/PathWeapon", "Forgotten Armaments");
            ChestList.Add("Metadata/Chests/DelveChests/PerfectFossilChest", "Perfect Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/PerfectFossilChestDynamite", "Perfect Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/PrismaticFossilChest", "Prismatic Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/PrismaticFossilChestDynamite", "Prismatic Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/PristineFossilChest", "Pristine Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/ProsperoChest1", "Gleaming Offering");
            ChestList.Add("Metadata/Chests/DelveChests/ProsperoChest2", "Glittering Offering");
            ChestList.Add("Metadata/Chests/DelveChests/ProsperoChest3", "Gilt Offering");
            ChestList.Add("Metadata/Chests/DelveChests/ProsperoChest4", "Golden Offering");
            ChestList.Add("Metadata/Chests/DelveChests/ProsperoChest5", "Glowing Offering");
            ChestList.Add("Metadata/Chests/DelveChests/ProsperoChest6", "Grand Offering");
            ChestList.Add("Metadata/Chests/DelveChests/Resonator1", "Resonator Stash");
            ChestList.Add("Metadata/Chests/DelveChests/Resonator2", "Resonator Cache");
            ChestList.Add("Metadata/Chests/DelveChests/Resonator3", "Resonator Trove");
            ChestList.Add("Metadata/Chests/DelveChests/SanctifiedFossilChest", "Sanctified Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/ScorchedFossilChest", "Scorched Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/SerratedFossilChest", "Serrated Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/SerratedFossilChestDynamite", "Serrated Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/ShudderingFossilChest", "Shuddering Fossilised Remains");
            ChestList.Add("Metadata/Chests/DelveChests/TangledFossilChest", "Tangled Fossilised Remains");
        }
    }
}