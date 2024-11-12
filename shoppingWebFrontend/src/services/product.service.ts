import { Order, ProductsByCategory } from "../models/product.model";

const BASE_URL = 'http://localhost:5172';

export const getProducts = async (): Promise<ProductsByCategory> => {
    const response = await fetch(`${BASE_URL}/products`);
    return response.json();
    // return {
    //     'vegetables and fruits': [{ name: 'Apple', id: 6, categoryId: 6}],
    //     'dairy products': [
    //         { name: 'Yellow cheese', id: 1, categoryId: 1 },
    //         { name: 'Yogurt', id: 2, categoryId: 2 },
    //         { name: 'butter',id: 3, categoryId: 3 }
    //     ],
    //     'Meat and fish': [
    //         { name: 'Sausages', id: 4, categoryId: 4 },
    //         { name: 'Salmon fish', id: 5, categoryId: 5 }
    //     ],
    //     'cleaning products': [
    //         { name: 'Detergent', id: 6, categoryId: 6 },
    //         { name: 'Soap', id: 7, categoryId: 7 }
    //     ],
    //     'cleaning productsdd': [
    //         { name: 'Detergent', id: 6, categoryId: 6 },
    //         { name: 'Soap', id: 7, categoryId: 7 }
    //     ],
    //     'cleaning productsdddd': [
    //         { name: 'Detergent', id: 6, categoryId: 6 },
    //         { name: 'Soap', id: 7, categoryId: 7 }
    //     ]
    // };
}

export const saveOrder = async (order: Order): Promise<void> => {
    // console.log(order);
    await fetch(`${BASE_URL}/add`, {
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });
}