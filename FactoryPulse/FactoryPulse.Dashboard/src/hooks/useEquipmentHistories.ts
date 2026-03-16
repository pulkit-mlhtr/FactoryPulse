import { useEffect, useState } from "react"
import type { EquipmentHistory } from "../types/EquipmentHistory"
import { getEquipmentHistory } from "../api/equipmentApi"

export const useEquipmentHistories = (equipmentId:number) => {

    const [histories, setHistories] = useState<EquipmentHistory[]>([])

    const loadFactories = async () => {

        const res = await getEquipmentHistory(equipmentId)

        setHistories(res);
    }

    useEffect(() => {
        if (equipmentId) {
            loadFactories()
        }
        setHistories([])

    }, [])

    return {
        histories  
    }

}