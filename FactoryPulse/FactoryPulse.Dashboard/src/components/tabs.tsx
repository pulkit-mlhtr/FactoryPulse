import WorkerDashboard from "../pages/WorkerDashboard";
import SupervisorDashboard from "../pages/SupervisorDashboard";
import { useTabs } from "../context/tabContext";

export default function Tabs() {
    const { activeTab, setActiveTab } = useTabs();

  return (
    <div>
      <div className="flex gap-4 border-b mb-6">
        <button
          onClick={() => setActiveTab("worker")}
                  className={`px-4 py-2 text-black hover:bg-blue-100 ${
            activeTab === "worker" ? "border-b-2 border-blue-500" : ""
          }`}
        >
          Worker
        </button>

        <button
          onClick={() => setActiveTab("supervisor")}
                  className={`px-4 py-2 text-black hover:bg-blue-100 ${
            activeTab === "supervisor" ? "border-b-2 border-blue-500" : ""
          }`}
        >
          Supervisor
        </button>
      </div>
      
      {activeTab === "worker" && <WorkerDashboard />}

      {activeTab === "supervisor" && <SupervisorDashboard />}
    </div>
  );
}
