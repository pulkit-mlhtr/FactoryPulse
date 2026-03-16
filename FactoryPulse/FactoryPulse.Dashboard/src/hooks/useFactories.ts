import { useEffect, useState } from "react"
import { getFactories } from "../api/factoryApi"
import type { Factory } from "../types/Factory"

export const useFactories = (countryId: number) => {

    const [factories, setFactories] = useState<Factory[]>([])
    const [selectedFactory, setSelectedFactory] =
        useState<number | null>(null)

    const loadFactories = async () => {

        const res = await getFactories(countryId)

        setFactories(res)

    }

    useEffect(() => {

        loadFactories()

    }, [])

    return {
        factories,
        selectedFactory,
        setSelectedFactory
    }

}