import { getEquipmentStatus } from "../util/equipmentStatusHelper"
import { useEquipmentHistories } from "../hooks/useEquipmentHistories";
interface Props {
    equipmentId: number;
    onClose: () => void;
}

export default function EquipmentHistoryModal({ equipmentId, onClose }: Props) {
    const { histories } = useEquipmentHistories(equipmentId);
  
    return (
        <div className="fixed inset-0 bg-black/40 flex items-center justify-center">
            <div className="bg-white rounded-lg p-6 w-[500px]">
                <div className="flex justify-between mb-4">
                    <h2 className="font-bold text-lg">Equipment History</h2>

                    <button onClick={onClose} className="text-gray-500">
                        X
                    </button>
                </div>

                <div className="max-h-80 overflow-auto text-black">
                    <table className="w-full text-sm">
                        <thead>
                            <tr className="border-b">
                                <th className="text-left py-2">Previous State</th>
                                <th className="text-left py-2">Current State</th>
                                <th className="text-left py-2">Order</th>
                                <th className="text-left py-2">Time</th>
                                <th className="text-left py-2">Changed By</th>
                            </tr>
                        </thead>

                        <tbody>
                            {histories.length>0 ? histories.map((h, i) => (
                                <tr key={i} className="border-b">
                                    <td>{getEquipmentStatus(h.previousState)}</td>
                                    <td>{getEquipmentStatus(h.newState)}</td>
                                    <td>{h.orderId}</td>
                                    <td>{h.changedBy}</td>
                                    <td>{new Date(h.changedAt).toLocaleString()}</td>
                                </tr>
                            )):<div>No log found.</div>}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}
