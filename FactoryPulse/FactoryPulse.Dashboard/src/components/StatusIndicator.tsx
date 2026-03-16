import type { EquipmentState } from "../types/Equipment";

interface Props {
  state: EquipmentState;
}

const colors = {
  Red: "bg-red-500",
  Yellow: "bg-yellow-400",
  Green: "bg-green-500",
};

export default function StatusIndicator({ state }: Props) {
  return (
    <div className="flex items-center gap-2">
      <div className={`w-3 h-3 rounded-full ${colors[state]} animate-pulse`} />

      <span className="font-semibold">{state}</span>
    </div>
  );
}
