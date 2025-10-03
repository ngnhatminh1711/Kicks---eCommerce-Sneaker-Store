import { useEffect, useState } from "react";
import type { Product } from "./models/product";
import ProductList from "./components/product/ProductList";
import Header from "./components/layout/Header.tsx";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/products')
      .then(response => response.json())
      .then(data => setProducts(data));
  }, []);

  return (
    <div className="container mx-auto">
      <Header />
      <ProductList products={products} />
    </div>
  );
}

export default App;
