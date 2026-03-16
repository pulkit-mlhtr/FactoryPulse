interface Props {
    orderNumber: number | undefined;
}

export default function OrderIndicator({ orderNumber }: Props) {
    return (
        <div className="flex items-center gap-2">
            <span className="text-gray-500 font-medium text-xs uppercase tracking-tight">Order: </span>

            {orderNumber ? (
                <span className="px-1.5 py-0.5 bg-slate-100 text-slate-600 border border-slate-200 rounded text-[10px] font-bold leading-none">
                    #{orderNumber}
                </span>
            ) : (
                    <span className="text-gray-400 italic text-[10px]">No Active Order</span>
            )}
        </div>
    );
}