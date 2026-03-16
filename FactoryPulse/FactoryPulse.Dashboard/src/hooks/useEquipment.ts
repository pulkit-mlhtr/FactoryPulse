import { useEffect } from "react"
import { getEquipments } from "../api/equipmentApi"

export const useEquipments = (factoryId: number, setEquipments:any) => {
    const loadEquipments = async () => {

        const res = await getEquipments(factoryId)

        setEquipments(res);
    }

    useEffect(() => {
        if (factoryId) {
            loadEquipments()
        }
        setEquipments([]);

    }, [])   
}