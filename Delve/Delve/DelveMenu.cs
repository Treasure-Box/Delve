using ImGuiNET;
using Delve.Libs;

namespace Delve
{
	partial class Delve
	{
		public void Menu(int idIn, out int idPop)
		{
			idPop = idIn;
			if (ImGui.TreeNode("Delve Path's"))
			{
				ImGui.PushID(idPop);
				Settings.DelvePathWays.Value = ImGuiExtension.Checkbox(Settings.DelvePathWays.Value ? "Show" : "Hidden", Settings.DelvePathWays);
				ImGui.PopID();
				idPop++;

				ImGui.Spacing();
				ImGui.PushID(idPop);
				Settings.DelvePathWaysNodeSize.Value = ImGuiExtension.IntSlider("Size", Settings.DelvePathWaysNodeSize);
				ImGui.PopID();
				idPop++;
				ImGui.PushID(idPop);
				Settings.DelvePathWaysNodeColor = ImGuiExtension.ColorPicker("Color", Settings.DelvePathWaysNodeColor);
				ImGui.PopID();
				idPop++;
				ImGui.Spacing();
				ImGui.Spacing();
				Settings.DelveWall.Value = ImGuiExtension.Checkbox($"Breakable Wall##{idPop}", Settings.DelveWall);
				idPop++;
				Settings.DelveWallSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveWallSize);
				idPop++;
				Settings.DelveWallColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveWallColor);
				idPop++;
				ImGui.TreePop();
			}

            if (ImGui.TreeNode("Delve Chests"))
            {
                ImGui.PushID(idPop);
                Settings.DelveChests.Value = ImGuiExtension.Checkbox(Settings.DelveChests.Value ? "Show" : "Hidden",
                    Settings.DelveChests);
                ImGui.PopID();
                idPop++;
                ImGui.PushID(idPop);
                Settings.NiceString.Value = ImGuiExtension.Checkbox(
                    Settings.NiceString.Value ? "Showing Nice Strings" : "Showing Raw Strings", Settings.NiceString);
                ImGui.PopID();
                ImGui.Spacing();
                ImGui.Spacing();
                idPop++;

                //Delve Mining Supplies
                #region Mining Supplies
                if (ImGui.TreeNode("Mining Supplies"))
                {
                    #region Delve Mining Supplies
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChest.Value = ImGuiExtension.Checkbox($"Mining Supplies##{idPop}", Settings.DelveMiningSuppliesChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveMiningSuppliesChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveMiningSuppliesChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestLabel.Value = ImGuiExtension.Checkbox($"Mining Supplies Label##{idPop}", Settings.DelveMiningSuppliesChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestLabelSize.Value = ImGuiExtension.IntSlider($"Label Size##{idPop}", Settings.DelveMiningSuppliesChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveMiningSuppliesChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveMiningSuppliesChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveMiningSuppliesChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveMiningSuppliesChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Delve Mining Supplies Dynamite
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChest.Value = ImGuiExtension.Checkbox($"Dynamite Supplies##{idPop}", Settings.DelveMiningSuppliesDynamiteChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveMiningSuppliesDynamiteChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveMiningSuppliesDynamiteChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestLabel.Value = ImGuiExtension.Checkbox($"Dynamite Supplies Label##{idPop}", Settings.DelveMiningSuppliesDynamiteChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestLabelSize.Value = ImGuiExtension.IntSlider($"Label Size##{idPop}", Settings.DelveMiningSuppliesDynamiteChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveMiningSuppliesDynamiteChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveMiningSuppliesDynamiteChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveMiningSuppliesDynamiteChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesDynamiteChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveMiningSuppliesDynamiteChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Delve Mining Supplies Flares
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChest.Value = ImGuiExtension.Checkbox($"Flare Supplies##{idPop}", Settings.DelveMiningSuppliesFlaresChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveMiningSuppliesFlaresChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveMiningSuppliesFlaresChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestLabel.Value = ImGuiExtension.Checkbox($"Flare Supplies Label##{idPop}", Settings.DelveMiningSuppliesFlaresChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestLabelSize.Value = ImGuiExtension.IntSlider($"Label Size##{idPop}", Settings.DelveMiningSuppliesFlaresChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveMiningSuppliesFlaresChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveMiningSuppliesFlaresChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveMiningSuppliesFlaresChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMiningSuppliesFlaresChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveMiningSuppliesFlaresChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }
                #endregion
                
                //Azurite Node
                #region Azurite Nodes
                if (ImGui.TreeNode("Azurite Vein"))
                {
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChest.Value = ImGuiExtension.Checkbox($"Azurite Vein##{idPop}", Settings.DelveAzuriteVeinChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveAzuriteVeinChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveAzuriteVeinChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestLabel.Value = ImGuiExtension.Checkbox($"Azurite Vein Label##{idPop}", Settings.DelveAzuriteVeinChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestLabelSize .Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveAzuriteVeinChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveAzuriteVeinChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveAzuriteVeinChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveAzuriteVeinChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAzuriteVeinChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveAzuriteVeinChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                }
                #endregion
                
                //Resonators
                #region Resonators
                if (ImGui.TreeNode("Resonators"))
                {
                    #region Resonators Tier 1
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1Chest.Value = ImGuiExtension.Checkbox($"Resonator T1 Chest##{idPop}", Settings.DelveResonatorTier1Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveResonatorTier1ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveResonatorTier1ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestLabel.Value = ImGuiExtension.Checkbox($"Resonator T1 Chest Label##{idPop}", Settings.DelveResonatorTier1ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveResonatorTier1ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveResonatorTier1ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveResonatorTier1ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveResonatorTier1ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier1ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveResonatorTier1ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Resonators Tier 2
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2Chest.Value = ImGuiExtension.Checkbox($"Resonator T2 Chest##{idPop}", Settings.DelveResonatorTier2Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveResonatorTier2ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveResonatorTier2ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestLabel.Value = ImGuiExtension.Checkbox($"Resonator T2 Chest Label##{idPop}", Settings.DelveResonatorTier2ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveResonatorTier2ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveResonatorTier2ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveResonatorTier2ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveResonatorTier2ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier2ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveResonatorTier2ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Resonators Tier 3
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3Chest.Value = ImGuiExtension.Checkbox($"Resonator T3 Chest##{idPop}", Settings.DelveResonatorTier3Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveResonatorTier3ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveResonatorTier3ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestLabel.Value = ImGuiExtension.Checkbox($"Resonator T3 Chest Label##{idPop}", Settings.DelveResonatorTier3ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveResonatorTier3ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveResonatorTier3ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveResonatorTier3ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveResonatorTier3ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveResonatorTier3ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveResonatorTier3ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }
                #endregion

                //Fossils
                #region Fossils
                if (ImGui.TreeNode("Fossils"))
                {
                    #region Fossils Tier 1
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1Chest.Value = ImGuiExtension.Checkbox($"Fossil T1 Chest##{idPop}", Settings.DelveFossilTier1Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveFossilTier1ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveFossilTier1ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestLabel.Value = ImGuiExtension.Checkbox($"Fossil T1 Chest Label##{idPop}", Settings.DelveFossilTier1ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestLabelSize.Value = ImGuiExtension.IntSlider($"Lable Size##{idPop}", Settings.DelveFossilTier1ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveFossilTier1ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveFossilTier1ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveFossilTier1ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier1ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveFossilTier1ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Fossils Tier 2
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2Chest.Value = ImGuiExtension.Checkbox($"Fossil T2 Chest##{idPop}", Settings.DelveFossilTier2Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveFossilTier2ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveFossilTier2ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestLabel.Value = ImGuiExtension.Checkbox($"Fossil T2 Chest Label##{idPop}", Settings.DelveFossilTier2ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestLabelSize.Value = ImGuiExtension.IntSlider($"Lable Size##{idPop}", Settings.DelveFossilTier2ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveFossilTier2ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveFossilTier2ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveFossilTier2ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier2ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveFossilTier2ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Fossils Tier 3
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3Chest.Value = ImGuiExtension.Checkbox($"Fossil T3 Chest##{idPop}", Settings.DelveFossilTier3Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveFossilTier3ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveFossilTier3ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestLabel.Value = ImGuiExtension.Checkbox($"Fossil T3 Chest Label##{idPop}", Settings.DelveFossilTier3ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestLabelSize.Value = ImGuiExtension.IntSlider($"Lable Size##{idPop}", Settings.DelveFossilTier3ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveFossilTier3ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveFossilTier3ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveFossilTier3ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFossilTier3ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveFossilTier3ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }
                #endregion

                //Currency
                #region Currency
                if (ImGui.TreeNode("Currency"))
                {
                    #region Currency Tier 1
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1Chest.Value = ImGuiExtension.Checkbox($"Currency T1 Chest##{idPop}", Settings.DelveCurrencyTier1Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveCurrencyTier1ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveCurrencyTier1ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestLabel.Value = ImGuiExtension.Checkbox($"Currency T1 Chest Label##{idPop}", Settings.DelveCurrencyTier1ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestLabelSize.Value = ImGuiExtension.IntSlider($"Lable Size##{idPop}", Settings.DelveCurrencyTier1ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveCurrencyTier1ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveCurrencyTier1ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveCurrencyTier1ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier1ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveCurrencyTier1ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Currency Tier 2
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2Chest.Value = ImGuiExtension.Checkbox($"Currency T2 Chest##{idPop}", Settings.DelveCurrencyTier2Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveCurrencyTier2ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveCurrencyTier2ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestLabel.Value = ImGuiExtension.Checkbox($"Currency T2 Chest Label##{idPop}", Settings.DelveCurrencyTier2ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestLabelSize.Value = ImGuiExtension.IntSlider($"Lable Size##{idPop}", Settings.DelveCurrencyTier2ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveCurrencyTier2ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveCurrencyTier2ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveCurrencyTier2ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier2ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveCurrencyTier2ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Currency Tier 3
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3Chest.Value = ImGuiExtension.Checkbox($"Currency T3 Chest##{idPop}", Settings.DelveCurrencyTier3Chest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveCurrencyTier3ChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveCurrencyTier3ChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestLabel.Value = ImGuiExtension.Checkbox($"Currency T3 Chest Label##{idPop}", Settings.DelveCurrencyTier3ChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestLabelSize.Value = ImGuiExtension.IntSlider($"Lable Size##{idPop}", Settings.DelveCurrencyTier3ChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveCurrencyTier3ChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveCurrencyTier3ChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveCurrencyTier3ChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveCurrencyTier3ChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveCurrencyTier3ChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }
                #endregion

                //On/Off Path Generic
                if (ImGui.TreeNode("On/Off Path Generic"))
                {
                    #region On Pathway Chest
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChest.Value = ImGuiExtension.Checkbox($"On Pathway Chest##{idPop}", Settings.DelveOnPathwayChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveOnPathwayChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveOnPathwayChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestLabel.Value = ImGuiExtension.Checkbox($"On Pathway Chest Label##{idPop}", Settings.DelveOnPathwayChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveOnPathwayChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveOnPathwayChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveOnPathwayChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveOnPathwayChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOnPathwayChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveOnPathwayChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                    #region Off Pathway Chest
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChest.Value = ImGuiExtension.Checkbox($"Off Pathway Chest##{idPop}", Settings.DelveOffPathwayChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveOffPathwayChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveOffPathwayChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestLabel.Value = ImGuiExtension.Checkbox($"Off Pathway Chest Label##{idPop}", Settings.DelveOffPathwayChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveOffPathwayChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveOffPathwayChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveOffPathwayChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveOffPathwayChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveOffPathwayChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveOffPathwayChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Generic Chest
                if (ImGui.TreeNode("Generic Chest"))
                {
                    #region Generic Chest
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChest.Value = ImGuiExtension.Checkbox($"Generic Chest##{idPop}", Settings.DelveGenericChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveGenericChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveGenericChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestLabel.Value = ImGuiExtension.Checkbox($"Generic Chest Label##{idPop}", Settings.DelveGenericChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveGenericChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveGenericChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveGenericChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveGenericChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGenericChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveGenericChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Armour Chest
                if (ImGui.TreeNode("Armour Chest"))
                {
                    #region Armour Chest
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChest.Value = ImGuiExtension.Checkbox($"Armour Chest##{idPop}", Settings.DelveArmourChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveArmourChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveArmourChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestLabel.Value = ImGuiExtension.Checkbox($"Armour Chest Label##{idPop}", Settings.DelveArmourChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveArmourChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveArmourChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveArmourChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveArmourChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveArmourChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveArmourChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Weapon Chest
                if (ImGui.TreeNode("Weapon Chest"))
                {
                    #region Weapon Chest
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChest.Value = ImGuiExtension.Checkbox($"Weapon Chest##{idPop}", Settings.DelveWeaponChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveWeaponChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveWeaponChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestLabel.Value = ImGuiExtension.Checkbox($"Weapon Chest Label##{idPop}", Settings.DelveWeaponChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveWeaponChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveWeaponChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveWeaponChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveWeaponChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveWeaponChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveWeaponChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Trinket Chest
                if (ImGui.TreeNode("Trinket Chest"))
                {
                    #region Trinket Chest
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChest.Value = ImGuiExtension.Checkbox($"Trinket Chest##{idPop}", Settings.DelveTrinketChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveTrinketChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveTrinketChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestLabel.Value = ImGuiExtension.Checkbox($"Trinket Chest Label##{idPop}", Settings.DelveTrinketChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveTrinketChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveTrinketChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveTrinketChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveTrinketChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveTrinketChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveTrinketChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Gem Chest
                if (ImGui.TreeNode("Gem Chest"))
                {
                    #region Gem Chest
                    ImGui.PushID(idPop);
                    Settings.DelveGemChest.Value = ImGuiExtension.Checkbox($"Gem Chest##{idPop}", Settings.DelveGemChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveGemChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveGemChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestLabel.Value = ImGuiExtension.Checkbox($"Gem Chest Label##{idPop}", Settings.DelveGemChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveGemChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveGemChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveGemChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveGemChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveGemChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveGemChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Vaal Chest
                if (ImGui.TreeNode("Vaal Chest"))
                {
                    #region Vaal Chest
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChest.Value = ImGuiExtension.Checkbox($"Vaal Chest##{idPop}", Settings.DelveVaalChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveVaalChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveVaalChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestLabel.Value = ImGuiExtension.Checkbox($"Vaal Chest Label##{idPop}", Settings.DelveVaalChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveVaalChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveVaalChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveVaalChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveVaalChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveVaalChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveVaalChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Abyssal Chest
                if (ImGui.TreeNode("Abyssal Chest"))
                {
                    #region Abyssal Chest
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChest.Value = ImGuiExtension.Checkbox($"Abyssal Chest##{idPop}", Settings.DelveAbyssalChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveAbyssalChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveAbyssalChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestLabel.Value = ImGuiExtension.Checkbox($"Abyssal Chest Label##{idPop}", Settings.DelveAbyssalChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveAbyssalChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveAbyssalChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveAbyssalChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveAbyssalChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveAbyssalChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveAbyssalChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion

                }
                //Delve Dynamite Chest
                if (ImGui.TreeNode("Dynamite Chest"))
                {
                    #region Dynamite Chest
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChest.Value = ImGuiExtension.Checkbox($"Dynamite Chest##{idPop}", Settings.DelveDynamiteChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveDynamiteChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveDynamiteChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestLabel.Value = ImGuiExtension.Checkbox($"Dynamite Chest Label##{idPop}", Settings.DelveDynamiteChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveDynamiteChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveDynamiteChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveDynamiteChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveDynamiteChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveDynamiteChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveDynamiteChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Legacy League Chest
                if (ImGui.TreeNode("Leagacy League Chest"))
                {
                    #region Legacy League Chest
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChest.Value = ImGuiExtension.Checkbox($"Legacy League Chest##{idPop}", Settings.DelveLegacyLeagueChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveLegacyLeagueChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveLegacyLeagueChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestLabel.Value = ImGuiExtension.Checkbox($"Legacy League Chest Label##{idPop}", Settings.DelveLegacyLeagueChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveLegacyLeagueChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveLegacyLeagueChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveLegacyLeagueChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveLegacyLeagueChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveLegacyLeagueChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveLegacyLeagueChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Map Chest
                if (ImGui.TreeNode("Map Chest"))
                {
                    #region Map Chest
                    ImGui.Spacing();
                    ImGui.Spacing();
                    ImGui.PushID(idPop);
                    Settings.DelveMapChest.Value = ImGuiExtension.Checkbox($"Map Chest##{idPop}", Settings.DelveMapChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveMapChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveMapChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestLabel.Value = ImGuiExtension.Checkbox($"Map Chest Label##{idPop}", Settings.DelveMapChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveMapChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveMapChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveMapChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveMapChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveMapChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveMapChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Fragment Chest
                if (ImGui.TreeNode("Fragment Chest"))
                {
                    #region Fragment Chest
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChest.Value = ImGuiExtension.Checkbox($"Fragment Chest##{idPop}", Settings.DelveFragmentChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveFragmentChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveFragmentChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestLabel.Value = ImGuiExtension.Checkbox($"Fragment Chest Label##{idPop}", Settings.DelveFragmentChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveFragmentChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveFragmentChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveFragmentChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveFragmentChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveFragmentChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveFragmentChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }

                //Delve Special Chest
                if (ImGui.TreeNode("special Chest"))
                {
                    #region Special Chest
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChest.Value = ImGuiExtension.Checkbox($"Special Chest##{idPop}", Settings.DelveSpecialChest);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveSpecialChestSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestColor.Value = ImGuiExtension.ColorPicker($"Color##{idPop}", Settings.DelveSpecialChestColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestLabel.Value = ImGuiExtension.Checkbox($"Special Chest Label##{idPop}", Settings.DelveSpecialChestLabel);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestLabelSize.Value = ImGuiExtension.IntSlider($"Size##{idPop}", Settings.DelveSpecialChestLabelSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestLabelColor.Value = ImGuiExtension.ColorPicker($"Label Color##{idPop}", Settings.DelveSpecialChestLabelColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestLabelBorderSize.Value = ImGuiExtension.IntSlider($"Label boarder Size##{idPop}", Settings.DelveSpecialChestLabelBorderSize);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestLabelBorderColor.Value = ImGuiExtension.ColorPicker($"Label border Color##{idPop}", Settings.DelveSpecialChestLabelBorderColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.PushID(idPop);
                    Settings.DelveSpecialChestLabelTextColor.Value = ImGuiExtension.ColorPicker($"Label Text Color##{idPop}", Settings.DelveSpecialChestLabelTextColor);
                    ImGui.PopID();
                    idPop++;
                    ImGui.Spacing();
                    ImGui.Spacing();
                    #endregion
                }
            }

            if (ImGui.TreeNode("Delve Mine Map Stuff"))
            {
                ImGui.PushID(idPop);
                Settings.DelveMineMapConnections.Value = ImGuiExtension.Checkbox($"Show Connections###{idPop}", Settings.DelveMineMapConnections.Value);
                ImGui.PopID();
                idPop++;
                Settings.ShowRadiusPercentage.Value = ImGuiExtension.IntSlider($"Radius (%)##{idPop}", Settings.ShowRadiusPercentage);
                idPop++;
                ImGui.TreePop();
            }
            if(ImGui.TreeNode("Debug Mode"))
            {
                ImGui.PushID(idPop);
                Settings.DebugHotkey.Value = ImGuiExtension.HotkeySelector($"Debug Mode Hotkey", Settings.DebugHotkey.Value);
                ImGui.PopID();
                idPop++;
                Settings.DebugMode.Value = ImGuiExtension.Checkbox($"Debug Mode##{idPop}", Settings.DebugMode);
                idPop++;
                Settings.ShouldHideOnOpen.Value = ImGuiExtension.Checkbox($"Hide Chest Name When Opened##{idPop}", Settings.ShouldHideOnOpen);
                idPop++;
                ImGui.TreePop();
            }
		}
	
		public override void DrawSettingsMenu()
		{
			ImGui.BulletText($"v{PluginVersion}");
			ImGui.BulletText($"Last Updated: {buildDate}");
			idPop = 1;
			ImGui.PushStyleVar(StyleVar.ChildRounding, 5.0f);
			ImGuiNative.igGetContentRegionAvail(out var newcontentRegionArea);
			if (ImGui.BeginChild("RightSettings", new System.Numerics.Vector2(newcontentRegionArea.X, newcontentRegionArea.Y), true, WindowFlags.Default))
			{
				Menu(idPop, out var newInt);
				idPop = newInt;
			}
            ImGui.EndChild();
		}
	}
}