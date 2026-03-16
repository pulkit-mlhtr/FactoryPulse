import type { UpdateEquipmentStateRequest } from "../types/UpdateEquipmentStateRequest"
import API from "./baseApi";

export const getEquipments = (factoryId:number) =>
    API.get(`/equipments?factoryId=${factoryId}`);

export const updateState = (
    request: UpdateEquipmentStateRequest
) =>
    API.post("/equipments/update", request)

export const getEquipmentHistory = (
    equipmentId: string
) =>
    API.get(`/equipments/${equipmentId}/state-history`)