using PoeHUD.Hud.Settings;

namespace Delve
{
    public class Settings : SettingsBase
    {
        public Settings()
        {
            Enable = true;
        }

        // Delve Connection Pathways
        public ToggleNode DelvePathWays = true;
        public RangeNode<int> DelvePathWaysNodeSize = new RangeNode<int>(7, 1, 200);
        public ColorNode DelvePathWaysNodeColor = new ColorNode(0xFF8C00FF);

        public ToggleNode DelveWall { get; set; } = true;
        public RangeNode<int> DelveWallSize { get; set; } = new RangeNode<int>(18, 1, 200);
        public ColorNode DelveWallColor { get; set; } = new ColorNode(0xFFFFFFFF);

        // Delve Chests
        public ToggleNode DelveChests = true;
        public ToggleNode NiceString { get; set; } = true;


        //Delve Mining Supplies
        #region Delve Miniing Supplies
        public ToggleNode DelveMiningSuppliesChest { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMiningSuppliesChestColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public ToggleNode DelveMiningSuppliesChestLabel { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMiningSuppliesChestLabelColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public RangeNode<int> DelveMiningSuppliesChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveMiningSuppliesChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveMiningSuppliesChestLabelTextColor { get; set; } = new ColorNode(0xDAA516FF);
        #endregion
        #region Dynamite
        public ToggleNode DelveMiningSuppliesDynamiteChest { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesDynamiteChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMiningSuppliesDynamiteChestColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public ToggleNode DelveMiningSuppliesDynamiteChestLabel { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesDynamiteChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMiningSuppliesDynamiteChestLabelColor { get; set; } = new ColorNode(0xFF000060);
        public RangeNode<int> DelveMiningSuppliesDynamiteChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveMiningSuppliesDynamiteChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveMiningSuppliesDynamiteChestLabelTextColor { get; set; } = new ColorNode(0xDAA516FF);
        #endregion
        #region Flare
        public ToggleNode DelveMiningSuppliesFlaresChest { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesFlaresChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMiningSuppliesFlaresChestColor { get; set; } = new ColorNode(0xFFFB00FF);
        public ToggleNode DelveMiningSuppliesFlaresChestLabel { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesFlaresChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMiningSuppliesFlaresChestLabelColor { get; set; } = new ColorNode(0xFFFB00FF);
        public RangeNode<int> DelveMiningSuppliesFlaresChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveMiningSuppliesFlaresChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveMiningSuppliesFlaresChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion

        //Azurite Nodes
        #region Azurite
        public ToggleNode DelveAzuriteVeinChest { get; set; } = true;
        public RangeNode<int> DelveAzuriteVeinChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveAzuriteVeinChestColor { get; set; } = new ColorNode(0x0073FFFF);
        public ToggleNode DelveAzuriteVeinChestLabel { get; set; } = true;
        public RangeNode<int> DelveAzuriteVeinChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveAzuriteVeinChestLabelColor { get; set; } = new ColorNode(0x0073FFFF);
        public RangeNode<int> DelveAzuriteVeinChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveAzuriteVeinChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveAzuriteVeinChestLabelTextColor { get; set; } = new ColorNode(0xFFFFFFFF);
        #endregion

        //Resonators
        #region Resonator Tier 1
        public ToggleNode DelveResonatorTier1Chest { get; set; } = true;
        public RangeNode<int> DelveResonatorTier1ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveResonatorTier1ChestColor { get; set; } = new ColorNode(0xEF581CFF);
        public ToggleNode DelveResonatorTier1ChestLabel { get; set; } = true;
        public RangeNode<int> DelveResonatorTier1ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveResonatorTier1ChestLabelColor { get; set; } = new ColorNode(0xEF581CFF);
        public RangeNode<int> DelveResonatorTier1ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveResonatorTier1ChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveResonatorTier1ChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion
        #region Resonator Tier 2
        public ToggleNode DelveResonatorTier2Chest { get; set; } = true;
        public RangeNode<int> DelveResonatorTier2ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveResonatorTier2ChestColor { get; set; } = new ColorNode(0XF8960DFF);
        public ToggleNode DelveResonatorTier2ChestLabel { get; set; } = true;
        public RangeNode<int> DelveResonatorTier2ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveResonatorTier2ChestLabelColor { get; set; } = new ColorNode(0XF8960DFF);
        public RangeNode<int> DelveResonatorTier2ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveResonatorTier2ChestLabelBorderColor { get; set; } = new ColorNode(0X000000FF);
        public ColorNode DelveResonatorTier2ChestLabelTextColor { get; set; } = new ColorNode(0X000000FF);
        #endregion
        #region Resonator Tier 3
        public ToggleNode DelveResonatorTier3Chest { get; set; } = true;
        public RangeNode<int> DelveResonatorTier3ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveResonatorTier3ChestColor { get; set; } = new ColorNode(0xD2B286FF);
        public ToggleNode DelveResonatorTier3ChestLabel { get; set; } = true;
        public RangeNode<int> DelveResonatorTier3ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveResonatorTier3ChestLabelColor { get; set; } = new ColorNode(0xD2B286FF);
        public RangeNode<int> DelveResonatorTier3ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveResonatorTier3ChestLabelBorderColor { get; set; } = new ColorNode(0xD2B286FF);
        public ColorNode DelveResonatorTier3ChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion

        //Fossils
        #region Fossile Tier 1
        public ToggleNode DelveFossilTier1Chest { get; set; } = true;
        public RangeNode<int> DelveFossilTier1ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFossilTier1ChestColor { get; set; } = new ColorNode(0xEF581CFF);
        public ToggleNode DelveFossilTier1ChestLabel { get; set; } = true;
        public RangeNode<int> DelveFossilTier1ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFossilTier1ChestLabelColor { get; set; } = new ColorNode(0xEF581CFF);
        public RangeNode<int> DelveFossilTier1ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveFossilTier1ChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveFossilTier1ChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion      
        #region Fossile Tier 2
        public ToggleNode DelveFossilTier2Chest { get; set; } = true;
        public RangeNode<int> DelveFossilTier2ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFossilTier2ChestColor { get; set; } = new ColorNode(0XF8960DFF);
        public ToggleNode DelveFossilTier2ChestLabel { get; set; } = true;
        public RangeNode<int> DelveFossilTier2ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFossilTier2ChestLabelColor { get; set; } = new ColorNode(0XF8960DFF);
        public RangeNode<int> DelveFossilTier2ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveFossilTier2ChestLabelBorderColor { get; set; } = new ColorNode(0X000000FF);
        public ColorNode DelveFossilTier2ChestLabelTextColor { get; set; } = new ColorNode(0X000000FF);
        #endregion
        #region Fossile Tier 3
        public ToggleNode DelveFossilTier3Chest { get; set; } = true;
        public RangeNode<int> DelveFossilTier3ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFossilTier3ChestColor { get; set; } = new ColorNode(0xD2B286FF);
        public ToggleNode DelveFossilTier3ChestLabel { get; set; } = true;
        public RangeNode<int> DelveFossilTier3ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFossilTier3ChestLabelColor { get; set; } = new ColorNode(0xD2B286FF);
        public RangeNode<int> DelveFossilTier3ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveFossilTier3ChestLabelBorderColor { get; set; } = new ColorNode(0xD2B286FF);
        public ColorNode DelveFossilTier3ChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion

        //Currency
        #region Currency Tier1
        public ToggleNode DelveCurrencyTier1Chest { get; set; } = true;
        public RangeNode<int> DelveCurrencyTier1ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveCurrencyTier1ChestColor { get; set; } = new ColorNode(0xFF0000FF);
        public ToggleNode DelveCurrencyTier1ChestLabel { get; set; } = true;
        public RangeNode<int> DelveCurrencyTier1ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveCurrencyTier1ChestLabelColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public RangeNode<int> DelveCurrencyTier1ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveCurrencyTier1ChestLabelBorderColor { get; set; } = new ColorNode(0xFF0000FF);
        public ColorNode DelveCurrencyTier1ChestLabelTextColor { get; set; } = new ColorNode(0xFF0000FF);
        #endregion
        #region Currency Tier2
        public ToggleNode DelveCurrencyTier2Chest { get; set; } = true;
        public RangeNode<int> DelveCurrencyTier2ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveCurrencyTier2ChestColor { get; set; } = new ColorNode(0XF8960DFF);
        public ToggleNode DelveCurrencyTier2ChestLabel { get; set; } = true;
        public RangeNode<int> DelveCurrencyTier2ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveCurrencyTier2ChestLabelColor { get; set; } = new ColorNode(0XF8960DFF);
        public RangeNode<int> DelveCurrencyTier2ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveCurrencyTier2ChestLabelBorderColor { get; set; } = new ColorNode(0X000000FF);
        public ColorNode DelveCurrencyTier2ChestLabelTextColor { get; set; } = new ColorNode(0X000000FF);
        #endregion
        #region Currency Tier3
        public ToggleNode DelveCurrencyTier3Chest { get; set; } = true;
        public RangeNode<int> DelveCurrencyTier3ChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveCurrencyTier3ChestColor { get; set; } = new ColorNode(0xD2B286FF);
        public ToggleNode DelveCurrencyTier3ChestLabel { get; set; } = true;
        public RangeNode<int> DelveCurrencyTier3ChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveCurrencyTier3ChestLabelColor { get; set; } = new ColorNode(0xD2B286FF);
        public RangeNode<int> DelveCurrencyTier3ChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveCurrencyTier3ChestLabelBorderColor { get; set; } = new ColorNode(0xD2B286FF);
        public ColorNode DelveCurrencyTier3ChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion

        //On/Off Path Chest
        #region On The Path Chest
        public ToggleNode DelveOnPathwayChest { get; set; } = true;
        public RangeNode<int> DelveOnPathwayChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveOnPathwayChestColor { get; set; } = new ColorNode(0x00830040); 
        public ToggleNode DelveOnPathwayChestLabel { get; set; } = true;
        public RangeNode<int> DelveOnPathwayChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveOnPathwayChestLabelColor { get; set; } = new ColorNode(0x00830040); 
        public RangeNode<int> DelveOnPathwayChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveOnPathwayChestLabelBorderColor { get; set; } = new ColorNode(0xFEFE76FF); 
        public ColorNode DelveOnPathwayChestLabelTextColor { get; set; } = new ColorNode(0xFEFE76FF); 
        #endregion
        #region OFF The Path Chest
        public ToggleNode DelveOffPathwayChest { get; set; } = true;
        public RangeNode<int> DelveOffPathwayChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveOffPathwayChestColor { get; set; } = new ColorNode(0x008300FF);
        public ToggleNode DelveOffPathwayChestLabel { get; set; } = true;
        public RangeNode<int> DelveOffPathwayChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveOffPathwayChestLabelColor { get; set; } = new ColorNode(0x008300FF);
        public RangeNode<int> DelveOffPathwayChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveOffPathwayChestLabelBorderColor { get; set; } = new ColorNode(0xFEFE76FF);
        public ColorNode DelveOffPathwayChestLabelTextColor { get; set; } = new ColorNode(0xFEFE76FF);
        #endregion

        //DelveGenericChest
        #region Delve Generic Chest
        public ToggleNode DelveGenericChest { get; set; } = true;
        public RangeNode<int> DelveGenericChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveGenericChestColor { get; set; } = new ColorNode(0x008300FF);
        public ToggleNode DelveGenericChestLabel { get; set; } = true;
        public RangeNode<int> DelveGenericChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveGenericChestLabelColor { get; set; } = new ColorNode(0x008300FF);
        public RangeNode<int> DelveGenericChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveGenericChestLabelBorderColor { get; set; } = new ColorNode(0xFEFE76FF);
        public ColorNode DelveGenericChestLabelTextColor { get; set; } = new ColorNode(0xFEFE76FF);
        #endregion

        //DelveArmourChest
        #region Delve Armour Chest
        public ToggleNode DelveArmourChest { get; set; } = true;
        public RangeNode<int> DelveArmourChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveArmourChestColor { get; set; } = new ColorNode(0x008300FF);
        public ToggleNode DelveArmourChestLabel { get; set; } = true;
        public RangeNode<int> DelveArmourChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveArmourChestLabelColor { get; set; } = new ColorNode(0x008300FF);
        public RangeNode<int> DelveArmourChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveArmourChestLabelBorderColor { get; set; } = new ColorNode(0xFEFE76FF);
        public ColorNode DelveArmourChestLabelTextColor { get; set; } = new ColorNode(0xFEFE76FF);
        #endregion

        //DelveWeaponChest
        #region Delve Weapon Chest
        public ToggleNode DelveWeaponChest { get; set; } = true;
        public RangeNode<int> DelveWeaponChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveWeaponChestColor { get; set; } = new ColorNode(0x008300FF);
        public ToggleNode DelveWeaponChestLabel { get; set; } = true;
        public RangeNode<int> DelveWeaponChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveWeaponChestLabelColor { get; set; } = new ColorNode(0x008300FF);
        public RangeNode<int> DelveWeaponChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveWeaponChestLabelBorderColor { get; set; } = new ColorNode(0xFEFE76FF);
        public ColorNode DelveWeaponChestLabelTextColor { get; set; } = new ColorNode(0xFEFE76FF);
        #endregion

        //DelveTrinketChest
        #region Delve Trinket Chest
        public ToggleNode DelveTrinketChest { get; set; } = true;
        public RangeNode<int> DelveTrinketChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveTrinketChestColor { get; set; } = new ColorNode(0x008300FF);
        public ToggleNode DelveTrinketChestLabel { get; set; } = true;
        public RangeNode<int> DelveTrinketChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveTrinketChestLabelColor { get; set; } = new ColorNode(0xFEFE76FF);
        public RangeNode<int> DelveTrinketChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveTrinketChestLabelBorderColor { get; set; } = new ColorNode(0xFEFE76FF);
        public ColorNode DelveTrinketChestLabelTextColor { get; set; } = new ColorNode(0xFEFE76FF);
        #endregion

        //DelveGemChest
        #region Delve Gem Chest
        public ToggleNode DelveGemChest { get; set; } = true;
        public RangeNode<int> DelveGemChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveGemChestColor { get; set; } = new ColorNode(0x00EFE76F);
        public ToggleNode DelveGemChestLabel { get; set; } = true;
        public RangeNode<int> DelveGemChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveGemChestLabelColor { get; set; } = new ColorNode(0x04046DFF);
        public RangeNode<int> DelveGemChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveGemChestLabelBorderColor { get; set; } = new ColorNode(0x00EFE76F);
        public ColorNode DelveGemChestLabelTextColor { get; set; } = new ColorNode(0x00EFE76F);
        #endregion

        //DelveVaalChest
        #region Delve Vaal Chest
        public ToggleNode DelveVaalChest { get; set; } = true;
        public RangeNode<int> DelveVaalChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveVaalChestColor { get; set; } = new ColorNode(0x9F00D5FF);
        public ToggleNode DelveVaalChestLabel { get; set; } = true;
        public RangeNode<int> DelveVaalChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveVaalChestLabelColor { get; set; } = new ColorNode(0x9F00D5FF);
        public RangeNode<int> DelveVaalChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveVaalChestLabelBorderColor { get; set; } = new ColorNode(0x000000FF);
        public ColorNode DelveVaalChestLabelTextColor { get; set; } = new ColorNode(0x000000FF);
        #endregion

        //DelveAbyssalChest
        #region Delve Abyssal Chest
        public ToggleNode DelveAbyssalChest { get; set; } = true;
        public RangeNode<int> DelveAbyssalChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveAbyssalChestColor { get; set; } = new ColorNode(0x00FF00FF);
        public ToggleNode DelveAbyssalChestLabel { get; set; } = true;
        public RangeNode<int> DelveAbyssalChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveAbyssalChestLabelColor { get; set; } = new ColorNode(0x00000FF);
        public RangeNode<int> DelveAbyssalChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveAbyssalChestLabelBorderColor { get; set; } = new ColorNode(0x00FF00FF);
        public ColorNode DelveAbyssalChestLabelTextColor { get; set; } = new ColorNode(0x00FF00FF);
        #endregion

        //DelveDynamiteChest
        #region Delve Dynamite Chest
        public ToggleNode DelveDynamiteChest { get; set; } = true;
        public RangeNode<int> DelveDynamiteChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveDynamiteChestColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public ToggleNode DelveDynamiteChestLabel { get; set; } = true;
        public RangeNode<int> DelveDynamiteChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveDynamiteChestLabelColor { get; set; } = new ColorNode(0x00830040);
        public RangeNode<int> DelveDynamiteChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveDynamiteChestLabelBorderColor { get; set; } = new ColorNode(0xFF0000FF);
        public ColorNode DelveDynamiteChestLabelTextColor { get; set; } = new ColorNode(0xFF0000FF);
        #endregion

        //Delve Legacy League Chest
        #region Delve Legacy League Chest
        public ToggleNode DelveLegacyLeagueChest { get; set; } = true;
        public RangeNode<int> DelveLegacyLeagueChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveLegacyLeagueChestColor { get; set; } = new ColorNode(0xFF0000FF);
        public ToggleNode DelveLegacyLeagueChestLabel { get; set; } = true;
        public RangeNode<int> DelveLegacyLeagueChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveLegacyLeagueChestLabelColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public RangeNode<int> DelveLegacyLeagueChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveLegacyLeagueChestLabelBorderColor { get; set; } = new ColorNode(0xFF0000FF);
        public ColorNode DelveLegacyLeagueChestLabelTextColor { get; set; } = new ColorNode(0xFF0000FF);
        #endregion

        //Delve Map Chest
        #region Delve Map Chest
        public ToggleNode DelveMapChest { get; set; } = true;
        public RangeNode<int> DelveMapChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMapChestColor { get; set; } = new ColorNode(0xFFFB00FF);
        public ToggleNode DelveMapChestLabel { get; set; } = true;
        public RangeNode<int> DelveMapChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveMapChestLabelColor { get; set; } = new ColorNode(0x00000060);
        public RangeNode<int> DelveMapChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveMapChestLabelBorderColor { get; set; } = new ColorNode(0xFFFB00FF);
        public ColorNode DelveMapChestLabelTextColor { get; set; } = new ColorNode(0xFFFB00FF);
        #endregion

        //DelveFragmentChest
        #region Delve Fragment Chest
        public ToggleNode DelveFragmentChest { get; set; } = true;
        public RangeNode<int> DelveFragmentChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFragmentChestColor { get; set; } = new ColorNode(0x9F00D5FF);
        public ToggleNode DelveFragmentChestLabel { get; set; } = true;
        public RangeNode<int> DelveFragmentChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveFragmentChestLabelColor { get; set; } = new ColorNode(0x9F00D5FF);
        public RangeNode<int> DelveFragmentChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveFragmentChestLabelBorderColor { get; set; } = new ColorNode(0x00000FF);
        public ColorNode DelveFragmentChestLabelTextColor { get; set; } = new ColorNode(0x00000FF);
        #endregion

        //DelveSpecialChest
        #region Delve Special Chest
        public ToggleNode DelveSpecialChest { get; set; } = true;
        public RangeNode<int> DelveSpecialChestSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveSpecialChestColor { get; set; } = new ColorNode(0xFF0000FF);
        public ToggleNode DelveSpecialChestLabel { get; set; } = true;
        public RangeNode<int> DelveSpecialChestLabelSize { get; set; } = new RangeNode<int>(35, 1, 100);
        public ColorNode DelveSpecialChestLabelColor { get; set; } = new ColorNode(0xFFFFFFFF);
        public RangeNode<int> DelveSpecialChestLabelBorderSize { get; set; } = new RangeNode<int>(2, 1, 50);
        public ColorNode DelveSpecialChestLabelBorderColor { get; set; } = new ColorNode(0xFF0000FF);
        public ColorNode DelveSpecialChestLabelTextColor { get; set; } = new ColorNode(0xFF0000FF);
        #endregion

        // Delve Mine Map Connections
        public ToggleNode DelveMineMapConnections { get; set; } = true;
        public RangeNode<int> ShowRadiusPercentage { get; set; } = new RangeNode<int>(80, 0, 100);

        //Debug
        public ToggleNode DebugMode { get; set; } = false;
        public ToggleNode ShouldHideOnOpen { get; set; } = false;
        public HotkeyNode DebugHotkey { get; set; } = new HotkeyNode(System.Windows.Forms.Keys.Menu);
    }
}
