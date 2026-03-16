import { useState } from "react";
import type { Equipment } from "../types/Equipment";
import EquipmentCard from "./EquipmentCard";
import EquipmentHistoryModal from "./EquipmentHistoryModal";

interface Props {
    equipments: Equipment[]
    onStateChange?: any
    onViewHistory?: any
}

export default function EquipmentGrid({ equipments, onStateChange, onViewHistory }: Props) {

  return (
    <div className="grid grid-cols-4 gap-6">
      {equipments.map((e) => (
        <EquipmentCard
              key={e.equipmentId}
              equipment={e}
              onStateChange={onStateChange}
              onViewHistory={onViewHistory}
          />        
      ))}          
    </div>
  );
}
