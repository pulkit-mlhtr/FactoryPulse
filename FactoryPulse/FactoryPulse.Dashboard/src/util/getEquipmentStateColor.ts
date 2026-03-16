import { EquipmentStateValues } from "../types/Equipment"

export const getEquipmentStateColor = (state: number): string => {
    switch (state) {
        case EquipmentStateValues.Red:
            return "Red";
        case EquipmentStateValues.Yellow:
            return "Yellow";
        case EquipmentStateValues.Green:
            return "Green";
        default:
            return "Unknown";
    }
};