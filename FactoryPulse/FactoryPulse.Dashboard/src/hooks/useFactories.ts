import { useEffect, useState } from "react"
import { getFactories } from "../api/factoryApi"
import type { Factory } from "../types/Factory"

export const useFactories = () => {

    const [factories, setFactories] = useState<Factory[]>([])
    const [selectedFactory, setSelectedFactory] =
        useState<number | null>(null)

    const loadFactories = async () => {

        const res = await getFactories()

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