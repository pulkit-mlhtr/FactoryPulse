import { useState } from "react";
import EquipmentGrid from "../components/EquipmentGrid";
import FactorySelector from "../components/FactorySelector";
import EquipmentHistoryModal from "../components/EquipmentHistoryModal";
import type { Equipment } from "../types/Equipment";

export default function SupervisorDashboard() {
    const [equipmentId, setEquipmentId] = useState<number>(0);
    const [currentEquipments, setCurrentEquipments] = useState<Equipment[]>([]);    

  const [showHistory, setShowHistory] = useState(false);

    const viewHistory = async (equipmentId: number) => {
         setEquipmentId(equipmentId);
         setShowHistory(true)
  };

  return (
    <div>
      <h2 className="text-xl font-semibold mb-4">Supervisor Dashboard</h2>

      <FactorySelector onEquipmentsLoaded={setCurrentEquipments} />

      <EquipmentGrid
        equipments={currentEquipments}
        onStateChange={() => {}}
        onViewHistory={viewHistory}
      />

      {showHistory && (
              <EquipmentHistoryModal
                  equipmentId={equipmentId}
          onClose={() => setShowHistory(false)}
        />
      )}
    </div>
  );
}
