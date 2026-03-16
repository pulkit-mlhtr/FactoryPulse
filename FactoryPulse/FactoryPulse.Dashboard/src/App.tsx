import Tabs from "./components/Tabs";
import { TabProvider } from "./context/tabContext";

function App() {
  return (
    <div className="bg-gray-100 min-h-screen">
      <TabProvider>
        <Tabs />
      </TabProvider>
    </div>
  );
}

export default App;
