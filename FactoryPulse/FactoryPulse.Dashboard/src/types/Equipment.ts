export const EquipmentStateValues = {
    Red: 1,
    Yellow: 2,
    Green: 3,
} as const;

export interface Equipment {

    equipmentId: string
    equipmentCode: string
    currentState: number
    runningOrder: number | undefined
    productionLineId: number

}