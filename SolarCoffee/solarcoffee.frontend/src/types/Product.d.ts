export interface IProduct{
    if: number;
    createdOn: Date;
    updatedOn: Date;
    name: string;
    description: string;
    price: number;
    isTaxable: boolean;
    isArchived: boolean;
}

export interface IProductInventory{
    id: number;
    product: IProduct;
    quantityOnHand: number;
    idealQuantity: number;
}