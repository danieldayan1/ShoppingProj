export interface Product {
    product_name: string;
    product_id: number;
    category_id: number;
}
  
export interface ProductToBuy {
    name: string;
    quantity: number;
    id: number;
}

export interface ProductsByCategory {
    [key: string]: Product[];
}

export interface ProductsToBuyByCategory {
    [key: string]: ProductToBuy[];
}

export interface Order {
    mail: string;
    name: string;
    address: string;
    data: ProductOrder
}
export interface ProductOrder {
    [key: number]: number;
}