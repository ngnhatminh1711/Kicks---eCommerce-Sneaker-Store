import { useEffect, useState } from "react";
import type { Product } from "./models/product";
import ProductList from "./components/product/ProductList";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/products')
      .then(response => response.json())
      .then(data => setProducts(data));
  }, []);

  return (
    <div>
      <ProductList products={products} />
    </div>
  );
}

export default App;
