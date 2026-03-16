import { EquipmentStateValues } from "../types/Equipment"

export const getEquipmentStatus = (state: number): string => {
    switch (state) {
        case EquipmentStateValues.Red:
            return "Stopped";
        case EquipmentStateValues.Yellow:
            return "Starting Up";
        case EquipmentStateValues.Green:
            return "Producing Normally";
        default:
            return "Unknown";
    }
}

    export const getEquipmentStateColorCss = (state: number): string => {
        switch (state) {
            case EquipmentStateValues.Red:
                return "#dc2626";
            case EquipmentStateValues.Yellow:
                return "#f59e0b";
            case EquipmentStateValues.Green:
                return "#16a34a";
            default:
                return "#4b5563";
        }
    }