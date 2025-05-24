import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import CategoriesList from './components/CategoriesList';
import ToysList from "./components/ToysList";
import ToyDetails from "./components/ToyDetails";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<CategoriesList />} />
        <Route path="/category/:categoryId" element={<ToysList />} />
        <Route path="/toy/:toyId" element={<ToyDetails />} />
      </Routes>
    </Router>
  );
}

export default App;