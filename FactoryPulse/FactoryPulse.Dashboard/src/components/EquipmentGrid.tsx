import { useState } from "react";
import type { Equipment } from "../types/Equipment";
import type { EquipmentHistory } from "../types/EquipmentHistory";
import EquipmentCard from "./EquipmentCard";
import EquipmentHistoryModal from "./EquipmentHistoryModal";

interface Props {
  equipments: Equipment[];
}

export default function EquipmentGrid({ equipments }: Props) {
    const [showHistory, setShowHistory] =
        useState(false);
    const [histories, setHistories] =
        useState<EquipmentHistory[]>([])

  return (
    <div className="grid grid-cols-4 gap-6">
      {equipments.map((e) => (
        <EquipmentCard
              key={e.equipmentId}
              equipment={e}
              onHistoryLoaded={setHistories}
              showHistory={setShowHistory}
          />        
      ))}
          {showHistory && (

              <EquipmentHistoryModal
                  histories={histories}
                  onClose={() => setShowHistory(false)}
              />

          )}
    </div>
  );
}
