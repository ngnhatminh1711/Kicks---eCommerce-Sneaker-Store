import type { Product } from "../../models/product"
import url from "../../assets/images/Streettalk_White_JP8275_01_00_standard.jpg"

type Props = {
    product: Product
}

export default function ProductCard({ product }: Props) {
    return (
        <div className="flex w-[318px] flex-col items-center gap-y-[16px]">
            <div className="relative flex w-[302px] h-[334px] p-2 items-start rounded-[28px] bg-[#FAFAFA]">
                <img className="flex-1 self-stretch rounded-3xl" src={url} alt={product.name} />
                <div className="flex py-3 px-4 items-start gap-2.5 absolute left-2 top-2 rounded-tl-3xl rounded-br-3xl rounded-tr-none rounded-bl-none bg-[#4A69E2]">
                    <p className="text-white font-rubik text-[12px] not-italic font-semibold leading-normal">New</p>
                </div>
            </div>
            <h3 className="text-[#232321] font-rubik text-[24px] not-italic font-semibold leading-normal uppercase">{product.name}</h3>
            <button className="flex h-12 px-16 py-2 justify-center items-center gap-1 self-stretch rounded-sm bg-[#232321]">
                <div className=" text-white font-rubik text-sm not-italic font-medium leading-normal tracking-[0.25px] uppercase">
                    view product <span className="text-[#FFA52F]">{product.regularPrice}VND</span>
                </div>
            </button>
        </div>
    )
}