import type { Equipment } from "../types/Equipment";
import type { UpdateEquipmentStateRequest } from "../types/UpdateEquipmentStateRequest"
import API from "./baseApi";

export const getEquipments = (factoryId:number) =>
    API.get(`/equipments/${factoryId}`);

export const updateState = (
    request: UpdateEquipmentStateRequest
) =>
    API.post<UpdateEquipmentStateRequest,Equipment>("/equipments/update", request)

export const getEquipmentHistory = (
    equipmentId: number
) =>
    API.get(`/equipments/${equipmentId}/state-history`)