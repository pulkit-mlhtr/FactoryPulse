import { useState } from "react";
import FactorySelector from "../components/FactorySelector";
import EquipmentGrid from "../components/EquipmentGrid";
import type { Equipment } from "../types/Equipment";
import { useSignalR } from "../hooks/useSignalR";

export default function Dashboard() {
  const [equipments, setEquipments] = useState<Equipment[]>([]);

  useSignalR((equipment) => {
    setEquipments((prev) =>
      prev.map((e) =>
        e.equipmentId === equipment.equipmentId ? equipment : e,
      ),
    );
  });

  return (
    <div className="p-10">
      <h1 className="text-2xl font-bold mb-6">Factory Equipment Dashboard</h1>

      <FactorySelector onEquipmentsLoaded={setEquipments} />

      <EquipmentGrid equipments={equipments} />
    </div>
  );
}
