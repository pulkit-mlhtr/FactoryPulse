import { getEquipmentStateColorCss, getEquipmentStatus } from "../util/equipmentStatusHelper"

interface Props {
    state: number;
}

export default function StatusIndicator({ state }: Props) {
  return (
    <div className="flex items-center gap-2">                  
          Current Status:  <span style={{ color: getEquipmentStateColorCss(state) }} className="font-semibold">{getEquipmentStatus(state)}</span>
    </div>
  );
}
