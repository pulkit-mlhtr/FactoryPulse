import type { Equipment } from "../types/Equipment";
import StatusIndicator from "./StatusIndicator";
import { getEquipmentStatus } from "../util/equipmentStatusHelper"
import { useTabs } from "../context/tabContext";
import OrderIndicator from "./OrderIndicator";
interface Props {
    equipment: Equipment;
    onStateChange: any
    onViewHistory: any
}

export default function EquipmentCard({ equipment, onStateChange, onViewHistory }: Readonly<Props>) {   
    const { activeTab } = useTabs();
    return (
        <div className="bg-white shadow rounded-lg p-2 flex flex-col gap-2">
            <div>
                <h3 className="font-italic text-black">{equipment.equipmentCode}</h3>                
                <div >                    
                    <StatusIndicator state={equipment.currentState} />
                </div>
                <div className="flex items-center gap-2">
                    <OrderIndicator orderNumber={equipment.currentOrderId} />
                </div>
            </div>

            <div className="flex gap-2 justify-center">
                {activeTab == "worker" &&
                    <><button
                    disabled={equipment.currentState === 1}
                    onClick={() => onStateChange({
                        equipmentId: equipment.equipmentId,
                        currentState: 1,
                        productionLine: equipment.productionLineId,
                        runningOrderId: equipment.currentOrderId,
                        changedBy: "Worker",
                        reasonOfStateChange: "Routine Maintenance"
                    })}
                    className="bg-red-500 text-white px-2 py-1 rounded text-sm"
                >
                    {getEquipmentStatus(1)}
                </button>

                    <button
                        disabled={equipment.currentState === 2}
                    onClick={() => onStateChange({
                        equipmentId: equipment.equipmentId,
                        currentState: 2,
                        productionLine: equipment.productionLineId,
                        runningOrderId: equipment.currentOrderId,
                        changedBy: "Worker",
                        reasonOfStateChange: "Mould Changing / Cleanup"
                    })}
                    className="bg-yellow-400 px-2 py-1 rounded text-sm"
                >
                    {getEquipmentStatus(2)}
                </button>

                    <button
                        disabled={equipment.currentState === 3}
                    onClick={() => onStateChange({
                        equipmentId: equipment.equipmentId,
                        currentState: 3,
                        productionLine: equipment.productionLineId,
                        runningOrderId: equipment.currentOrderId,
                        changedBy: "Worker",
                        reasonOfStateChange: "Working Normally"
                    })}
                    className="bg-green-500 text-white px-2 py-1 rounded text-sm"
                >
                    {getEquipmentStatus(3)}
                    </button></>}
                {activeTab == "supervisor" && <button
                    onClick={() => onViewHistory(equipment.equipmentId)}
                    className="w-full bg-white hover:bg-blue-50 text-blue-700 px-3 py-1.5 rounded-md text-xs font-bold border border-blue-200 transition-colors shadow-sm"
                >
                    View History
                </button>}
               
            </div>
        </div>
    );
}
