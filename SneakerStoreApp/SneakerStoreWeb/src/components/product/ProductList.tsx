import type { Product } from "../../models/product";
import ProductCard from "./ProductCard";

type Props = {
    products: Product[];
}

export default function ProductList({ products }: Props) {
    return (
        <div className="flex flex-row gap-x-[16px]">
            {products.map(product => (
                <ProductCard key={product.id} product={product} />
            ))}
        </div>
    )
}