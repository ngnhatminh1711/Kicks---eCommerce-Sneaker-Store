import type { Product } from "../../models/product"

type Props = {
    product: Product
}

export default function ProductCard({ product }: Props) {
    return (
        <div className="flex w-[318px] flex-col items-center gap-y-[16px]">
            <div></div>
            <h3>{product.name}</h3>
            <button className="flex h-12 px-16 py-2 justify-center items-center gap-1 self-stretch rounded-sm bg-[#232321]">
                <div className=" text-white font-rubik text-sm not-italic font-medium leading-normal tracking-[0.25px] uppercase">
                    view product <span className="text-[#FFA52F]">{product.regularPrice}VND</span>
                </div>
            </button>
        </div>
    )
}