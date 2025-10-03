import type { Product } from "../../models/product";
import ProductCard from "./ProductCard";

type Props = {
    products: Product[];
}

export default function ProductList({ products }: Props) {
    return (
        <div className="container mx-auto flex flex-row gap-x-[16px] flex-nowrap max-w-[1320px]">
            {products.map(product => (
                <ProductCard key={product.id} product={product} />
            ))}
        </div>
    )
}