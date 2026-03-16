import { updateState, getEquipmentHistory } from "../api/equipmentApi";
import type { Equipment } from "../types/Equipment";
import StatusIndicator from "./StatusIndicator";
import type { EquipmentHistory } from "../types/EquipmentHistory";
import type { SetStateAction } from "react";
import type { UpdateEquipmentStateRequest } from "../types/UpdateEquipmentStateRequest";

interface Props {
    equipment: Equipment;
    onHistoryLoaded: (equipments: EquipmentHistory[]) => void;
    showHistory: React.Dispatch<SetStateAction<boolean>>;
}

export default function EquipmentCard({ equipment, onHistoryLoaded, showHistory }: Readonly<Props>) {

    const onStateChange = async (rquest: UpdateEquipmentStateRequest) => {
    try {
        await updateState(rquest);
      
    } catch (error) {
      console.error(error);
    }
  };

  const onViewHistory = async (equipmentId: string) => {
    try {
        const res = await getEquipmentHistory(equipmentId);
        onHistoryLoaded(res);
        showHistory(true);
    } catch (error) {
        console.error(error);
        onHistoryLoaded([]);
    }
  };

  return (
    <div className="bg-white shadow rounded-lg p-4 flex flex-col gap-3">
      <div className="flex justify-between">
        <h3 className="font-bold">{equipment.equipmentCode}</h3>

        <StatusIndicator state={equipment.currentState} />
      </div>

      <div className="flex gap-2">
        <button
                  onClick={() => onStateChange({
                      equipmentId: equipment.equipmentId,
                      currentState: 1,
                      productionLine: equipment.productionLineId,
                      runningOrderId: equipment.runningOrder,
                      changedBy: "Worker",
                      reasonOfStateChange: "Routine Maintenance"
                  })}
          className="bg-red-500 text-white px-2 py-1 rounded text-sm"
        >
          Stop
        </button>

        <button
                  onClick={() => onStateChange({
                      equipmentId: equipment.equipmentId,
                      currentState: 2,
                      productionLine: equipment.productionLineId,
                      runningOrderId: equipment.runningOrder,
                      changedBy: "Worker",
                      reasonOfStateChange: "Mould Changing / Cleanup"
                  })}
          className="bg-yellow-400 px-2 py-1 rounded text-sm"
        >
          Starting Up
        </button>

              <button
                  onClick={() => onStateChange({
                      equipmentId: equipment.equipmentId,
                      currentState: 3,
                      productionLine: equipment.productionLineId,
                      runningOrderId: equipment.runningOrder,
                      changedBy: "Worker",
                      reasonOfStateChange: "Working Normally"
                  })}
          className="bg-green-500 text-white px-2 py-1 rounded text-sm"
        >
          Producing Normally
        </button>

        <button
          onClick={() => onViewHistory(equipment.equipmentId)}
          className="mt-2 bg-gray-200 px-2 py-1 rounded text-sm"
        >
          View History
        </button>
      </div>
    </div>
  );
}
