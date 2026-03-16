import EquipmentGrid from "../components/EquipmentGrid";
import { updateState } from "../api/equipmentApi";
import { useEquipments } from "../hooks/useEquipment";
import type { UpdateEquipmentStateRequest } from "../types/UpdateEquipmentStateRequest";
import { useTabs } from "../context/tabContext";
import { useSignalR } from "../hooks/useSignalR";

const FACTORY_ID = 101;

export default function WorkerDashboard() {
  const { equipments, setEquipments } = useTabs();

  useEquipments(FACTORY_ID, setEquipments);

  const onStateChange = async (request: UpdateEquipmentStateRequest) => {
    await updateState(request);
  };

  useSignalR((updatedEquipment: any) => {
    setEquipments((prev) =>
      prev.map((e) =>
        e.equipmentId === updatedEquipment.equipmentId
          ? { ...e, currentState: updatedEquipment.currentState }
          : e,
      ),
    );
  });
  return (
    <div>
      <h2 className="text-xl text-black font-semibold mb-4">
        Worker Dashboard (Factory 101)
      </h2>

      <EquipmentGrid
        equipments={equipments}
        onStateChange={onStateChange}
        onViewHistory={() => {}}
      />
    </div>
  );
}
