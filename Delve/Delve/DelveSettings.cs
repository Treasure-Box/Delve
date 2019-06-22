using PoeHUD.Hud.Settings;
using SharpDX;

namespace Delve
{
	public class DelveSettings : SettingsBase
	{
		public DelveSettings()
		{
			Enable = true;
		}

		// Delve Pathways
		public ToggleNode DelvePathWays = true;
		public RangeNode<int> DelvePathWaysNodeSize = new RangeNode<int>(7, 1, 200);
		public ColorBGRA DelvePathWaysNodeColor = new ColorBGRA(255, 140, 0, 255);

		public ToggleNode DelveWall { get; set; } = true;
		public RangeNode<int> DelveWallSize { get; set; } = new RangeNode<int>(18, 1, 200);
		public ColorNode DelveWallColor { get; set; } = new ColorBGRA(255, 255, 255, 255);

		// Delve Chests
		public ToggleNode DelveChests = true;
        public ToggleNode NiceString { get; set; } = true;

        #region On The Way
        public ToggleNode DelvePathwayChest { get; set; } = true;
        public RangeNode<int> DelvePathwayChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelvePathwayChestColor { get; set; } = new ColorBGRA(0, 131, 0, 255);
        public ToggleNode DelvePathwayVeinChestLabel { get; set; } = true;
        public ColorNode DelvePathwayChestLabelColor { get; set; } = new ColorBGRA(0, 131, 0, 255);
        public ColorNode DelvePathwayChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);

        #endregion

        #region Dynamite
        public ToggleNode DelveMiningSuppliesDynamiteChest { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesDynamiteChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelveMiningSuppliesDynamiteChestColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ToggleNode DelveMiningSuppliesDynamiteChestLabel { get; set; } = true;
        public ColorNode DelveMiningSuppliesDynamiteChestLabelColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ColorNode DelveMiningSuppliesDynamiteChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        #endregion

        #region Flare
        public ToggleNode DelveMiningSuppliesFlaresChest { get; set; } = true;
        public RangeNode<int> DelveMiningSuppliesFlaresChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelveMiningSuppliesFlaresChestColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ToggleNode DelveMiningSuppliesFlaresChestLabel { get; set; } = true;
        public ColorNode DelveMiningSuppliesFlaresChestLabelColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ColorNode DelveMiningSuppliesFlaresChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        #endregion

        #region Currency
        public ToggleNode DelveCurrencyChest { get; set; } = true;
        public RangeNode<int> DelveCurrencyChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelveCurrencyChestColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ToggleNode DelveCurrencyChestLabel { get; set; } = true;
        public ColorNode DelveCurrencyChestLabelColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ColorNode DelveCurrencyChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        #endregion

        #region Azurite
        public ToggleNode DelveAzuriteVeinChest { get; set; } = true;
        public RangeNode<int> DelveAzuriteVeinChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelveAzuriteVeinChestColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        public ToggleNode DelveAzuriteVeinChestLabel { get; set; } = true;
        public ColorNode DelveAzuriteVeinChestLabelColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        public ColorNode DelveAzuriteVeinChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        #endregion

        #region Resonator
        public ToggleNode DelveResonatorChest { get; set; } = true;
        public RangeNode<int> DelveResonatorChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelveResonatorChestColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ToggleNode DelveResonatorChestLabel { get; set; } = true;
        public ColorNode DelveResonatorChestLabelColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ColorNode DelveResonatorChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        #endregion

        #region Fossile
        public ToggleNode DelveFossilChest { get; set; } = true;
        public RangeNode<int> DelveFossilChestSize { get; set; } = new RangeNode<int>(15, 1, 200);
        public ColorNode DelveFossilChestColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ToggleNode DelveFossilChestLabel { get; set; } = true;
        public ColorNode DelveFossilChestLabelColor { get; set; } = new ColorBGRA(255, 255, 255, 255);
        public ColorNode DelveFossilChestLabelTextColor { get; set; } = new ColorBGRA(0, 115, 255, 255);
        #endregion      

        // Delve Mine Map Connections
        public ToggleNode DelveMineMapConnections { get; set; } = true;
        public RangeNode<int> ShowRadiusPercentage { get; set; } = new RangeNode<int>(80, 0, 100);

        public ToggleNode DebugMode { get; set; } = false;
        public ToggleNode ShouldHideOnOpen { get; set; } = false;
        public HotkeyNode DebugHotkey { get; set; } = new HotkeyNode(System.Windows.Forms.Keys.Menu);
	}
}
