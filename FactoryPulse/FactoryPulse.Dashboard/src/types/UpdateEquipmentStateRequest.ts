export interface UpdateEquipmentStateRequest {

    equipmentId: string
    currentState: number
    productionLine: number
    runningOrderId?: number
    changedBy: string
    reasonOfStateChange: string

}