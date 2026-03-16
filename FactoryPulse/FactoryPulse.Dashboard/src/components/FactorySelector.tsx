import { useEffect } from "react";
import { useFactories } from "../hooks/useFactories";
import { getEquipments } from "../api/equipmentApi";
import type { Equipment } from "../types/Equipment";

interface Props {
  onEquipmentsLoaded: (equipments: Equipment[]) => void;
}

export default function FactorySelector({ onEquipmentsLoaded }: Readonly<Props>) {
  const { factories, selectedFactory, setSelectedFactory } = useFactories(1);

  useEffect(() => {
    if (!selectedFactory) return;

    const loadEquipments = async () => {
      const res = await getEquipments(selectedFactory);

      onEquipmentsLoaded(res);
    };

    loadEquipments();
  }, [selectedFactory]);

  return (
    <div className="mb-6">
      <label className="block text-black text-sm font-medium mb-2">Select Factory :</label>

      <select
        className="border rounded px-3 py-2 w-64"
        onChange={(e) => setSelectedFactory(Number(e.target.value))}
      >
        <option value="0">Select Factory</option>

        {factories.map((factory) => (
          <option key={factory.factoryId} value={factory.factoryId}>
            {factory.factoryCode}
          </option>
        ))}
      </select>
    </div>
  );
}
