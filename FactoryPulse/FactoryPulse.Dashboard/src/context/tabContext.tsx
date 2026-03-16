import { createContext, useContext, useState } from 'react';
import type { Equipment } from "../types/Equipment"

const TabContext = createContext({ });

export const TabProvider = ({ children }) => {
    // Set the default active tab ID here
    const [activeTab, setActiveTab] = useState<"worker" | "supervisor">("worker");
    const [equipments, setEquipments] = useState<Equipment[]>([])

    return (
        <TabContext.Provider value={{ activeTab, setActiveTab, equipments, setEquipments }
}>
    { children }
    </TabContext.Provider>
  );
};

// Custom hook for cleaner imports in your components
export const useTabs = () => useContext(TabContext);