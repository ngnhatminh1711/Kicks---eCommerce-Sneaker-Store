export type Product = {
    id: number;
    name: string;
    sku: string;
    brandName: string;
    regularPrice: number;
    salePrice: number;
    stockQuantity: number;
    mainImageUrl: string;
    createdAt: Date;
    updatedAt: Date;
}