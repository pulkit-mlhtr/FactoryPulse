import * as signalR from "@microsoft/signalr";
import { useEffect } from "react";
import type { Equipment } from "../types/Equipment";
import type { UpdateEquipmentStateRequest } from "../types/UpdateEquipmentStateRequest";

export const useSignalR = (onUpdate: (equipment: Equipment) => void) => {
  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("/equipmentHub",{
      withCredentials: false
      })
      .withAutomaticReconnect()
      .build();

    connection.on("equipmentStateUpdated", (equipment: UpdateEquipmentStateRequest) => {
      onUpdate(equipment);
    });

      connection
          .start()
          .then(() => console.log("SignalR Connected"))      
      .catch((err) => console.error("SignalR Error:", err));    
  }, []);
};
