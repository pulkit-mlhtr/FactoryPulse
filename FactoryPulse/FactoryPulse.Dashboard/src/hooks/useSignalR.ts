import * as signalR from "@microsoft/signalr";
import { useEffect } from "react";
import type { Equipment } from "../types/Equipment";

export const useSignalR = (onUpdate: (equipment: Equipment) => void) => {
  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7349/equipmentHub", {
            withCredentials: true
        })
      .withAutomaticReconnect()
      .build();

    connection.on("equipmentStateUpdated", (equipment: Equipment) => {
      onUpdate(equipment);
    });

      connection
          .start()
          .then(() => console.log("SignalR Connected"))      
      .catch((err) => console.error("SignalR Error:", err));

    return () => {
      connection.stop();
    };
  }, []);
};
