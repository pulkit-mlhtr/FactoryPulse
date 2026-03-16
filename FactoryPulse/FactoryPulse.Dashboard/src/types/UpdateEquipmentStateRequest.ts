export interface UpdateEquipmentStateRequest {
    equipmentId: number
    currentState: number
    productionLine: number
    runningOrderId?: number
    changedBy: string
    reasonOfStateChange: string

}