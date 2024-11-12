import { Order, ProductsByCategory } from "../models/product.model";

const BASE_URL = 'http://localhost:5172';

export const getProducts = async (): Promise<ProductsByCategory> => {
    const response = await fetch(`${BASE_URL}/products`);
    return response.json();
}

export const saveOrder = async (order: Order): Promise<void> => {
    await fetch(`${BASE_URL}/add`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });
}